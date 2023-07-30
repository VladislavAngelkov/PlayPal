using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Controllers
{
    [Authorize(Policy = PlayPalPolicyNames.Player)]
    public class GoalController : PlayPalBaseController
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid gameId)
        {
            var model = await _goalService.GetGoalInputModel(gameId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GoalInputModel model)
        {
            try
            {
                await _goalService.Add(model);

                return RedirectToAction("ProcessGame", "Game", new { gameId = model.GameId });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
