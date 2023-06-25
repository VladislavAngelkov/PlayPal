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

        public PlayerService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreatePlayer(CreatePlayerInputModel model)
        {
            var player = new Player()
            {
                Name = model.Name,
                CurrentCity = model.City,
                Position = Enum.Parse<Position>(model.Position),
                UserId = model.Id
            };

            await _repository.AddAsync(player);
        }
    }
}
