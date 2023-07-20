using PlayPal.Core.Models.InputModels;
using PlayPal.Core.Models.ViewModels;

namespace PlayPal.Core.Services.Interfaces
{
    public interface IReportService
    {
        public Task<ICollection<ReportViewModel>> All();

        public bool ReportExist(Guid reportId);

        public Task CheckReport(Guid reportId);

        public Task ReportPlayer(ReportInputModel model);
    }
}
