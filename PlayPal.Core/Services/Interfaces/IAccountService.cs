using PlayPal.Core.Models.InputModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IAccountService
    {
        public Task RegisterUser(RegisterUserInputModel model);
    }
}
