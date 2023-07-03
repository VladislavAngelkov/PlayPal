using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services.Interfaces;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly IAdministratorService _administratorService;

        public AdministratorController(
            IAdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpGet]
        public async Task<IActionResult> Promote()
        {
            var appliedForAdministratorUsers = await _administratorService.GetAdministratorApplicationsAsync();

            return View(appliedForAdministratorUsers);
        }

        [HttpPost]
        public async Task<IActionResult> Promote(string email, Guid administratorId)
        {
            var appliedForAdministratorUsers = await _administratorService.GetAdministratorApplicationsAsync();

            if (appliedForAdministratorUsers.Any(u => u.Email == email  && u.AdministratorId  == administratorId))
            {
                await _administratorService.PromoteUserToAdministrator(email, administratorId);
            }

            return RedirectToAction("Promote");
        }
    }
}
