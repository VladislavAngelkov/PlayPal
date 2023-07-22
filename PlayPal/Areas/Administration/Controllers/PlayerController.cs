using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
    public class PlayerController : PlayPalBaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult Search()
        {
            var model = new SearchPlayerInputModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchPlayerInputModel model)
        {
            string name = model.Name;
            string email = model.Email;
            string city = model.City;

            try
            {
                var players = await _playerService.SearchPlayer(name, email, city);

                model.Players = players;

                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
