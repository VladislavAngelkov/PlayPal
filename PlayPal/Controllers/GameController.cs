using Microsoft.AspNetCore.Mvc;

namespace PlayPal.Controllers
{
    public class GameController : PlayPalBaseController
    {
        public IActionResult JoinGame()
        {
            return View();
        }
    }
}
