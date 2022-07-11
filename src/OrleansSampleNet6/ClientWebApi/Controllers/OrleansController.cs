using GrainInterface;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace WebApi.Controllers;

[ApiController]
public class OrleansController : ControllerBase
{
    private readonly IClusterClient _client;

    public OrleansController(IClusterClient client)
    {
        _client = client;
    }

    [HttpGet]
    [Route("sample")]
    public async Task<IActionResult> Get([FromQuery(Name = "gainname")] string grainName)
    {
        var grain = _client.GetGrain<ISample>(grainName);
        var response = await grain.Response($" This is 1 at {DateTime.Now}");
        return await Task.FromResult<IActionResult>(Ok(response));
    }
}