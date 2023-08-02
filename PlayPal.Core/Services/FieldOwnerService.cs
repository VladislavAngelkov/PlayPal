using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Identity;
using PlayPal.Common;
using PlayPal.Common.IdentityConstants;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Data.Models.Enums;
using System.Numerics;
using System.Security.Claims;

namespace PlayPal.Core.Services
{
    public class FieldOwnerService : IFieldOwnerService
    {
        private readonly IRepository _repository;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly IPictureService _pictureService;

        public FieldOwnerService(
            IRepository repository,
            UserManager<PlayPalUser> userManager,
            IPictureService pictureService)
        {
            _repository = repository;
            _userManager = userManager;
            _pictureService = pictureService;
        }

        public async Task CreateFieldOwner(RegisterUserInputModel model)
        {
            var fieldOwner = new FieldOwner()
            {
                Id = model.FieldOwner!.Id,
                Title = Enum.Parse<Title>(model.FieldOwner.Title),
                FirstName = model.FieldOwner.FirstName,
                LastName = model.FieldOwner.LastName,
                CompanyName = model.FieldOwner.CompanyName,
                ContactAddress = model.FieldOwner.ContactAddres,
                UserId = model.Id
            };

            if (model.ProfilePicture != null)
            {
                string pictureId = await _pictureService.UploadAsync(model.ProfilePicture);

                fieldOwner.ProfilePictureId = pictureId;
            }

            await _repository.AddAsync<FieldOwner>(fieldOwner);
        }

        public async Task DeleteFieldOwnerAsync(Guid? fieldOwnerId)
        {
            if (fieldOwnerId != null)
            {
                var fieldOwner = await _repository.GetByIdAsync<FieldOwner>((Guid)fieldOwnerId);

                if (fieldOwner != null)
                {
                    fieldOwner.UserId = null;
                    fieldOwner.User = null;
                    await _repository.DeleteAsync<FieldOwner>((Guid)fieldOwnerId);
                    await _repository.SaveChangesAsync();
                }
            }
        }

        public async Task<EditFieldOwnerProfileInputModel> GetEditFieldOwnerProfileInputModelAsync(Guid fieldOwnerId, string email)
        {
            var fieldOwner = await GetFieldOwnerAsync(fieldOwnerId);

            var model = new EditFieldOwnerProfileInputModel()
            {
                Email = email,
                Id = fieldOwnerId,
                FirstName = fieldOwner.FirstName,
                LastName = fieldOwner.LastName,
                CompanyName = fieldOwner.CompanyName,
                ContactAddress = fieldOwner.ContactAddress,
                Title = fieldOwner.Title.ToString()
            };

            if (fieldOwner.ProfilePictureId != null)
            {
                string pictureUrl = await _pictureService.DownloadAsync(fieldOwner.ProfilePictureId);

                model.ProfilePictureUrl = pictureUrl;
            }
            else
            {
                model.ProfilePictureUrl = ApplicationConstants.DefaultProfilePicUrl;
            }

            return model;
        }

        public async Task<FieldOwner> GetFieldOwnerAsync(Guid fieldOwnerId)
        {
            var fieldOwner = await _repository.GetByIdAsync<FieldOwner>(fieldOwnerId);

            return fieldOwner;
        }

        public async Task<FieldOwnerProfileViewModel> GetFieldOwnerProfileViewModelAsync(Guid fieldOwnerId)
        {
            var fieldOwner = await GetFieldOwnerAsync(fieldOwnerId);

            if (fieldOwner == null)
            {
                return null;
            }

            var model = new FieldOwnerProfileViewModel()
            {
                Id = fieldOwnerId,
                FirstName = fieldOwner.FirstName,
                LastName = fieldOwner.LastName,
                Title = fieldOwner.Title.ToString(),
                CompanyName = fieldOwner.CompanyName,
                ContactAddress = fieldOwner.ContactAddress,
            };

            if (fieldOwner.ProfilePictureId != null)
            {
                var pictureUrl = await _pictureService.DownloadAsync(fieldOwner.ProfilePictureId);

                model.ProfilePictureUrl = pictureUrl;
            }
            else
            {
                model.ProfilePictureUrl = ApplicationConstants.DefaultProfilePicUrl;
            }

            return model;
        }

        public async Task UpdateFieldOwnerAsync(EditFieldOwnerProfileInputModel model, Guid userId)
        {
            var fieldOwner = await _repository.GetByIdAsync<FieldOwner>(model.Id);

            var user = await _userManager.FindByIdAsync(userId.ToString());

            var oldPictureId = fieldOwner.ProfilePictureId;

            fieldOwner.FirstName = model.FirstName;
            fieldOwner.LastName = model.LastName;
            fieldOwner.Title = Enum.Parse<Title>(model.Title);
            fieldOwner.CompanyName = model.CompanyName;
            fieldOwner.ContactAddress = model.ContactAddress;

            if (model.ProfilePicture != null)
            {
                string pictureId = await _pictureService.UploadAsync(model.ProfilePicture);

                fieldOwner.ProfilePictureId = pictureId;

                if (oldPictureId != null)
                {
                    await _pictureService.DeleteAsync(oldPictureId);
                }
            }

            var claims = await _userManager.GetClaimsAsync(user);

            var oldNameClaim = claims.FirstOrDefault(c => c.Type == PlayPalClaimTypes.Name);

            await _userManager.RemoveClaimAsync(user, oldNameClaim);

            string newName = $"{model.Title} {model.FirstName} {model.LastName}";

            var newNameClaim = new Claim(PlayPalClaimTypes.Name, newName);

            await _userManager.AddClaimAsync(user, newNameClaim);

            await _repository.Update(fieldOwner);
        }
    }
}
