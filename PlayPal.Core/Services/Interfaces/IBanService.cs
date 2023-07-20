using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IBanService
    {
        public Task<BanViewModel> GetLatestBan(Guid playerId);

        public Task BanPlayer(BanInputModel model);
    }
}
