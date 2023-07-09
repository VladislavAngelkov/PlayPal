using Microsoft.AspNetCore.Mvc;
using PlayPal.Controllers;

namespace PlayPal.Areas.FieldManagment.Controllers
{
    public class FieldController : PlayPalBaseController
    {
        public IActionResult Mine()
        {
            return View();
        }
    }
}
