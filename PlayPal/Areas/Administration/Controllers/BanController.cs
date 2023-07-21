using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
    public class BanController : PlayPalBaseController
    {
        private readonly IBanService _banService;

        public BanController(IBanService banService)
        {
            _banService = banService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var models = await _banService.GetAll();
                return View(models);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Ban(Guid playerId)
        {
            var model = new BanInputModel()
            {
                AdministratorId = Guid.Parse(User.Claims
                .First(c => c.Type == PlayPalClaimTypes.AdministratorId).Value),
                PlayerId = playerId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ban(BanInputModel model, string? returnUrl= null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                model.BannedTo = model.BannedTo.ToUniversalTime();

                await _banService.BanPlayer(model);

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("All", "Report", new {Area = "Administration" });
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBan(Guid id)
        {
            try
            {
                await _banService.RemoveBan(id);

                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
