using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/gwp")]
[ApiController]
public class CountryGwpController : ControllerBase
{
	private readonly IGwpService _gwpService;

	public CountryGwpController(IGwpService gwpService)
	{
		_gwpService = gwpService;
	}

	[HttpPost("avg")]
	public async Task<IActionResult> GetAverageGwp([FromBody] GwpRequest request)
	{
		try
		{
			var result = await _gwpService.GetAverageGwp(request);
			return Ok(result);
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal server error: {ex.Message}");
		}
	}
}
