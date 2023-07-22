using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IFieldService
    {
        public Task<ICollection<AdministrationFieldViewModel>> AllAsync();

        public Task DeleteAsync(Guid fieldId);

        public Task<bool> Exist(Guid fieldId);

    }
}
