﻿using PlayPal.Core.Models.InputModels;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IFieldOwnerService
    {
        public Task CreateFieldOwner(RegisterUserInputModel model);

        public Task DeleteFieldOwnerAsync(Guid? fieldOwnerId);

        public Task<FieldOwner> GetFieldOwnerAsync(Guid fieldOwnerId);

        public Task UpdateFieldOwnerAsync(EditFieldOwnerProfileInputModel model, Guid userId);
    }
}
