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

        [HttpGet]
        public async Task<IActionResult> JoinGame()
        {
            try
            {
                var city = User.FindFirstValue(PlayPalClaimTypes.City);

                var playerId = (Guid)User.PlayerId()!;

                var models = await _gameService.GetGamesByCityAsync(city, playerId);

                return View(models);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> JoinGame(Guid gameId)
        {
            try
            {
                var playerId = (Guid)User.PlayerId()!;

                await _gameService.JoinPlayerToGame(playerId, gameId);

                return RedirectToAction("MyGames");
            }
            catch (Exception ex)
            {

                throw;
            }
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
                Guid playerId = (Guid)User.PlayerId()!;

                var models = await _gameService.GetPlayerGamesAsync(playerId);

                return View(models);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid gameId)
        {
            var model = await _gameService.GetGameModelAsync(gameId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveGame(Guid gameId)
        {
            try
            {
                Guid playerId = (Guid)User.PlayerId()!;

                await _gameService.LeaveGame(gameId, (Guid)playerId);

                return RedirectToAction("MyGames");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Manage(Guid gameId)
        {
            var model = await _gameService.GetGameModelAsync(gameId);

            var playerId = (Guid)User.PlayerId()!;

            if (model.CreatorId != playerId)
            {
                TempData[ToastrMessageTypes.Warning] = WarningMessages.UserNotACreator;

                return RedirectToAction("Details", gameId);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToHomeTeam(Guid gameId, Guid playerId)
        {
            try
            {
                await _gameService.AddToHomeTeam(gameId, playerId);

                return RedirectToAction("Manage", new { gameId = gameId });
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddToAwayTeam(Guid gameId, Guid playerId)
        {
            try
            {
                await _gameService.AddToAwayTeam(gameId, playerId);

                return RedirectToAction("Manage", new { gameId = gameId });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeTeam(Guid gameId, Guid playerId)
        {
            try
            {
                var game = await _gameService.GetGameModelAsync(gameId);

                if (game == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                if (game.HomeTeam.Any(p => p.Id == playerId))
                {
                    await _gameService.AddToAwayTeam(gameId, playerId);
                }

                if (game.AwayTeam.Any(p => p.Id == playerId))
                {
                    await _gameService.AddToHomeTeam(gameId, playerId);
                }

                return RedirectToAction("Manage", new { gameId = gameId });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemovePlayer(Guid gameId, Guid playerId)
        {
            try
            {

                await _gameService.LeaveGame(gameId, playerId);

                return RedirectToAction("Manage", new { gameId = gameId });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGame(Guid gameId)
        {
            try
            {
                Guid playerId = (Guid)User.PlayerId()!;

                await _gameService.DeleteGameAsync(gameId, playerId);

                return RedirectToAction("MyGames");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> OldGames()
        {
            var playerId = (Guid)User.PlayerId()!;

            try
            {
                var models = await _gameService.GetOldGames(playerId);

                return View(models);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ProcessGame(Guid gameId)
        {
            try
            {
                Guid playerId = (Guid)User.PlayerId()!;

                var model = await _gameService.GetProcesGameViewModel(gameId);

                if (model.CreatorId != playerId)
                {
                    TempData[ToastrMessageTypes.Error] = ErrorMessages.PlayerNotCreatorOfGame;

                    return RedirectToAction("OldGames");
                }

                if (model.IsProcessed)
                {
                    TempData[ToastrMessageTypes.Error] = ErrorMessages.GameIsAlreadyProcessed;

                    return RedirectToAction("OldGames");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> FinishGame(Guid gameId)
        {
            try
            {
                await _gameService.ProcessGame(gameId);

                return RedirectToAction("OldGames");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ViewOldGame(Guid gameId)
        {
            try
            {
                var model = await _gameService.GetProcesGameViewModel(gameId);

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
