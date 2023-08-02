using Microsoft.AspNetCore.Http;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IPictureService
    {
        public Task<string> UploadAsync(IFormFile file);

        public Task<string> DownloadAsync(string id);

        public Task DeleteAsync(string id, string versionId = null);
    }
}
