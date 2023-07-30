using Microsoft.EntityFrameworkCore;
using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;
using PlayPal.Core.Repositories.Interfaces;
using PlayPal.Core.Services.Interfaces;
using PlayPal.Data.Models;

namespace PlayPal.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository _repository;

        public ReportService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ReportViewModel>> All()
        {
            var models = await _repository.All<Report>(r => !r.IsChecked && !r.IsDeleted)
                .Include(r => r.ReportedPlayer.User)
                .Include(r => r.ReportingPlayer.User)
                .Select(r => new ReportViewModel()
                {
                    Id = r.Id,
                    ReportedPlayerId = r.ReportedPlayerId,
                    ReportingPlayerId = r.ReportingPlayerId,
                    ReportedPlayer = r.ReportedPlayer.User!.Email,
                    ReportingPlayer = r.ReportingPlayer.User!.Email,
                    Reason = r.Reason.ToString()
                })
                .ToListAsync();

            return models;
        }

        public async Task CheckReport(Guid reportId)
        {
            var report = await _repository.GetByIdAsync<Report>(reportId);

            report.IsChecked = true;

            await _repository.SaveChangesAsync();
        }

        public bool ReportExist(Guid reportId)
        {
            return _repository.All<Report>().Any(r => r.Id == reportId);
        }

        public bool IsAlreadyReported(Guid reportingId, Guid reportedId)
        {
            return _repository.All<Report>()
                .Any(r => r.ReportingPlayerId == reportingId &&
                r.ReportedPlayerId == reportedId &&
                !r.IsChecked);
        }

        public async Task ReportPlayer(ReportInputModel model)
        {
            if (IsAlreadyReported(model.ReportingPlayerId, model.ReportedPlayerId))
            {
                return;
            }

            var report = new Report()
            {
                Id = model.Id,
                ReportedPlayerId = model.ReportedPlayerId,
                ReportingPlayerId = model.ReportingPlayerId,
                Reason = model.Reason,
                IsChecked = false
            };

            await _repository.AddAsync<Report>(report);
            await _repository.SaveChangesAsync();
        }

    }
}
