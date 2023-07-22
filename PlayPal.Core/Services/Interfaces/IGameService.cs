using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IGameService
    {
        public Task Delete(Guid gameId);

        public Task<bool> Exist(Guid gameId);

        public Task<FieldGameViewModel> Games(Guid fieldId);
    }
}
