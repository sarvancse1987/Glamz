using Glamz.Business.Common.Utilities;
using System;
using System.Threading.Tasks;

namespace Glamz.Business.Common.Interfaces.Directory
{
    public partial interface IGoogleAnalyticsService
    {
        Task<GoogleAnalyticsResult> GetDataByGeneral(DateTime startDate, DateTime endDate);
        Task<GoogleAnalyticsResult> GetDataByLocalization(DateTime startDate, DateTime endDate);
        Task<GoogleAnalyticsResult> GetDataBySource(DateTime startDate, DateTime endDate);
        Task<GoogleAnalyticsResult> GetDataByExit(DateTime startDate, DateTime endDate);
        Task<GoogleAnalyticsResult> GetDataByDevice(DateTime startDate, DateTime endDate);
    }
}
