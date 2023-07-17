using PlayPal.Core.Models.InputModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IFieldOwnerService
    {
        public Task CreateFieldOwner(RegisterUserInputModel model);

        public Task DeleteFieldOwnerAsync(Guid? fieldOwnerId);
    }
}
