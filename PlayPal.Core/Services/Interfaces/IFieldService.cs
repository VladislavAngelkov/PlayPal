using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using System.Reflection;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IFieldService
    {
        public Task<ICollection<AdministrationFieldViewModel>> AllAsync();

        public Task DeleteAsync(Guid fieldId);

        public Task<bool> Exist(Guid fieldId);

        public Task<ICollection<FieldViewModel>> GetFieldsByOwnerAsync(Guid ownerId);

        public Task AddAsync(FieldInputModel model);

    }
}
