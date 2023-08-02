using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Extensions;

namespace PlayPal.Areas.FieldManagment.Controllers
{
    [Area("FieldManagment")]
    [Authorize(Policy = PlayPalPolicyNames.FieldManagment)]
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

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            Guid ownerId = (Guid)User.OwnerId()!;

            try
            {
                var models = await _fieldService.AllAsync(ownerId);

                return View(models);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new FieldInputModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FieldInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var ownerId = (Guid)User.OwnerId()!;

                model.OwnerId = ownerId!;

                await _fieldService.AddAsync(model);

                return RedirectToAction("Mine");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
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

                    return RedirectToAction("Mine");
                }

                Guid fieldOwnerId = (Guid)User.OwnerId()!;

                var field = await _fieldService.GetFieldAsync(fieldId);

                if (fieldOwnerId != field.OwnerId)
                {
                    TempData[ToastrMessageTypes.Warning] = WarningMessages.FieldNotOwnedByUser;

                    return RedirectToAction("Mine");
                }

                var model = await _gameService.GetGamesByFieldAsync(fieldId);

                TempData["Field"] = field.Name;

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid fieldId)
        {
            try
            {
                bool exist = await _fieldService.ExistAsync(fieldId);

                if (!exist)
                {

                    TempData[ToastrMessageTypes.Error] = ErrorMessages.FieldDoesNotExist;

                    return RedirectToAction("Mine");
                }

                Guid fieldOwnerId = (Guid)User.OwnerId()!;

                var field = await _fieldService.GetFieldAsync(fieldId);

                if (fieldOwnerId != field.OwnerId)
                {
                    TempData[ToastrMessageTypes.Warning] = WarningMessages.FieldNotOwnedByUser;

                    return RedirectToAction("Mine");
                }

                var gamesModel = await _gameService.GetGamesByFieldAsync(fieldId);

                foreach (var game in gamesModel.Games)
                {
                    await _gameService.DeleteGameAsync(game.Id, fieldOwnerId);
                }
                    
                await _fieldService.DeleteAsync(fieldId);

                return RedirectToAction("Mine");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
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

                Guid fieldOwnerId = (Guid)User.OwnerId()!;

                await _gameService.DeleteGameAsync(gameId, fieldOwnerId);

                return RedirectToAction("Games", new { fieldId = fieldId });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }
    }
}
