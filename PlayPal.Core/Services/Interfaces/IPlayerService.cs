﻿using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IPlayerService
    {
        public Task CreatePlayerAsync(RegisterUserInputModel model);

        public Task DeletePlayerAsync(Guid? playerId);

        public Task<Player> GetPlayerAsync(Guid id);

        public Task<ICollection<PlayerViewModel>> SearchPlayer(string name, string email, string city);

        public Task UpdatePlayer(EditPlayerProfileInputModel model, Guid userId);

        public Task<bool> CheckAvailabilityAsync(Guid playerId, DateTime startingTime, DateTime endingTime);

        public Task<PlayerProfileViewModel> GetPlayerProfileViewModelAsync(Guid playerId);

        public Task<EditPlayerProfileInputModel> GetEditPlayerProfileInputModelAsync(Guid playerId, string email);
    }
}
