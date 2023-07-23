using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Common.Notifications;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Extensions;

namespace PlayPal.Areas.FieldManagment.Controllers
{
    [Area("FieldManagment")]
    [Authorize(Policy = PlayPalPolicyNames.FieldManagment)]
    public class FieldController : PlayPalBaseController
    {
        private readonly IFieldService _fieldService;

        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var ownerId = User.OwnerId();

            if (ownerId == null)
            {
                return View(new List<FieldViewModel>());
            }

            var models = await _fieldService.GetFieldsByOwnerAsync((Guid)ownerId);

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new FieldInputModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FieldInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var ownerId = User.OwnerId();

                model.OwnerId = (Guid)ownerId!;

                await _fieldService.AddAsync(model);

                return RedirectToAction("Mine");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
