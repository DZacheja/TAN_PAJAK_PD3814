using ClientTripsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientTripsAPI.Controllers;
[Route("api/trips")]
[ApiController]
public class TripController : ControllerBase
{
    private readonly IDatabseService _databseService;

    public TripController(IDatabseService databseService)
    {
        _databseService = databseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips()
    {
        var data = await _databseService.GetTrips();
        return Ok(data);
    }

    [HttpDelete("{clientId}")]
    public async Task<IActionResult> DeleteClient(int clientId)
    {
        var data = await _databseService.DeleteClient(clientId);

        if (!data)
            return Conflict("Nie można usunąć kliejnta z aktywnymi wycieczkami");
        else
            return Ok("Usunięto pomyślnie osobę z id: " +clientId);
    }

}
