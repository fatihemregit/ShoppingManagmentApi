﻿using System;
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
		Task<IMarketRepositoryCreateOneMarketAsyncResponse?> createOneMarketAsync(IMarketRepositoryCreateOneMarketAsyncRequest market);

		//Read
		Task<List<IMarketRepositoryGetAllAsyncResponse>> getAllAsync();

		Task<IMarketRepositoryGetOneMarketByIdAsyncResponse?> getOneMarketByIdAsync(int id);

		Task<IMarketRepositoryGetOneMarketByNameAsyncResponse?> getOneMarketByNameAsync(string MarketName);


		//Update
		Task<IMarketRepositoryUpdateOneMarketAsyncResponse?> updateOneMarketAsync(IMarketRepositoryUpdateOneMarketAsyncRequest market);

		//Delete
		Task<bool> deleteOneMarketByIdAsync(int id);

	}
}
