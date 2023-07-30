using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Extensions;
using System.Security.Cryptography.X509Certificates;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
    public class BanController : PlayPalBaseController
    {
        private readonly IBanService _banService;
        private readonly IReportService _reportService;

        public BanController(
            IBanService banService,
            IReportService reportService)
        {
            _banService = banService;
            _reportService = reportService;
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
        public async Task<IActionResult> Ban(Guid reportId)
        {
            var model = await _banService.GetBanInputModel(reportId);

            model.AdministratorId = (Guid)User.AdministratorId()!;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ban(BanInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _banService.BanPlayer(model);

                await _reportService.CheckReport(model.ReportId);

                return RedirectToAction("All", "Report", new {Area = "Administration"});
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
