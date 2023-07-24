using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository _repository;

        public GameService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(Guid gameId)
        {
            await _repository.DeleteAsync<Game>(gameId);
        }

        public async Task<bool> ExistAsync(Guid gameId)
        {
            var game = await _repository.GetByIdAsync<Game>(gameId);

            if (game == null || game.IsDeleted)
            {
                return false;
            }

            return true;
        }

        public async Task<FieldGameViewModel> GamesAsync(Guid fieldId)
        {
            var games = await _repository.All<Game>()
                .Where(g => g.FieldId == fieldId &&
                g.EndingTime > DateTime.UtcNow)
                .Include(g => g.Creator.User)
                .Select(g => new GameViewModel()
                {
                    Id = g.Id,
                    Creator = g.Creator.User!.Email,
                    StartingTime = g.StartingTime,
                    EndingTime = g.EndingTime
                })
                .ToListAsync();

            var model = new FieldGameViewModel()
            {
                Id = fieldId,
                Games = games
            };

            return model;
        }
    }
}
