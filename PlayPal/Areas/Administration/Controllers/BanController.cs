using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using System.Security.Cryptography.X509Certificates;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
    public class BanController : PlayPalBaseController
    {
        [HttpGet]
        public async Task<IActionResult> BanPlayer()
        {
            var model = new BanInputModel()
            {
                AdministratorId = Guid.Parse(User.Claims
                .First(c => c.Type == PlayPalClaimTypes.AdministratorId).Value)
            };

            return View();
        }
    }
}
