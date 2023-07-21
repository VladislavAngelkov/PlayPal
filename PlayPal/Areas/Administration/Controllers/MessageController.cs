using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlayPal.Common.IdentityConstants;
using PlayPal.Controllers;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using System.Security.Claims;

namespace PlayPal.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Policy = PlayPalPolicyNames.Adminstration)]
    public class MessageController : PlayPalBaseController
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<PlayPalUser> _userManager;

        public MessageController(
            IMessageService messageService,
            UserManager<PlayPalUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                var models = await _messageService.AllAsync(userId);

                return View(models);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsSeen(Guid id)
        {
            try
            {
                await _messageService.MarkAsSeenAsync(id);

                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Reply(Guid messageId)
        {
            try
            {
                await _messageService.MarkAsSeenAsync(messageId);

                var message = _messageService.GetMessage(messageId);

                return RedirectToAction("Send", new { receiverId = message.SenderId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Send(Guid receiverId)
        {
            var model = new MessageInputModel();
            model.ReceiverId = receiverId;

            var user = _userManager.Users.FirstOrDefault(u => u.Id == receiverId);

            if (user == null)
            {
                return RedirectToAction("Error", "Home");
            }

            model.Receiver = user.Email;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Send(MessageInputModel model)
        {
            model.SenderId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                await _messageService.SendAsync(model);

                return RedirectToAction("Sent");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Sent()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                var models = await _messageService.GetSentMessagesAsync(userId);

                return View(models);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
