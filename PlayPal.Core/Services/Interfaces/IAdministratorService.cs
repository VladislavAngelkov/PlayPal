using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IAdministratorService
    {
        public Task CreateAdministrator(RegisterUserInputModel model);

        public Task<ICollection<AdministratorRequestViewModel>> GetAdministratorRequestsAsync();

        public Task PromoteUserToAdministrator(string email, Guid administratorId);

        public Task DeleteAdministratorAsync(Guid administratorId);

        public Task<Administrator> GetAdministratorAsync(Guid administratorId);

        public Task UpdateAdministratorAsync(EditAdministratorProfileInputModel model, Guid userId);

        public Task<AdministratorProfileViewModel> GetAdministratorProfileViewModelAsync(Guid administratorId, Guid userId);

        public Task<EditAdministratorProfileInputModel> GetEditAdministratorProfileInputModelAsync(Guid administratorId, string email);
    }
}
