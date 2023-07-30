using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IGameService
    {
        public Task<bool> ExistAsync(Guid gameId);

        public Task<FieldGameViewModel> GetGamesByFieldAsync(Guid fieldId);

        public Task<ICollection<GameViewModel>> GetGamesByCityAsync(string city, Guid playerId);

        public Task CreateGameAsync(GameInputModel model);

        public Task<ICollection<GameViewModel>> GetPlayerGamesAsync(Guid playerId);

        public Task<GameDetailViewModel> GetGameModelAsync(Guid gameId);

        public Task JoinPlayerToGame(Guid playerId, Guid gameId);

        public Task LeaveGame(Guid gameId, Guid playerId);

        public Task AddToHomeTeam(Guid gameId, Guid playerId);

        public Task AddToAwayTeam(Guid gameId, Guid playerId);


        public Task DeleteGameAsync
            (Guid gameId, Guid playerId);

        public Task<ICollection<OldGameViewModel>> GetOldGames(Guid playerId);

        public Task<ProcessGameViewModel> GetProcesGameViewModel(Guid gameId);

        public Task ProcessGame(Guid gameId);
    }
}
