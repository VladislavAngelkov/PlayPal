using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Data.Models.Enums;

namespace PlayPal.Core.Services
{
    public class FieldOwnerService : IFieldOwnerService
    {
        private readonly IRepository _repository;

        public FieldOwnerService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateFieldOwner(RegisterUserInputModel model)
        {
            var fieldOwner = new FieldOwner()
            {
                Id = model.FieldOwner!.Id,
                Title = Enum.Parse<Title>(model.FieldOwner.Title),
                FirstName = model.FieldOwner.FirstName,
                LastName = model.FieldOwner.LastName,
                CompanyName = model.FieldOwner.CompanyName,
                ContactAddress = model.FieldOwner.ContactAddres,
                UserId = model.Id
            };

            await _repository.AddAsync<FieldOwner>(fieldOwner);
        }

        public async Task DeleteFieldOwnerAsync(Guid? fieldOwnerId)
        {
            if (fieldOwnerId != null)
            {
                var fieldOwner = await _repository.GetByIdAsync<FieldOwner>((Guid)fieldOwnerId);

                if (fieldOwner != null)
                {
                    fieldOwner.UserId = null;
                    fieldOwner.User = null;
                    await _repository.DeleteAsync<FieldOwner>((Guid)fieldOwnerId);
                    await _repository.SaveChangesAsync();
                }
            }
        }
    }
}
