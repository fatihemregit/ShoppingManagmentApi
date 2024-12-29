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
		Task<Exception> createProductAsync(IProductServiceCreateProductRequest product);
		//Read
		Task<Exception> getProductWithBarcodeNumberAndMarketIdAsync(string barcodeNumber, int marketId);
		//Update
		Task<Exception> updateProductAsync(IProductServiceUpdateProductAsyncRequest product);
		//Delete
		Task<Exception> deleteProductAsync(string id);

	}
}
