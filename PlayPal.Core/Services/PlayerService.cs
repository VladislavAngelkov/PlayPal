using PlayPal.Core.Models.InputModels;
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

        public async Task<Guid> CreatePlayerAsync(RegisterUserInputModel model)
        {
            var player = new Player()
            {
                Name = model.Player!.Name,
                CurrentCity = model.Player.City,
                NormalizedCurrentCity = model.Player.City.ToUpper(),
                Position = await _positionService.GetPositionByIdAsync(model.Player.Position),
                UserId = model.Id
            };

            await _repository.AddAsync(player);

            return player.Id;
        }

        public async Task DeletePlayerAsync(Guid? playerId)
        {
            if (playerId != null)
            {
                var player = await _repository.GetByIdAsync<Player>(playerId);

                if (player != null)
                {
                    player.UserId = null;
                    player.User = null;
                    await _repository.DeleteAsync<Player>(playerId);
                    await _repository.SaveChangesAsync();
                }
            }
        }

        public async Task<Player> GetPlayerAsync(Guid id)
        {
            var player = await _repository.GetByIdAsync<Player>(id);

            return player;
        }
    }
}
