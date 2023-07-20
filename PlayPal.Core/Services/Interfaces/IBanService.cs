using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IBanService
    {
        public Task<BanViewModel> GetLatestBan(Guid playerId);

        
    }
}
