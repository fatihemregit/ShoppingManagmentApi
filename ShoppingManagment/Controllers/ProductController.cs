using AutoMapper;
using Business.Abstracts.Product;
using Entity.IProductService;
using Entity.ProductController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ShoppingManagment.Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[EnableRateLimiting(policyName: "productController")]
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
		//Update
		[HttpPut()]
		public async Task<IActionResult> updateProductAsync([FromBody] ProductControllerUpdateProductAsyncRequest product)
		{
			IProductServiceUpdateProductAsyncResponse productServiceResponse = await _productService.updateProductAsync(_mapper.Map<IProductServiceUpdateProductAsyncRequest>(product));
			ProductControllerUpdateProductAsyncResponse productControllerResponse = _mapper.Map<ProductControllerUpdateProductAsyncResponse>(productServiceResponse);
			return Ok(productControllerResponse);
		}
		//Delete
		[HttpDelete("{id}")]
		public async Task<IActionResult> deleteProductAsync(string id)
		{ 
			bool productServiceResponse = await _productService.deleteProductAsync(id);
			bool productControllerResponse = productServiceResponse;
			return Ok(productControllerResponse);
		}

		[HttpGet("rateTest")]
		public IActionResult rateTest()
		{
			return Ok();
		}



	}
}
