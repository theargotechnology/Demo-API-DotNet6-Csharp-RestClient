
using RestApi.ServiceErrors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RestApi.Controllers;

[ApiController]
public class StationsController : ControllerBase //ApiController
{
    [HttpGet("/stations")]
    //public ErrorOr<IActionResult> GetStations()
    public IActionResult GetStations()
    {
        string message = "Test Message";
        /*
        if (message == "")
        {
            return Errors.Station.NotFound;
        }
        */
        return Ok(message);
    }
}
