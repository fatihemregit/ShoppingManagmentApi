using AutoMapper;
using Data;
using Data.Abstracts.Order;
using Entity.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DenemeController : ControllerBase
	{

		private readonly IMapper _mapper;

		public DenemeController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet("custom")]
		public IActionResult customBadRequestTest()
		{
			throw new NotFoundException("hata");
		}


		[HttpGet("normal")]
		public IActionResult normalbadrequesttest()
		{
			return NotFound();
		}

	}
}
