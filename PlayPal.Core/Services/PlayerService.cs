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
    public class PlayerService : IPlayerService
    {
        private readonly IRepository _repository;
        private readonly IPositionService _positionService;
        private readonly UserManager<PlayPalUser> _userManager;
        private readonly IPictureService _pictureService;

        public PlayerService(
            IRepository repository,
            IPositionService positionService,
            UserManager<PlayPalUser> userManager,
            IPictureService pictureService)
        {
            _repository = repository;
            _positionService = positionService;
            _userManager = userManager;
            _pictureService = pictureService;
        }

        public async Task<bool> CheckAvailabilityAsync(Guid playerId, DateTime startingTime, DateTime endingTime)
        {
            var playerGames = await _repository.AllReadonly<Game>()
                .Where(g => (g.EndingTime > DateTime.UtcNow) &&
                (g.PendingPlayers.Any(p => p.PlayerId == playerId) || g.HomeTeam.Players.Any(p => p.PlayerId == playerId) || g.AwayTeam.Players.Any(p => p.PlayerId == playerId)))
                .ToListAsync();

            bool isAvailable = !playerGames.Any(g => (g.StartingTime > startingTime && g.StartingTime < endingTime) || (g.EndingTime > startingTime && g.EndingTime < endingTime) || (g.StartingTime < startingTime && g.EndingTime > endingTime));

            return isAvailable;
        }

        public async Task CreatePlayerAsync(RegisterUserInputModel model)
        {
            var player = new Player()
            {
                Id = model.Player!.Id,
                Name = model.Player!.Name,
                CurrentCity = model.Player.City,
                NormalizedCurrentCity = model.Player.City.ToUpper(),
                Position = await _positionService.GetPositionByIdAsync(model.Player.Position),
                UserId = model.Id
            };

            if (model.ProfilePicture != null)
            {
                string pictureId = await _pictureService.UploadAsync(model.ProfilePicture);

                player.ProfilePictureId = pictureId;
            }

            await _repository.AddAsync(player);
            await _repository.SaveChangesAsync();
        }

        public async Task DeletePlayerAsync(Guid? playerId)
        {
            if (playerId != null)
            {
                var player = await _repository.GetByIdAsync<Player>((Guid)playerId);

                if (player != null)
                {
                    player.UserId = null;
                    player.User = null;
                    await _repository.DeleteAsync<Player>((Guid)playerId);
                    await _repository.SaveChangesAsync();
                }
            }
        }

        public async Task<EditPlayerProfileInputModel> GetEditPlayerProfileInputModelAsync(Guid playerId, string email)
        {
            var player = await GetPlayerAsync(playerId);

            if (player == null)
            {
                return null;
            }

            var positions = await _positionService.GetAllPositionsModels();

            var model = new EditPlayerProfileInputModel()
            {
                Email = email,
                Id = playerId,
                Name = player.Name,
                CurrentCity = player.CurrentCity,
                Position = player.PositionId,
                Positions = positions,
            };

            if (player.ProfilePictureId != null)
            {
                model.ProfilePictureUrl = await _pictureService.DownloadAsync(player.ProfilePictureId);
            }
            else
            {
                model.ProfilePictureUrl = ApplicationConstants.DefaultProfilePicUrl;
            }

            return model;
        }

        public async Task<Player> GetPlayerAsync(Guid id)
        {
            var player = await _repository.All<Player>()
                .Include(p => p.Goals)
                .Include(p => p.Teams)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return player;
        }

        public async Task<PlayerProfileViewModel> GetPlayerProfileViewModelAsync(Guid playerId)
        {
            var player = await GetPlayerAsync((Guid)playerId);

            if (player == null)
            {
                return null;
            }

            var position = await _positionService.GetPositionByIdAsync(player.PositionId);

            var user = _userManager.Users.FirstOrDefault(u => u.PlayerId == playerId);
            var userId = user.Id;

            var profilePictureId = player.ProfilePictureId;

            var model = new PlayerProfileViewModel()
            {
                Id = (Guid)playerId,
                UserId = userId,
                Name = player.Name,
                CurrentCity = player.CurrentCity,
                Position = position.Name,
                Games = player.Teams.Count,
                Goals = player.Goals.Where(g => !g.IsAutoGoal).Count() - player.Goals.Where(g => g.IsAutoGoal).Count()
            };

            if (profilePictureId != null)
            {
                var pictureUrl = await _pictureService.DownloadAsync(profilePictureId);

                model.ProfilePictureUrl = pictureUrl;
            }
            else
            {
                model.ProfilePictureUrl = ApplicationConstants.DefaultProfilePicUrl;
            }

            return model;

        }

        public async Task<ICollection<PlayerViewModel>> SearchPlayer(string name, string email, string city)
        {
            var players = await _repository.All<Player>()
                .Include(p => p.User)
                .Where(p => (name != null ? p.Name.ToUpper().Contains(name.ToUpper()) : true) &&
                (email != null ? p.User!.Email.ToUpper().Contains(email.ToUpper()) : true) &&
                (city != null ? p.CurrentCity.ToUpper().Contains(city.ToUpper()) : true))
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    City = p.CurrentCity,
                    Email = p.User!.Email
                })
                .ToListAsync();

            return players;
        }

        public async Task UpdatePlayer(EditPlayerProfileInputModel model, Guid userId)
        {
            var player = await _repository.GetByIdAsync<Player>(model.Id);

            var user = await _userManager.FindByIdAsync(userId.ToString());

            var oldPictureId = player.ProfilePictureId;

            if (model.ProfilePicture != null)
            {
                string pictureId = await _pictureService.UploadAsync(model.ProfilePicture);

                player.ProfilePictureId = pictureId;

                if (oldPictureId != null)
                {
                    await _pictureService.DeleteAsync(oldPictureId);
                }
            }

            player.Name = model.Name;
            player.CurrentCity = model.CurrentCity;
            player.PositionId = model.Position;

            var claims = await _userManager.GetClaimsAsync(user);

            var oldNameClaim = claims.FirstOrDefault(c => c.Type == PlayPalClaimTypes.Name);

            await _userManager.RemoveClaimAsync(user, oldNameClaim);

            string newName = model.Name;

            var newNameClaim = new Claim(PlayPalClaimTypes.Name, newName);

            var oldCityClaim = claims.FirstOrDefault(c => c.Type == PlayPalClaimTypes.City); 
            
            await _userManager.RemoveClaimAsync(user, oldCityClaim);

            string newCity = model.CurrentCity;

            var newCityClaim = new Claim(PlayPalClaimTypes.City, newCity);

            await _userManager.AddClaimAsync(user, newNameClaim);

            await _userManager.AddClaimAsync(user, newCityClaim);

            await _repository.Update(player);
        }
    }
}
