using Microsoft.AspNetCore.Identity;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository _repository;
        private readonly IPlayerService _playerService;

        public TeamService(
            IRepository repository,
            IPlayerService playerService)
        {
            _playerService = playerService;
            _repository = repository;
        }    
        
        public async Task AddPlayerToTeamAsync(Guid playerId, Guid teamId)
        {
            var player = await _playerService.GetPlayerAsync(playerId);

            var team = await _repository.GetByIdAsync<Team>(teamId);

            PlayerTeam playerTeam = new PlayerTeam()
            {
                PlayerId = playerId,
                TeamId = teamId
            };

            team.Players.Add(playerTeam);
            player.Teams.Add(playerTeam);

            await _repository.SaveChangesAsync();
        }
    }
}
