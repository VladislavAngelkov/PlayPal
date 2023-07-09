using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PlayPal.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class PlayPalBaseController : Controller
    {
    }
}
