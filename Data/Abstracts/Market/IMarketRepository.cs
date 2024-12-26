using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.IMarketRepository;
namespace Data.Abstracts.Market
{
    public interface IMarketRepository
    {
		//Create
		Task<IMarketRepositoryCreateOneMarketAsync?> createOneMarketAsync(IMarketRepositoryCreateOneMarketAsync market);

		//Read
		Task<List<IMarketRepositoryGetAllAsync>> getAllAsync();

		Task<IMarketRepositoryGetOneMarketByIdAsync?> getOneMarketByIdAsync(int id);

		//Update
		Task<IMarketRepositoryUpdateOneMarketAsync?> updateOneMarketAsync(IMarketRepositoryUpdateOneMarketAsync market);

		//Delete
		Task<bool> deleteOneMarketByIdAsync(int id);

	}
}
