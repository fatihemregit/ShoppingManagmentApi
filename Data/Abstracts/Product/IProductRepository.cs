using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.IProductRepository;

namespace Data.Abstracts.Product
{
	public interface IProductRepository
    {

        //Create
        Task<IProductRepositoryCreateOneProductAsyncResponse> createOneProductAsync(IProductRepositoryCreateOneProductAsyncRequest product);
        //Read
        Task<List<IProductRepositoryGetAllAsyncResponse>> getAllAsync();
        Task<IProductRepositoryGetOneProductByIdAsyncResponse> getOneProductByIdAsync(string id);
        Task<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse> getOneProductByBarcodeNumberAndMarketIdAsync(string barcodeNumber, int marketId);

        //Update
        Task<IProductRepositoryUpdateOneProductAsyncResponse> updateOneProductAsync(IProductRepositoryUpdateOneProductAsyncRequest product);
        //Delete
        Task<bool> deleteOneProductbyIdAsync(string id);

	}
}