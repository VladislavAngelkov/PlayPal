using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayPal.Common;
using PlayPal.Common.IdentityConstants;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using System.Security.Claims;

namespace PlayPal.Core.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IRepository _repository;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly IPictureService _pictureService;

        public AdministratorService(
            IRepository repository,
            UserManager<PlayPalUser> userManager,
            IPictureService pictureService)
        {
            _repository = repository;
            _userManager = userManager;
            _pictureService = pictureService;
        }

        public async Task CreateAdministrator(RegisterUserInputModel model)
        {
            var administrator = new Administrator()
            {
                Id = model.Administrator!.Id,
                FirstName = model.Administrator.FirstName,
                LastName = model.Administrator.LastName,
                UserId = model.Id
            };

            if (model.ProfilePicture != null)
            {
                string pictureId = await _pictureService.UploadAsync(model.ProfilePicture);

                administrator.ProfilePictureId = pictureId;
            }

            await _repository.AddAsync<Administrator>(administrator);
        }

        public async Task<ICollection<AdministratorRequestViewModel>> GetAdministratorRequestsAsync()
        {
            var administrators = await _userManager
                .Users
                .Where(u => u.Administator != null)
                .AsNoTracking()
                .ToListAsync();

            var administratorsRequests = new List<AdministratorRequestViewModel>();

            foreach (var administrator in administrators)
            {
                var userClaims = await _userManager.GetClaimsAsync(administrator);

                if (!userClaims.Any(c => c.Type == PlayPalClaimTypes.AdministratorId))
                {
                    var application = new AdministratorRequestViewModel()
                    {
                        UserId = administrator.Id,
                        AdministratorId = administrator.AdministratorId,
                        Email = administrator.Email
                    };

                    administratorsRequests.Add(application);
                }
            }

            return administratorsRequests;
        }

        public async Task PromoteUserToAdministrator(string email, Guid administratorId)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var claim = new Claim(PlayPalClaimTypes.AdministratorId, administratorId.ToString());

            await _userManager.AddClaimAsync(user, claim);
        }

        public async Task DeleteAdministratorAsync(Guid administratorId)
        {
            var administrator = await _repository.GetByIdAsync<Administrator>(administratorId);

            if (administrator != null)
            {
                administrator.UserId = null;
                administrator.User = null;
                await _repository.DeleteAsync<Administrator>(administratorId);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<Administrator> GetAdministratorAsync(Guid administratorId)
        {
            var administrator = await _repository.GetByIdAsync<Administrator>(administratorId);

            return administrator;
        }

        public async Task UpdateAdministratorAsync(EditAdministratorProfileInputModel model, Guid userId)
        {
            var administrator = await _repository.GetByIdAsync<Administrator>(model.Id);

            var user = await _userManager.FindByIdAsync(userId.ToString());

            var oldPictureId = administrator.ProfilePictureId;

            administrator.FirstName = model.FirstName;
            administrator.LastName = model.LastName;

            if (model.ProfilePicture != null)
            {
                string pictureId = await _pictureService.UploadAsync(model.ProfilePicture);

                administrator.ProfilePictureId = pictureId;

                if (oldPictureId != null)
                {
                    await _pictureService.DeleteAsync(oldPictureId);
                }
            }

            var claims = await _userManager.GetClaimsAsync(user);

            var oldNameClaim = claims.FirstOrDefault(c => c.Type == PlayPalClaimTypes.Name);

            await _userManager.RemoveClaimAsync(user, oldNameClaim);

            string newName = $"{model.FirstName} {model.LastName}";

            var newNameClaim = new Claim(PlayPalClaimTypes.Name, newName);

            await _userManager.AddClaimAsync(user, newNameClaim);

            await _userManager.UpdateAsync(user);

            await _repository.Update(administrator);
        }

        public async Task<AdministratorProfileViewModel> GetAdministratorProfileViewModelAsync(Guid administratorId, Guid userId)
        {
            var administrator = await GetAdministratorAsync(administratorId);

            if (administrator == null)
            {
                return null;
            }

            var model = new AdministratorProfileViewModel()
            {
                Id = administratorId,
                FirstName = administrator.FirstName,
                LastName = administrator.LastName,
            };

            if (administrator.ProfilePictureId != null)
            {
                var profilePictureUrl = await _pictureService.DownloadAsync(administrator.ProfilePictureId);

                model.ProfilePictureUrl = profilePictureUrl;
            }
            else
            {
                model.ProfilePictureUrl = ApplicationConstants.DefaultProfilePicUrl;
            }

            return model;
        }

        public async Task<EditAdministratorProfileInputModel> GetEditAdministratorProfileInputModelAsync(Guid administratorId, string email)
        {
            var administrator = await GetAdministratorAsync(administratorId);

            var model = new EditAdministratorProfileInputModel()
            {
                Email = email,
                Id = administratorId,
                FirstName = administrator.FirstName,
                LastName = administrator.LastName
            };

            if (administrator.ProfilePictureId != null)
            {
                var pictureUrl = await _pictureService.DownloadAsync(administrator.ProfilePictureId);

                model.ProfilePictureUrl = pictureUrl;
            }
            else
            {
                model.ProfilePictureUrl = ApplicationConstants.DefaultProfilePicUrl;
            }

            return model;
        }
    }
}
