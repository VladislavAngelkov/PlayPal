using Microsoft.AspNetCore.Mvc;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Data.Models.Enums;

namespace PlayPal.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> CreatePlayer(CreatePlayerInputModel model)
        {
           var playerId = await _service.CreatePlayerAsync(model);

            return RedirectToAction("JoinGame", "Game");
        }
    }
}
