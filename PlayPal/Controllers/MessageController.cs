using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using PlayPal.Common;
using PlayPal.Common.IdentityConstants;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Extensions;

namespace PlayPal.Controllers
{
    public class MessageController : PlayPalBaseController
    {
        private readonly IMessageService _messageService;

        public MessageController(
            IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> AllNew()
        {
            Guid userId = User.UserId();

            try
            {
                if (User.IsInRole(PlayPalRoleNames.FieldOwner))
                {
                    ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;
                   
                    var models = await _messageService.AllNewAsync(userId);

                    return View(models);
                }
                else if (User.IsInRole(PlayPalRoleNames.Administrator))
                {
                    ViewData["Layout"] = ApplicationConstants.AdministrationLayoutPath;

                    var models = await _messageService.AllNewAdministrationAsync(userId);

                    return View(models);
                }
                else
                {
                    var models = await _messageService.AllNewAsync(userId);

                    return View(models);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> AllOld()
        {
            Guid userId = User.UserId();

            try
            {
                if (User.IsInRole(PlayPalRoleNames.FieldOwner))
                {
                    ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;

                    var models = await _messageService.AllOldAsync(userId);

                    return View(models);
                }
                else if (User.IsInRole(PlayPalRoleNames.Administrator))
                {
                    ViewData["Layout"] = ApplicationConstants.AdministrationLayoutPath;

                    var models = await _messageService.AllOldAdministrationAsync(userId);

                    return View(models);
                }
                else
                {
                    var models = await _messageService.AllOldAsync(userId);

                    return View(models);
                }
            }
            catch (Exception) { return RedirectToAction("Error", "Home"); }
        }

        [HttpGet]
        public IActionResult Send(Guid? userId)
        {
            if (User.IsInRole(PlayPalRoleNames.FieldOwner))
            {
                ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;
            }
            else if (User.IsInRole(PlayPalRoleNames.Administrator))
            {
                ViewData["Layout"] = ApplicationConstants.AdministrationLayoutPath;
            }

            var model = new MessageInputModel();
            model.ReceiverId = userId;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Send(MessageInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                model.SenderId = User.UserId();

                await _messageService.SendAsync(model);

                if (User.IsInRole(PlayPalRoleNames.FieldOwner))
                {
                    ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;
                }
                else if (User.IsInRole(PlayPalRoleNames.Administrator))
                {
                    ViewData["Layout"] = ApplicationConstants.AdministrationLayoutPath;
                }

                return RedirectToAction("Sent");
            }
            catch(Exception) { return RedirectToAction("Error", "Home"); }
        }

        [HttpGet]
        public async Task<IActionResult> Sent()
        {
            var userId = User.UserId();

            try
            {
                if (User.IsInRole(PlayPalRoleNames.FieldOwner))
                {
                    ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;
                }
                else if (User.IsInRole(PlayPalRoleNames.Administrator))
                {
                    ViewData["Layout"] = ApplicationConstants.AdministrationLayoutPath;
                }

                var models = await _messageService.GetSentMessagesAsync(userId);

                return View(models);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        [HttpPost]
        public async Task<IActionResult> MarkAsSeen(Guid id)
        {
            try
            {
                await _messageService.MarkAsSeenAsync(id);

                if (User.IsInRole(PlayPalRoleNames.FieldOwner))
                {
                    ViewData["Layout"] = ApplicationConstants.FieldManagmentLayoutPath;
                }
                else if (User.IsInRole(PlayPalRoleNames.Administrator))
                {
                    ViewData["Layout"] = ApplicationConstants.AdministrationLayoutPath;
                }

                return RedirectToAction("AllNew");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Reply(Guid userId, Guid messageId)
        {
            try
            {
                await _messageService.MarkAsSeenAsync(messageId);

                return RedirectToAction("Send", new { userId = userId });
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
