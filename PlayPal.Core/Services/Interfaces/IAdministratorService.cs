using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IAdministratorService
    {
        public Task CreateAdministrator(RegisterUserInputModel model);

        public Task<ICollection<AdministratorRequestViewModel>> GetAdministratorRequestsAsync();

        public Task PromoteUserToAdministrator(string email, Guid administratorId);

        public Task DeleteAdministratorAsync(Guid administratorId);
    }
}
