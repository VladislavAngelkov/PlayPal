using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Extensions;

namespace PlayPal.Controllers
{
    [Authorize(Policy = PlayPalPolicyNames.Player)]
    public class ReportController : PlayPalBaseController
    {
        private readonly IReportService _reportService;

        public ReportController(
            IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult Add(Guid reportedId, string returnUrl, Guid gameId)
        {
            Guid playerId = (Guid)User.PlayerId()!;

            var model = new ReportInputModel()
            {
                ReportingPlayerId = playerId,
                ReportedPlayerId = reportedId,
                ReturnUrl = $"{returnUrl}?gameId={gameId.ToString()}"
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ReportInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                _reportService.ReportPlayer(model);
                
                return LocalRedirect(model.ReturnUrl);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
