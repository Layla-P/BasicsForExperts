using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicsForExperts.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WaffleOrderController : ControllerBase
{
    private readonly IWaffleCreationService _waffleCreationService;
    private readonly ILogger<WaffleOrderController> _logger;

    public WaffleOrderController(ILogger<WaffleOrderController> logger, IEnumerable<IWaffleCreationService> waffleCreationServiceCollection)
    {
        _waffleCreationService = waffleCreationServiceCollection
            .FirstOrDefault(x=> x.GetType()==typeof(WaffleCreationService)) ?? throw new ArgumentNullException("WaffleCreationService"); ;

        _logger = logger;
            
    }

    [HttpGet]
    [Route("Options")]
    public async Task<JsonResult> Get()
    {
        var response = await _waffleCreationService.StartWaffleCreation();

        return new JsonResult(new { toppings = response.toppings, bases = response.bases });
    }

    [HttpPost]
    [Route("Options")]
    public void Post([FromBody] WaffleOrder waffleOrder)
    {
        
        //do stuff with the waffle order
    }
}
