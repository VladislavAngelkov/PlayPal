using PlayPal.Core.Models.InputModels;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<PlayPalUser> RegisterPlayerUserAsync(RegisterUserInputModel model);

        public Task<PlayPalUser> RegisterFieldOwnerAsync(RegisterUserInputModel model);

        public Task<PlayPalUser> ApplyAdministratorAsync(RegisterUserInputModel model);

        public Task DeleteUser(Guid userId);

        public Task<bool> UserExist(string email);

        public Task UpdateUserName(Guid userId, string newName);
    }
}
