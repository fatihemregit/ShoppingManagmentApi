using AutoMapper;
using Business.Abstracts.Order;
using Data;
using Data.Abstracts.Order;
using Entity.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace ShoppingManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DenemeController : ControllerBase
	{

		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;
		private readonly ILogger<DenemeController> _logger;

		public DenemeController(IMapper mapper, IConfiguration configuration, ILogger<DenemeController> logger)
		{
			_mapper = mapper;
			_configuration = configuration;
			_logger = logger;
		}

		[HttpGet("custom")]
		public IActionResult customBadRequestTest()
		{
			throw new NotFoundException("hata");
		}

		[HttpGet("logTest")]
		public IActionResult logTest()
		{
			_logger.LogInformation("sucess");
			return Ok();
		}


		[HttpGet("normal")]
		public IActionResult normalbadrequesttest()
		{
			return NotFound();
		}

		//[HttpPost]
		//public async Task<IActionResult> orderTest([FromServices]IOrderService order)
		//{
		//	await order.createOrderAsync(new List<string>() { "1","2","3"});
		//	return Ok();
		//}

		[HttpGet("data")]
		public IActionResult data()
		{
			var data = _configuration.GetSection("veri");

			Console.WriteLine();
			return Ok();
		}


		[Authorize(AuthenticationSchemes = "Bearer")]
		[HttpGet("authTest")]
		public IActionResult authTest()
		{ 
			return Ok();
		}

	}
}
