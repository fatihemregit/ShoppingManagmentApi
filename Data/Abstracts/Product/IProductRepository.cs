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
        Task<IProductRepositoryCreateOneProductAsync?> createOneProductAsync(IProductRepositoryCreateOneProductAsync product);
        //Read
        Task<List<IProductRepositoryGetAllAsync>> getAllAsync();
        Task<IProductRepositoryGetOneProductByIdAsync?> getOneProductByIdAsync(string id);
        Task<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync?> getOneProductByBarcodeNumberAndMarketIdAsync(string barcodeNumber, int marketId);

        //Update
        Task<IProductRepositoryUpdateOneProductAsync?> updateOneProductAsync(IProductRepositoryUpdateOneProductAsync product);
        //Delete
        Task<bool> deleteOneProductbyIdAsync(string id);

	}
}