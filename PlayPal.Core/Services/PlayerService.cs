using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayPal.Common.IdentityConstants;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data;
using PlayPal.Data.Models;
using PlayPal.Data.Models.Enums;
using System.Security.Claims;

namespace PlayPal.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository _repository;
        private readonly IPositionService _positionService;
        private readonly UserManager<PlayPalUser> _userManager;

        public PlayerService(
            IRepository repository,
            IPositionService positionService,
            UserManager<PlayPalUser> userManager)
        {
            _repository = repository;
            _positionService = positionService;
            _userManager = userManager;
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

        public async Task<Player> GetPlayerAsync(Guid id)
        {
            var player = await _repository.All<Player>()
                .Include(p => p.Goals)
                .Include(p => p.Teams)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return player;
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

            player.Name = model.Name;
            player.CurrentCity = model.CurrentCity;
            player.PositionId = model.Position;

            var user = await _userManager.FindByIdAsync(userId.ToString());

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
