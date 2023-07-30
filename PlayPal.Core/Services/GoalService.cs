using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class GoalService : IGoalService
    {
        private readonly IRepository _repository;

        public GoalService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> GetAwayTeamGoalCount(Guid gameId)
        {
            var game = await _repository.All<Game>()
                .Include(g => g.HomeTeam)
                .ThenInclude(ht => ht.Players)
                .ThenInclude(pt => pt.Player)
                .ThenInclude(p => p.Goals)
                .Include(g => g.AwayTeam)
                .ThenInclude(at => at.Players)
                .ThenInclude(pt => pt.Player)
                .ThenInclude(p => p.Goals)
                .Where(g => g.Id == gameId)
                .FirstAsync();

            int awayTeamGoals = game.AwayTeam.Players.Sum(p => p.Player.Goals.Where(g => g.GameId == game.Id && !g.IsAutoGoal && !g.IsDeleted).Count()) + game.HomeTeam.Players.Sum(p => p.Player.Goals.Where(g => g.GameId == game.Id && g.IsAutoGoal && !g.IsDeleted).Count());

            return awayTeamGoals;
        }

        public async Task<int> GetHomeTeamGoalCount(Guid gameId)
        {
            var game = await _repository.All<Game>()
                .Include(g => g.HomeTeam)
                .ThenInclude(ht => ht.Players)
                .ThenInclude(pt => pt.Player)
                .ThenInclude(p => p.Goals)
                .Include(g => g.AwayTeam)
                .ThenInclude(at => at.Players)
                .ThenInclude(pt => pt.Player)
                .ThenInclude(p => p.Goals)
                .Where(g => g.Id == gameId)
                .FirstAsync();

            int homeTeamGoals = game.HomeTeam.Players.Sum(p => p.Player.Goals.Where(g => g.GameId == game.Id && !g.IsAutoGoal && !g.IsDeleted).Count()) + game.AwayTeam.Players.Sum(p => p.Player.Goals.Where(g => g.GameId == game.Id && g.IsAutoGoal && !g.IsDeleted).Count());


            return homeTeamGoals;
        }

        public async Task<GoalInputModel> GetGoalInputModel(Guid gameId)
        {
            var model = new GoalInputModel();
            model.GameId = gameId;

            var homePlayers = await _repository.All<Player>()
                .Where(p => p.Teams.Any(t => t.Team.HomeGame.Id == gameId))
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            var awayPlayers = await _repository.All<Player>()
                .Where(p => p.Teams.Any(t => t.Team.AwayGame.Id == gameId))
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            foreach (var player in homePlayers)
            {
                model.Players.Add(player);
            }

            foreach (var player in awayPlayers)
            {
                model.Players.Add(player);
            }

            return model;
        }

        public async Task Add(GoalInputModel model)
        {
            var goal = new Goal()
            {
                Id = model.Id,
                GameId = model.GameId,
                PlayerId = model.PlayerId,
                IsAutoGoal = model.IsAutoGoal
            };

            await _repository.AddAsync(goal);

            var game = await _repository.All<Game>()
                .Include(g => g.HomeTeam)
                .ThenInclude(ht => ht.Players)
                .Include(g => g.AwayTeam)
                .ThenInclude(at => at.Players)
                .Where(g => g.Id == model.GameId &&
                !g.IsDeleted)
                .FirstOrDefaultAsync();

            if (game.HomeTeam.Players.Any(p => p.PlayerId == model.PlayerId))
            {
                if (goal.IsAutoGoal)
                {
                    game.AwayTeamGoalCount++;
                }
                else
                {
                    game.HomeTeamGoalCount++;
                }
                
            }
            else
            {
                if (goal.IsAutoGoal)
                {
                    game.HomeTeamGoalCount++;
                }
                else
                {
                    game.AwayTeamGoalCount++;
                }
            }

            await _repository.Update(game);
        }
    }
}
