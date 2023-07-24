using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository _repository;

        public MessageService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<MessageViewModel>> AllNewAdministrationAsync(Guid userId)
        {
            var models = await _repository.All<Message>()
                .Where(m => m.ReceiverId == null &&
                !m.Seen &&
                m.SenderId != userId)
                .Include(m => m.Sender)
                .Select(m => new MessageViewModel()
                {
                    Id = m.Id,
                    Sender = m.Sender.Email,
                    SenderId = m.SenderId,
                    Title = m.Title,
                    Content = m.Content
                })
                .ToListAsync();

            return models;
        }

        public async Task<ICollection<MessageViewModel>> AllOldAdministrationAsync(Guid userId)
        {
            var models = await _repository.All<Message>()
                .Where(m => m.ReceiverId == null &&
                m.Seen &&
                m.SenderId != userId)
                .Include(m => m.Sender)
                .Select(m => new MessageViewModel()
                {
                    Id = m.Id,
                    Sender = m.Sender.Email,
                    SenderId = m.SenderId,
                    Title = m.Title,
                    Content = m.Content
                })
                .ToListAsync();

            return models;
        }

        public async Task<ICollection<MessageViewModel>> AllNewAsync(Guid userId)
        {
            var models = await _repository.All<Message>()
                .Where(m => !m.Seen &&
                m.SenderId != userId &&
                m.ReceiverId == userId)
                .Include(m => m.Sender)
                .Select(m => new MessageViewModel()
                {
                    Id = m.Id,
                    Sender = m.Sender.Email,
                    SenderId = m.SenderId,
                    Title = m.Title,
                    Content = m.Content
                })
                .ToListAsync();

            return models;
        }

        public async Task<ICollection<MessageViewModel>> AllOldAsync(Guid userId)
        {
            var models = await _repository.All<Message>()
                .Where(m => m.Seen &&
                m.SenderId != userId &&
                m.ReceiverId == userId)
                .Include(m => m.Sender)
                .Select(m => new MessageViewModel()
                {
                    Id = m.Id,
                    Sender = m.Sender.Email,
                    SenderId = m.SenderId,
                    Title = m.Title,
                    Content = m.Content
                })
                .ToListAsync();

            return models;
        }

        public MessageViewModel GetMessage(Guid id)
        {
            var message = _repository.All<Message>()
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .FirstOrDefault(m => m.Id == id);

            var model = new MessageViewModel();

            if (message != null)
            {
                model.Id = id;
                model.SenderId = message.SenderId;
                model.Sender = message.Sender.Email;
                model.Title = message.Title;
                model.Content = message.Content;
            }

            return model;
        }

        public async Task<ICollection<MessageViewModel>> GetSentMessagesAsync(Guid userId)
        {
            var models = await _repository.All<Message>()
                .Where(m => m.SenderId == userId)
                .Include(m => m.Receiver)
                .Select(m => new MessageViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Content = m.Content,
                    Receiver = m.Receiver.Email
                })
                .ToListAsync();

            return models;
        }

        public async Task MarkAsSeenAsync(Guid id)
        {
            var message = await _repository.GetByIdAsync<Message>(id);

            message.Seen = true;

            await _repository.SaveChangesAsync();
        }

        public async Task SendAsync(MessageInputModel model)
        {
            var message = new Message()
            {
                Id = model.Id,
                SenderId = model.SenderId,
                ReceiverId = model.ReceiverId,
                Title = model.Title,
                Content = model.Content
            };

            await _repository.AddAsync(message);
        }
    }
}
