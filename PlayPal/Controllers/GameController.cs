using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Extensions;
using System.Security.Claims;

namespace PlayPal.Controllers
{
    [Authorize(Policy = PlayPalPolicyNames.Player)]
    public class GameController : PlayPalBaseController
    {
        private readonly IGameService _gameService;
        private readonly IFieldService _fieldService;
        private readonly IPlayerService _playerService;

        public GameController(
            IGameService gameService,
           IFieldService fieldService,
           IPlayerService playerService)
        {
            _gameService = gameService;
            _fieldService = fieldService;
            _playerService = playerService;
        }
            
        
        public IActionResult JoinGame()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateGame()
        {
            try
            {
                var city = User.FindFirstValue(PlayPalClaimTypes.City);

                var fields = await _fieldService.GetFieldsByCityAsync(city);

                var model = new GameInputModel();
                model.Fields = fields;

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame(GameInputModel model)
        {
            try
            {
                var city = User.FindFirstValue(PlayPalClaimTypes.City);

                var fields = await _fieldService.GetFieldsByCityAsync(city);

                if (!fields.Any(f => f.Id == model.FieldId))
                {
                    ModelState.AddModelError("", ErrorMessages.FieldDoesNotExist);
                }

                bool fieldIsAvailable = await _fieldService.CheckAvailabilityAsync(model.FieldId, model.StartingTime, model.EndingTime);

                if (!fieldIsAvailable)
                {
                    ModelState.AddModelError("", ErrorMessages.FieldIsNotAvalable);
                }

                bool playerIsAvailable = await _playerService.CheckAvailabilityAsync(model.CreatorId, model.StartingTime, model.EndingTime);
                
                if (!playerIsAvailable)
                {
                    ModelState.AddModelError("", ErrorMessages.PlayerIsNotAvailable);
                }

                if (!ModelState.IsValid)
                {
                    model.Fields = fields;
                    return View(model);
                }

                Guid creatorId = (Guid)User.PlayerId()!;

                model.CreatorId = creatorId;

                await _gameService.CreateGameAsync(model);

                return RedirectToAction("MyGames");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> MyGames()
        {
            try
            {
                Guid playerId = (Guid)User.PlayerId();

                var models = await _gameService.GetPlayerGamesAsync(playerId);

                return View(models);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
