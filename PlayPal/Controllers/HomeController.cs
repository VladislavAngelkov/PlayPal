using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Models;
using System.Diagnostics;

namespace PlayPal.Controllers
{
    public class HomeController : PlayPalBaseController
    {
        private readonly IPlayerService _playerService;
        private readonly IBanService _banService;
        private readonly SignInManager<PlayPalUser> _signinManager;

        public HomeController(
            IPlayerService playerService,
            IBanService banService,
            SignInManager<PlayPalUser> signinManager)
        {
            _playerService = playerService;
            _banService = banService;
            _signinManager = signinManager;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                if (User.IsInRole(PlayPalRoleNames.Administrator))
                {
                    return RedirectToAction("Index", "Administrator", new { Area = "Administration" });
                }
                else if (User.IsInRole(PlayPalRoleNames.FieldOwner))
                {
                    return RedirectToAction("Mine", "Field", new { Area = "FieldManagment" });
                }
                else if (User.IsInRole(PlayPalRoleNames.Player))
                {
                    var playerId = Guid.Parse(User.Claims.First(c => c.Type == PlayPalClaimTypes.PlayerId).Value);

                    var player = await _playerService.GetPlayerAsync(playerId);

                    if (player != null)
                    {
                        var latestBan = await _banService.GetLatestBan(playerId);

                        if (latestBan != null && latestBan.BannedTo > DateTime.UtcNow)
                        {
                            await _signinManager.SignOutAsync();

                            return View("Banned", latestBan);
                        }
                    }

                    return RedirectToAction("JoinGame", "Game");
                }
                else
                {
                    return View();
                }
            }

            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}