using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Controllers;
using PlayPal.Core.Services.Interfaces;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
    public class FieldController : PlayPalBaseController
    {
        private readonly IFieldService _fieldService;
        private readonly IGameService _gameService;

        public FieldController(
            IFieldService fieldService,
            IGameService gameService)
        {
            _fieldService = fieldService;
            _gameService = gameService;
        }

        public async Task<IActionResult> All()
        {
            try
            {

                var models = await _fieldService.AllAsync();

                return View(models);    
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> Delete(Guid fieldId)
        {
            try
            {
                bool exist = await _fieldService.ExistAsync(fieldId);

                if (!exist)
                {
                    TempData[ToastrMessageTypes.Error] = ErrorMessages.FieldDoesNotExist;

                    return RedirectToAction("All");
                }

                await _fieldService.DeleteAsync(fieldId);

                return RedirectToAction("All");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Games(Guid fieldId)
        {
            try
            {
                bool exist = await _fieldService.ExistAsync(fieldId);

                if (!exist)
                {

                    TempData[ToastrMessageTypes.Error] = ErrorMessages.FieldDoesNotExist;

                    return RedirectToAction("All");
                }

                var models = await _gameService.GamesAsync(fieldId);

                return View(models);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGame(Guid gameId, Guid fieldId)
        {
            try
            {
                bool exist = await _gameService.ExistAsync(gameId);

                if (!exist)
                {
                    TempData[ToastrMessageTypes.Error] = ErrorMessages.GameDoesNotExist;

                    return RedirectToAction("Games", new { fieldId = fieldId });
                }

                await _gameService.DeleteAsync(gameId);

                return RedirectToAction("Games", new { fieldId = fieldId });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
