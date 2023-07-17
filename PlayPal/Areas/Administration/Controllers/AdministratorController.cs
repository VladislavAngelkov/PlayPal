using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Controllers;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services.Interfaces;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : PlayPalBaseController
    {
        private readonly IAdministratorService _administratorService;

        public AdministratorController(
            IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.HasClaim(c => c.Type == PlayPalClaimTypes.AdministratorId))
            {
                return RedirectToAction("Promote");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> Promote()
        {
            var appliedForAdministratorUsers = await _administratorService.GetAdministratorRequestsAsync();

            return View(appliedForAdministratorUsers);
        }

        [HttpPost]
        public async Task<IActionResult> Promote(string email, Guid administratorId)
        {
            var appliedForAdministratorUsers = await _administratorService.GetAdministratorRequestsAsync();

            if (appliedForAdministratorUsers.Any(u => u.Email == email  && u.AdministratorId  == administratorId))
            {
                await _administratorService.PromoteUserToAdministrator(email, administratorId);
            }

            return RedirectToAction("Promote");
        }
    }
}
