using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Models;
using System.Diagnostics;

namespace PlayPal.Controllers
{
    public class HomeController : PlayPalBaseController
    {
        [AllowAnonymous]
        public IActionResult Index()
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