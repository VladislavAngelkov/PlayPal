using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PlayPal.Core.Services.Interfaces;
using System;

namespace PlayPal.Core.Services
{
    public class PictureService : IPictureService
    {
        private readonly IConfiguration _configuration;
        private readonly IAmazonS3 _client;
        private readonly string _bucketName;

        public PictureService(
            IConfiguration configuration,
            IAmazonS3 client)
        {
            _configuration = configuration;
            _client = client;
            _bucketName = configuration.GetValue<string>("Objectstore:DocumentBucket")!;

            AmazonS3Config config = _client.Config as AmazonS3Config;

            if (config != null)
            {
                config.ForcePathStyle = true;
            }
        }

        public async Task DeleteAsync(string id, string versionId = null)
        {
            DeleteObjectRequest request = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = id
            };

            if (!string.IsNullOrEmpty(versionId))
            {
                request.VersionId = versionId;
            }

            await _client.DeleteObjectAsync(request);
        }

        public async Task<string> DownloadAsync(string id)
        {
            var getRequest = new GetObjectRequest()
            {
                BucketName = _bucketName,
                Key = id
            };

            try
            {
                GetObjectResponse response = await _client.GetObjectAsync(getRequest);

                using (MemoryStream ms = new MemoryStream())
                {
                    response.ResponseStream.CopyTo(ms);

                    var data = ms.ToArray();

                    var dataString = Convert.ToBase64String(data);

                    string dataUrl = string.Format("data:image/png;base64,{0}", dataString);

                    return dataUrl;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var stream = file.OpenReadStream();

            string key = Guid.NewGuid().ToString();

            var request = new PutObjectRequest()
            {
                BucketName = _bucketName,
                InputStream = stream,
                AutoCloseStream = true,
                Key = key,
                ContentType = file.ContentType
            };

            try
            {
                var response = await _client.PutObjectAsync(request);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Something went wrong with uploading the file", ex);
            }

            return request.Key;
        }
    }
}
