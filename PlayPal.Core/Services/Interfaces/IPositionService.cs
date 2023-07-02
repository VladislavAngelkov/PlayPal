using PlayPal.Core.Models.ViewModels;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IPositionService
    {
        public Task<ICollection<PositionViewModel>> GetAllPositionsModels();

        public Task<Position> GetPositionByIdAsync(Guid id);
    }
}
