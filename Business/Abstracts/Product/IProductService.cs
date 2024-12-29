using Entity.IProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Product
{
	public interface IProductService
	{
		//Create
		Task<IProductServiceCreateProductAsyncResponse> createProductAsync(IProductServiceCreateProductAsyncRequest product);
		//Read
		Task<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse> getProductWithBarcodeNumberAndMarketIdAsync(string barcodeNumber, int marketId);
		//Update
		Task<IProductServiceUpdateProductAsyncResponse> updateProductAsync(IProductServiceUpdateProductAsyncRequest product);
		//Delete
		Task<bool> deleteProductAsync(string id);

	}
}
