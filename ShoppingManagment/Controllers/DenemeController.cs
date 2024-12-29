using Entity.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DenemeController : ControllerBase
	{
		[HttpGet()]
		public IActionResult Test()
		{
			throw new BadRequestException("hata");
			//return Ok("sucess");
		}
	}
}
