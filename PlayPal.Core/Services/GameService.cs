using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using System.Numerics;

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

            await AddToHomeTeam(game.Id, game.CreatorId);
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

        public async Task<FieldGameViewModel> GetGamesByFieldAsync(Guid fieldId)
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

        public async Task<GameDetailViewModel> GetGameModelAsync(Guid gameId)
        {
            var game = await _repository.AllReadonly<Game>()
                .Include(g => g.Field)
                .Include(g => g.Creator)
                .Include(g => g.PendingPlayers)
                .ThenInclude(pp => pp.Player)
                .Include(g => g.HomeTeam)
                .ThenInclude(ht => ht.Players)
                .ThenInclude(p => p.Player)
                .Include(g => g.AwayTeam)
                .ThenInclude(at => at.Players)
                .ThenInclude(p => p.Player)
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                return null;
            }

            var model = new GameDetailViewModel()
            {
                Id = game.Id,
                Creator = game.Creator.Name,
                CreatorId = game.CreatorId,
                Field = game.Field.Name,
                StartingTime = game.StartingTime,
                EndingTime = game.EndingTime,
                PendingPlayers = game.PendingPlayers
                .Select(p => new GameDetailPlayerViewModel()
                {
                    Id = p.PlayerId,
                    Name = p.Player.Name,
                }).ToList(),
                HomeTeam = game.HomeTeam.Players
                .Select(p => new GameDetailPlayerViewModel()
                {
                    Id = p.PlayerId,
                    Name = p.Player.Name,
                }).ToList(),
                AwayTeam = game.AwayTeam.Players
                .Select(p => new GameDetailPlayerViewModel()
                {
                    Id = p.PlayerId,
                    Name = p.Player.Name,
                }).ToList(),
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
                    CreatorId = g.CreatorId,
                    FieldName = g.Field.Name,
                    EndingTime = g.EndingTime,
                    StartingTime = g.StartingTime,
                    Creator = g.Creator.Name,
                })
                .ToListAsync();
                
            return models;
        }

        public async Task<ICollection<GameViewModel>> GetGamesByCityAsync(string city, Guid playerId)
        {
            var models = await _repository.All<Game>()
                .Where(g => g.Field.City.ToUpper() == city.ToUpper() &&
                g.StartingTime > DateTime.UtcNow &&
                !g.PendingPlayers.Any(p => p.PlayerId==playerId) &&
                !g.HomeTeam.Players.Any(p => p.PlayerId== playerId) &&
                !g.AwayTeam.Players.Any(p => p.PlayerId == playerId))
                .Include(g => g.Field)
                .Include(g => g.Creator)
                .Select(g => new GameViewModel()
                {
                    Id = g.Id,
                    FieldName = g.Field.Name,
                    StartingTime = g.StartingTime,
                    EndingTime = g.EndingTime,
                    Creator = g.Creator.Name,
                    CreatorId = g.CreatorId,
                })
                .ToListAsync();
                
            return models;
        }

        public async Task JoinPlayerToGame(Guid playerId, Guid gameId)
        {
            var player = await _repository.GetByIdAsync<Player>(playerId);

            var game = await _repository.GetByIdAsync<Game>(gameId);

            var pendingPlayerGame = new PendingPlayerGame()
            {
                PlayerId = playerId,
                GameId = gameId
            };

            player.PendingGames.Add(pendingPlayerGame);
            game.PendingPlayers.Add(pendingPlayerGame);

            //await _repository.Update(player);
            //await _repository.Update(game);   

            await _repository.SaveChangesAsync();
        }

        public async Task LeaveGame(Guid gameId, Guid playerId)
        {

            var game = await _repository.All<Game>(g => g.Id == gameId)
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .FirstOrDefaultAsync();

            if (game == null)
            {
                return;
            }

            _repository.HardDeleteAsync<PendingPlayerGame>(g => g.GameId == gameId && g.PlayerId == playerId);

            _repository.HardDeleteAsync<PlayerTeam>(t => t.TeamId == game.HomeTeam.Id && t.PlayerId == playerId);

            _repository.HardDeleteAsync<PlayerTeam>(t => t.TeamId == game.AwayTeam.Id && t.PlayerId == playerId);

            await _repository.SaveChangesAsync();


            //var game = await _repository.All<Game>(g => g.Id == gameId)
            //    .Include(g => g.PendingPlayers)
            //    .Include(g => g.HomeTeam)
            //    .ThenInclude(ht => ht.Players)
            //    .Include(g => g.AwayTeam)
            //    .ThenInclude(at => at.Players)
            //    .FirstOrDefaultAsync();

            //if (game == null)
            //{
            //    return;
            //}

            //var player = await _repository.GetByIdAsync<Player>(playerId);

            //if (game.PendingPlayers.Any(p => p.PlayerId == player.Id))
            //{
            //    _repository.HardDeleteAsync<PendingPlayerGame>(g => g.GameId == game.Id && g.PlayerId == player.Id);

            //    var pendingPlayerGame = game.PendingPlayers.FirstOrDefault(p => p.PlayerId == player.Id);
            //    game.PendingPlayers.Remove(pendingPlayerGame!);

            //    player.PendingGames.Remove(pendingPlayerGame!);
            //}
            //else if (game.HomeTeam.Players.Any(p => p.PlayerId == player.Id))
            //{
            //    var playerTeam = game.HomeTeam.Players.FirstOrDefault(p => p.PlayerId == player.Id);
            //    game.HomeTeam.Players.Remove(playerTeam!);

            //    var playerTeam = player.Teams.FirstOrDefault(pt => pt.TeamId == game.HomeTeam.Id);
            //    player.Teams.Remove(playerTeam!);
            //}
            //else if (game.AwayTeam.Players.Any(p => p.PlayerId == player.Id))
            //{
            //    var pendingPlayerGame = game.AwayTeam.Players.FirstOrDefault(p => p.PlayerId == player.Id);
            //    game.AwayTeam.Players.Remove(pendingPlayerGame!);

            //    var playerTeam = player.Teams.FirstOrDefault(pt => pt.TeamId == game.AwayTeam.Id);
            //    player.Teams.Remove(playerTeam!);
            //}

            await _repository.SaveChangesAsync();
        }

        public async Task AddToHomeTeam(Guid gameId, Guid playerId)
        {
            var game = await _repository
                .All<Game>(g => g.Id == gameId)
                .Include(g => g.HomeTeam)
                .FirstOrDefaultAsync();

            if (game == null)
            {
                return;
            }

            var teamId = game.HomeTeam.Id;

            await LeaveGame(gameId, playerId);

            await _teamService.AddPlayerToTeamAsync(playerId, teamId);
        }

        public async Task AddToAwayTeam(Guid gameId, Guid playerId)
        {
            var game = await _repository
                .All<Game>(g => g.Id == gameId)
                .Include(g => g.AwayTeam)
                .FirstOrDefaultAsync();

            if (game == null)
            {
                return;
            }

            var teamId = game.AwayTeam.Id;

            await LeaveGame(gameId, playerId);

            await _teamService.AddPlayerToTeamAsync(playerId, teamId);
        }
    }
}
