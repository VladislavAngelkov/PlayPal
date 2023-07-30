using PlayPal.Core.Models.InputModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IGoalService
    {
        public Task<int> GetHomeTeamGoalCount(Guid gameId);

        public Task<int> GetAwayTeamGoalCount(Guid gameId);

        public Task<GoalInputModel> GetGoalInputModel(Guid gameId);

        public Task Add(GoalInputModel model);
    }
}
