using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
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
            var ownerId = User.OwnerId();

            if (ownerId == null)
            {
                return View(new List<FieldViewModel>());
            }

            var models = await _fieldService.AllAsync((Guid)ownerId);

            return View(models);
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
                var ownerId = User.OwnerId();

                model.OwnerId = (Guid)ownerId!;

                await _fieldService.AddAsync(model);

                return RedirectToAction("Mine");
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

                    return RedirectToAction("Mine");
                }

                Guid? fieldOwnerId = User.OwnerId()!;

                var field = await _fieldService.GetFieldAsync(fieldId);

                if (fieldOwnerId != field.OwnerId)
                {
                    TempData[ToastrMessageTypes.Warning] = WarningMessages.FieldNotOwnedByUser;

                    return RedirectToAction("Mine");
                }

                var model = await _gameService.GamesAsync(fieldId);

                TempData["Field"] = field.Name;

                return View(model);
            }
            catch (Exception)
            {

                throw;
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

                Guid? fieldOwnerId = User.OwnerId()!;

                var field = await _fieldService.GetFieldAsync(fieldId);

                if (fieldOwnerId != field.OwnerId)
                {
                    TempData[ToastrMessageTypes.Warning] = WarningMessages.FieldNotOwnedByUser;

                    return RedirectToAction("Mine");
                }

                await _fieldService.DeleteAsync(fieldId);

                return RedirectToAction("Mine");
            }
            catch (Exception ex)
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

                Guid? fieldOwnerId = User.OwnerId()!;

                if (fieldOwnerId != fieldId)
                {
                    TempData[ToastrMessageTypes.Warning] = WarningMessages.FieldNotOwnedByUser;

                    return RedirectToAction("Mine");
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
