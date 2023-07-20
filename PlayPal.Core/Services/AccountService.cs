using Microsoft.AspNetCore.Identity;
using PlayPal.Common.IdentityConstants;
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
        private readonly IAdministratorService _administratorService;
        private readonly IFieldOwnerService _fieldOwnerService;

        public AccountService(
            UserManager<PlayPalUser> userManager,
            IUserStore<PlayPalUser> userStore,
            SignInManager<PlayPalUser> signInManager,
            IPlayerService playerService,
            IAdministratorService administratorService,
            IFieldOwnerService fieldOwnerService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _playerService = playerService;
            _administratorService = administratorService;
            _fieldOwnerService = fieldOwnerService;
        }

        public async Task<PlayPalUser> RegisterPlayerUserAsync(RegisterUserInputModel model)
        {
            var user = await RegisterUserAsync(model);

            await _playerService.CreatePlayerAsync(model);

            await _userManager.AddToRoleAsync(user, PlayPalRoleNames.Player);

            var playerIdClaim = new Claim(PlayPalClaimTypes.PlayerId, model.Player!.Id.ToString());
            await _userManager.AddClaimAsync(user, playerIdClaim);

            var cityClaim = new Claim(PlayPalClaimTypes.City, model.Player.City);
            await _userManager.AddClaimAsync(user, cityClaim);

            var nameClaim = new Claim(PlayPalClaimTypes.Name, model.Player.Name);
            await _userManager.AddClaimAsync(user, nameClaim);

            return user;
        }

        public async Task<PlayPalUser> ApplyAdministratorAsync(RegisterUserInputModel model)
        {
            var user = await RegisterUserAsync(model);

            await _administratorService.CreateAdministrator(model);

            await _userManager.AddToRoleAsync(user, PlayPalRoleNames.Administrator);

            var nameClaim = new Claim(PlayPalClaimTypes.Name, $"{model.Administrator.FirstName} {model.Administrator.LastName}");
            await _userManager.AddClaimAsync(user, nameClaim);

            return user;
        }

        public async Task<PlayPalUser> RegisterFieldOwnerAsync(RegisterUserInputModel model)
        {
            var user = await RegisterUserAsync(model);

            await _fieldOwnerService.CreateFieldOwner(model);

            await _userManager.AddToRoleAsync(user, PlayPalRoleNames.FieldOwner);

            var fieldOwnerIdClaim = new Claim(PlayPalClaimTypes.FieldOwnerId, model.FieldOwner!.Id.ToString());
            await _userManager.AddClaimAsync(user, fieldOwnerIdClaim);

            var nameClaim = new Claim(PlayPalClaimTypes.Name, $"{model.FieldOwner.Title} {model.FieldOwner.FirstName} {model.FieldOwner.LastName}");
            await _userManager.AddClaimAsync(user, nameClaim);

            return user;
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

        public async Task DeleteUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var administratorId = user.AdministratorId;
            var fieldOwnerId = user.FieldOwnerId;
            var playerId = user.PlayerId;

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            await _administratorService.DeleteAdministratorAsync(administratorId);

            await _fieldOwnerService.DeleteFieldOwnerAsync(fieldOwnerId);

            await _playerService.DeletePlayerAsync(playerId);
        }

        public async Task<bool> UserExist(string email)
        {
            if (await _userManager.FindByEmailAsync(email) != null)
            {
                return true;
            }
            return false;
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
