using AutoMapper;
using Business.Abstracts.Product;
using Entity.IProductService;
using Entity.ProductController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}


		//Create
		[HttpPost()]
		public async Task<IActionResult> createProductAsync([FromBody] ProductControllerCreateProductAsyncRequest product)
		{
			IProductServiceCreateProductAsyncResponse productServiceResponse = await _productService.createProductAsync(_mapper.Map<IProductServiceCreateProductAsyncRequest>(product));
			ProductControllerCreateProductAsyncResponse productControllerResponse = _mapper.Map<ProductControllerCreateProductAsyncResponse>(productServiceResponse);
			return Ok(productControllerResponse);
		}
		//Read
		[HttpGet("{barcodeNumber}/{marketId:int}")]
		public async Task<IActionResult> getProductWithBarcodeNumberAndMarketIdAsync([FromRoute(Name = "barcodeNumber")] string barcodeNumber,[FromRoute(Name = "marketId")] int marketId)
		{
			IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse productServiceResponse = await _productService.getProductWithBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);
			ProductControllerGetProductWithBarcodeNumberAndMarketIdAsyncResponse productControllerResponse = _mapper.Map<ProductControllerGetProductWithBarcodeNumberAndMarketIdAsyncResponse>(productServiceResponse);
			return Ok(productControllerResponse);
		}





	}
}
