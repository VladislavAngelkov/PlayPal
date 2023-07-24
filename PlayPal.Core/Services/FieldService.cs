using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class FieldService : IFieldService
    {
        private readonly IRepository _repository;

        public FieldService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(FieldInputModel model)
        {
            var field = new Field()
            {
                Id = model.Id,
                Name = model.Name,
                City = model.City,
                Address = model.Address,
                OwnerId = model.OwnerId
            };

            await _repository.AddAsync(field);
        }

        public async Task<ICollection<FieldViewModel>> AllAsync(Guid? fieldOwnerId = null)
        {

            var models = new List<FieldViewModel>();

            if (fieldOwnerId == null)
            {
                models = await _repository.All<Field>()
                .Include(f => f.Owner)
                .Select(f => new FieldViewModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    City = f.City,
                    Address = f.Address,
                    Owner = $"{f.Owner.Title} {f.Owner.FirstName} {f.Owner.LastName}"
                })
                .ToListAsync();
            }
            else
            {
                fieldOwnerId = (Guid)fieldOwnerId;

                models = await _repository.All<Field>()
                .Include(f => f.Owner)
                .Where(f => f.OwnerId == fieldOwnerId)
                .Select(f => new FieldViewModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    City = f.City,
                    Address = f.Address,
                    Owner = $"{f.Owner.Title} {f.Owner.FirstName} {f.Owner.LastName}"
                })
                .ToListAsync();
            }

            return models;
        }

        public async Task DeleteAsync(Guid fieldId)
        {
            await _repository.DeleteAsync<Field>(fieldId);
        }

        public async Task<bool> ExistAsync(Guid fieldId)
        {
            var field = await _repository.GetByIdAsync<Field>(fieldId);

            if (field == null || field.IsDeleted)
            {
                return false;
            }

            return true;    
        }

        public Task<Field> GetFieldAsync(Guid fieldId)
        {
            var field = _repository.GetByIdAsync<Field>(fieldId);

            return field;
        }

    }
}
