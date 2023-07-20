using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;
using PlayPal.Data.Models.Enums;

namespace PlayPal.Core.Services
{
    public class BanService : IBanService
    {
        private readonly IRepository _repository;

        public BanService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task BanPlayer(BanInputModel model)
        {
            var ban = new Ban()
            {
                Id = model.Id,
                PlayerId = model.PlayerId,
                AdministratorId = model.AdministratorId,
                BannedTo = model.BannedTo,
                Reason = Enum.Parse<Reason>(model.Reason)
            };

            await _repository.AddAsync(ban);
            await _repository.SaveChangesAsync();
        }

        public async Task<BanViewModel> GetLatestBan(Guid playerId)
        {
            var player = await _repository
                .All<Player>(p => p.Id == playerId)
                .Include(p => p.Bans)
                .FirstAsync();
                
            var ban = player.Bans
                .OrderByDescending(b => b.BannedTo)
                .FirstOrDefault();

            string reason = string.Empty;

            if (ban != null)
            {
                if (ban.Reason == Reason.DangerousPlay)
                {
                    reason = "You have played dangerously in previous games";
                }
                else if (ban.Reason == Reason.Insults)
                {
                    reason = "You have insulted other players in previous games";
                }
                else
                {
                    reason = "You have skipped or leaved games before they have ended";
                }
            }

            var model = new BanViewModel()
            {
                BannedTo = ban.BannedTo,
                Reason = reason
            };

            return model;
        }
    }
}
