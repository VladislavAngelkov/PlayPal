using PlayPal.Core.Models.InputModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IAccountService
    {
        public Task RegisterPlayerUserAsync(RegisterUserInputModel model);

        public Task ApplyAdministratorAsync(RegisterUserInputModel model);
    }
}
