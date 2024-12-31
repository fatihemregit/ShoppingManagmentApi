using Entity.IMarketService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts.Market
{
	public interface IMarketService
	{

		//Create
		Task<IMarketServiceCreateMarketAsyncResponse> createMarketAsync(IMarketServiceCreateMarketAsyncRequest market);
		//Read
		Task<List<IMarketServiceGetAllMarketsAsyncResponse>> getAllMarketsAsync();
		Task<IMarketServiceGetMarketByIdAsyncResponse> getMarketByIdAsync(int id);
		//Update
		Task<IMarketServiceUpdateMarketAsyncResponse> updateMarketAsync(IMarketServiceUpdateMarketAsyncRequest market);
		//Delete
		Task<bool> deleteMarketAsync(int id);

	}
}
