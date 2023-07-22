using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IPlayerService
    {
        public Task CreatePlayerAsync(RegisterUserInputModel model);

        public Task DeletePlayerAsync(Guid? playerId);

        public Task<Player> GetPlayerAsync(Guid id);

        public Task<ICollection<PlayerViewModel>> SearchPlayer(string name, string email, string city);
    }
}
