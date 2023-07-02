using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class PositionService : IPositionService
    {
        private readonly IRepository _repository;

        public PositionService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<PositionViewModel>> GetAllPositionsModels()
        {
            var models = await _repository
                .All<Position>()
                .Select(p => new PositionViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();

            return models;
        }

        public async Task<Position> GetPositionByIdAsync(Guid id)
        {
            var position = await _repository.GetByIdAsync<Position>(id);

            return position;
        }
    }
}
