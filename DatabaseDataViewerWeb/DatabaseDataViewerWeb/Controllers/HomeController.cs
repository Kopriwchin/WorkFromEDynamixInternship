using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatabaseDataViewerWeb.Models;
using DatabaseDataViewerWeb.Data;

namespace DatabaseDataViewerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IISFailedRequestDbContext _dbContext;
        public HomeController(IISFailedRequestDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var logs = _dbContext.T_fal_req_log
                .Select(x => new t_fal_req_log
                {
                    Id = x.Id,
                    Url = x.Url,
                    AppPoolId = x.AppPoolId,
                    SiteId = x.SiteId,
                    ProcessId = x.ProcessId,
                    Verb = x.Verb,
                    TokenUserName = x.TokenUserName,
                    AuthenticationType = x.AuthenticationType,
                    ActivityId = x.ActivityId,
                    FailureReason = x.FailureReason,
                    ReasonDescription = x.ReasonDescription,
                    StatusCode = x.StatusCode,
                    TriggerStatusCode = x.TriggerStatusCode,
                    TimeTaken = x.TimeTaken,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    ServerName = x.ServerName
                })
                .AsQueryable();

            var list = typeof(t_fal_req_log)
                .GetProperties()
                .Select(x => x.Name)
                .ToList();

            ViewBag.Titles = list;
            return View(await PaginatedList<t_fal_req_log>.CreateAsync(logs, pageNumber, 4));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
