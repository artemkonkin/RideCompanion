using FastReport.Web;

namespace RideCompanion.Models;

public class HomeModel
{
    public WebReport WebReport { get; set; }
    public string[] ReportsList { get; set; }
}