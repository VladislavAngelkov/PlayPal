using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data;
using PlayPal.Data.Models;
using PlayPal.Data.Models.Enums;

namespace PlayPal.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository _repository;
        private readonly IPositionService _positionService;

        public PlayerService(
            IRepository repository,
            IPositionService positionService)
        {
            _repository = repository;
            _positionService = positionService;
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
            var player = await _repository.GetByIdAsync<Player>(id);

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
    }
}
