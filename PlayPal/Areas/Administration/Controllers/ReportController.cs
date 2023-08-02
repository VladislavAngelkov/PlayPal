using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class ReportController : PlayPalBaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> All()
        {
            try
            {
                var models = await _reportService.All();

                return View(models);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpPost]
        [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
        public async Task<IActionResult> CheckReport(Guid reportId)
        {
            try
            {
                var exist =  _reportService.ReportExist(reportId);

                if (exist)
                {
                    await _reportService.CheckReport(reportId);
                }
                else
                {
                    TempData[ToastrMessageTypes.Error] = ErrorMessages.ReportDoesNotExist;
                }

                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }

        [HttpPost]
        [Authorize(Roles = PlayPalRoleNames.Player)]
        public async Task<IActionResult> ReportPlayer(ReportInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _reportService.ReportPlayer(model);

                return RedirectToAction("FillGameResult", "Game");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home", new { Area = "" });
            }
        }
    }
}
