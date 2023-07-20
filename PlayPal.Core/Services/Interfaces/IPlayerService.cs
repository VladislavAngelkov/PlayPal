using PlayPal.Core.Models.InputModels;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IPlayerService
    {
        public Task<Guid> CreatePlayerAsync(RegisterUserInputModel model);

        public Task DeletePlayerAsync(Guid? playerId);

        public Task<Player> GetPlayerAsync(Guid id);
    }
}
