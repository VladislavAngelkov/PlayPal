using PlayPal.Core.Models.InputModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IPlayerService
    {
        public Task CreatePlayer(CreatePlayerInputModel model);
    }
}
