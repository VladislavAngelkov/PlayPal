﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Controllers;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Extensions;

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
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
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

                    return RedirectToAction("All");
                }

                var models = await _gameService.GetGamesByFieldAsync(fieldId);

                return View(models);
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

                Guid administratorId = (Guid)User.AdministratorId()!;

                await _gameService.DeleteGameAsync(gameId, administratorId);

                return RedirectToAction("Games", new { fieldId = fieldId });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }
    }
}
