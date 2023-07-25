using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository _repository;
        private readonly ITeamService _teamService;

        public GameService(
            IRepository repository, 
            ITeamService teamService)
        {
            _repository = repository;
            _teamService = teamService;
        }

        public async Task CreateGameAsync(GameInputModel model)
        {
            var game = new Game()
            {
                Id = model.Id,
                FieldId = model.FieldId,
                CreatorId = model.CreatorId,
                StartingTime = model.StartingTime,
                EndingTime = model.EndingTime
            };

            var homeTeam = new Team()
            {
                HomeGameId = game.Id,
            };

            var awayTeam = new Team()
            {
                AwayGameId = game.Id
            };

            game.HomeTeam = homeTeam;
            game.AwayTeam = awayTeam;

            await _repository.AddAsync(game);

            await _teamService.AddPlayerToTeamAsync(model.CreatorId, homeTeam.Id);
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

        public async Task<ICollection<GameViewModel>> GetPlayerGamesAsync(Guid playerId)
        {
            var models = await _repository.All<Game>()
                .Where(g => (g.EndingTime > DateTime.UtcNow) &&
                (g.PendingPlayers.Any(p => p.PlayerId == playerId) || g.HomeTeam.Players.Any(p => p.PlayerId == playerId) || g.AwayTeam.Players.Any(p => p.PlayerId == playerId)))
                .Include(g => g.Field)
                .Include(g => g.Creator)
                .Select(g => new GameViewModel()
                {
                    Id = g.Id,
                    FieldName = g.Field.Name,
                    EndingTime = g.EndingTime,
                    StartingTime = g.StartingTime,
                    Creator = g.Creator.Name,
                })
                .ToListAsync();
                
            return models;
        }
    }
}
