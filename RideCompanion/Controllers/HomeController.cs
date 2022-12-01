using System.Data;
using System.Diagnostics;
using FastReport.Utils;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.Models;

namespace RideCompanion.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static readonly string ReportsFolder = FindReportsFolder();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="reportIndex"></param>
    /// <returns></returns>
    [HttpGet("{reportIndex:int?}")]
    public IActionResult Index(int? reportIndex)
    {
        var model = new HomeModel()
        {
            WebReport = new WebReport(),
            ReportsList = new[]
            {
                "test"
            },
        };

        var reportToLoad = model.ReportsList[0];
        if (reportIndex >= 0 && reportIndex < model.ReportsList.Length)
            reportToLoad = model.ReportsList[reportIndex.Value];

        model.WebReport.Report.Load(Path.Combine(ReportsFolder, $"{reportToLoad}.frx"));

        var dataSet = new DataSet();
        dataSet.ReadXml(Path.Combine(ReportsFolder,"nwind.xml"));
        model.WebReport.Report.RegisterData(dataSet, "NorthWind");

        return View(model);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static string FindReportsFolder()
    {
        var fastReportsFolder = "";
        var thisFolder = Config.ApplicationFolder;

        for (var i = 0; i < 6; i++)
        {
            var dir = Path.Combine(thisFolder, "Reports");
            if (Directory.Exists(dir))
            {
                var reportDir = Path.GetFullPath(dir);
                if (System.IO.File.Exists(Path.Combine(reportDir, "reports.xml")))
                {
                    fastReportsFolder = reportDir;
                    break;
                }
            }
            thisFolder = Path.Combine(thisFolder, @"..");
        }
        return fastReportsFolder;
    }
}