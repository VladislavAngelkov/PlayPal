using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<ICollection<MessageViewModel>> AllNewAdministrationAsync(Guid userId);

        public Task<ICollection<MessageViewModel>> AllOldAdministrationAsync(Guid userId);

        public Task MarkAsSeenAsync(Guid id);

        public Task SendAsync(MessageInputModel model);

        public Task<ICollection<MessageViewModel>> GetSentMessagesAsync(Guid userId);

        public MessageViewModel GetMessage(Guid id);

        public Task<ICollection<MessageViewModel>> AllNewAsync(Guid userId);

        public Task<ICollection<MessageViewModel>> AllOldAsync(Guid userId);
    }
}
