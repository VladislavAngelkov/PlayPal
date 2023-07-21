using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<ICollection<MessageViewModel>> AllAsync(Guid userId);

        public Task MarkAsSeenAsync(Guid id);

        public Task SendAsync(MessageInputModel model);

        public Task<ICollection<MessageViewModel>> GetSentMessagesAsync(Guid userId);

        public MessageViewModel GetMessage(Guid id);
    }
}
