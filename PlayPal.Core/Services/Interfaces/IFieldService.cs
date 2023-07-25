using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Data.Models;
using System.Reflection;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IFieldService
    {
        public Task<ICollection<FieldViewModel>> AllAsync(Guid? fieldOwnerId = null);

        public Task DeleteAsync(Guid fieldId);

        public Task<bool> ExistAsync(Guid fieldId);

        public Task AddAsync(FieldInputModel model);

        public Task<Field> GetFieldAsync(Guid fieldId);

        public Task<ICollection<FieldViewModel>> GetFieldsByCityAsync(string city);

        public Task<bool> CheckAvailabilityAsync(Guid fieldId, DateTime startingTime, DateTime endingTime);

    }
}
