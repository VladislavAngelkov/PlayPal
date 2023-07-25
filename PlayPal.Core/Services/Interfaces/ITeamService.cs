using PlayPal.Data.Models;

namespace PlayPal.Core.Services.Interfaces
{
    public interface ITeamService
    {
        public Task AddPlayerToTeamAsync(Guid playerId, Guid teamId);
    }
}
