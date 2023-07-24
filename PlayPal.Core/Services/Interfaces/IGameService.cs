using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IGameService
    {
        public Task DeleteAsync(Guid gameId);

        public Task<bool> ExistAsync(Guid gameId);

        public Task<FieldGameViewModel> GamesAsync(Guid fieldId);
    }
}
