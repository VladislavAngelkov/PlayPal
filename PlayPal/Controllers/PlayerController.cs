using Microsoft.AspNetCore.Mvc;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Data.Models.Enums;

namespace PlayPal.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IRepository _repository;

        public PlayerController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerInputModel model)
        {
            var player = new Player()
            {
                Name = model.Name,
                CurrentCity = model.City,
                Position = Enum.Parse<Position>(model.Position),
                UserId = model.Id
            };

            await _repository.AddAsync<Player>(player);

            return RedirectToAction("JoinGame", "Game");
        }
    }
}
