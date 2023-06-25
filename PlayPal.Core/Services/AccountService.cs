using Microsoft.AspNetCore.Identity;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<PlayPalUser> _signInManager;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly IUserStore<PlayPalUser> _userStore;
        private readonly IUserEmailStore<PlayPalUser> _emailStore;

        public AccountService(
            UserManager<PlayPalUser> userManager,
            IUserStore<PlayPalUser> userStore,
            SignInManager<PlayPalUser> signInManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
        }

        public async Task RegisterUser(RegisterUserInputModel model)
        {
            var user = new PlayPalUser();
            user.Id = model.Id;
            user.PlayerId = model.PlayerId;

            await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, model.Password);
        }
        private IUserEmailStore<PlayPalUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<PlayPalUser>)_userStore;
        }
    }
}
