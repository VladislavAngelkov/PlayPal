using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly SignInManager<PlayPalUser> _signInManager;
        private readonly IUserStore<PlayPalUser> _userStore;

        public AccountService(
            UserManager<PlayPalUser> userManager,
            SignInManager<PlayPalUser> signInManager,
            IUserStore<PlayPalUser> userStore)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userStore = userStore;
        }

        public async Task RegisterUser(RegisterUserInputModel model)
        {
            var user = new PlayPalUser();

            await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, model.Password);
        }
    }
}
