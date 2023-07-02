using Microsoft.AspNetCore.Identity;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using System.Security.Claims;

namespace PlayPal.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<PlayPalUser> _signInManager;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly IUserStore<PlayPalUser> _userStore;
        private readonly IUserEmailStore<PlayPalUser> _emailStore;
        private readonly IPlayerService _playerService;

        public AccountService(
            UserManager<PlayPalUser> userManager,
            IUserStore<PlayPalUser> userStore,
            SignInManager<PlayPalUser> signInManager,
            IPlayerService playerService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _playerService = playerService;
        }

        public async Task RegisterPlayerUserAsync(RegisterUserInputModel model)
        {
            var user = await RegisterUserAsync(model);

            await _playerService.CreatePlayerAsync(model);

            await _userManager.AddToRoleAsync(user, "Player");

            var claim = new Claim("PlayerId", model.Player!.Id.ToString());
            await _userManager.AddClaimAsync(user, claim);
        }

        private async Task<PlayPalUser> RegisterUserAsync(RegisterUserInputModel model)
        {
            var user = new PlayPalUser();
            user.Id = model.Id;
            if (model.Player != null)
            {
                user.PlayerId = model.Player.Id;
            }
            else if (model.Administrator != null)
            {
                user.AdministratorId = model.Administrator.Id;
            }
            else if (model.FieldOwner != null)
            {
                user.FieldOwnerId = model.FieldOwner.Id;
            }

            await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, model.Password);

            return user;
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
