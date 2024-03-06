
using RestApi.ServiceErrors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System.Security.Principal;
using RestApi.Models;

namespace RestApi.Controllers;

[ApiController]
public class StationsController : ControllerBase //ApiController
{
    [HttpGet("/stations")]
    //public ErrorOr<IActionResult> GetStations()
    public IActionResult GetStations()
    {
        Console.WriteLine("UNIT TEST : Start : GetStations()");

        string message = "";

        // Relay Operation
        using (var client = new HttpClient())
        {
            try
            {
                // Trigger the GET request to call an API endpoint
                var response = client.GetAsync("https://environment.data.gov.uk/flood-monitoring/id/stations?parameter=rainfall&_limit=50").Result;

                // Read the response as a stream
                var responseStream = response.Content.ReadAsStreamAsync().Result;

                // Convert the stream to string
                StreamReader reader = new StreamReader(responseStream);

                // Transformer
                string text = reader.ReadToEnd();

                // Print out the JSON Response
                //Console.WriteLine("Response: " + text);
                message = text;

                // Relay Transformer
                StationList member = JsonConvert.DeserializeObject<StationList>(text);

                if (member == null)
                {
                    Console.WriteLine("Problem with json response");
                }
                else
                {
                    if (member.items.Length == 0)
                    {
                        Console.WriteLine("No Stations available");
                    }
                    else
                    {
                        // Print all stations with some info
                        Console.WriteLine("UNIT TEST - Start printing all stations with some info");
                        for (int i = 0; i < member.items.Length; i++)
                        {
                            Console.WriteLine("##");
                            Console.WriteLine(member.items[i].label);
                            Console.WriteLine(member.items[i].lat);
                            Console.WriteLine(member.items[i].stationReference);
                            Console.WriteLine("##");
                        }
                        Console.WriteLine("UNIT TEST - Stop printing all stations with some info");
                    }
                }
                // Relay Transformer
            }
            catch (Exception ex)
            {
                // If got problem with the rest call show here
                Console.WriteLine("Error: " + ex.Message);
                message = "empty";
                return Ok("Error: " + ex.Message + ", "+message);
            }
        }
        // Relay Operation

        Console.WriteLine("UNIT TEST : Stop : GetStations()");

        return Ok(message);
    }
}
