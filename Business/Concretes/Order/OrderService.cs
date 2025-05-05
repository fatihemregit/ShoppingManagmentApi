using AutoMapper;
using Business.Abstracts.Order;
using Business.Utils.Functions;
using Data.Abstracts.Order;
using Entity.IOrderService;
using Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstracts.Product;
using Entity.IProductRepository;
using Entity.IOrderRepository;
using Microsoft.Extensions.Logging;

namespace Business.Concretes.Order
{
	public class OrderService : IOrderService
	{

		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;
		private readonly IProductRepository _productRepository;
		private readonly ILogger<OrderService> _logger;

		public OrderService(IMapper mapper, IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
			_productRepository = productRepository;
			_logger = logger;
		}


		private string createOrderId()
		{
			return $"ORDER-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
		}



		private async Task checkProductsAsync(List<string> productIds)
		{
			List<string> notAProducts = new List<string>();
			foreach (string id in productIds)
			{
				IProductRepositoryGetOneProductByIdAsyncResponse? result = await _productRepository.getOneProductByIdAsync(id);
				if (result is null)
				{
					notAProducts.Add(id);
				}
			}
			if (notAProducts.Count > 0)
			{
				string errorMessage = "product id ile ürün bulanamadı";
				foreach (string i in notAProducts)
				{
					errorMessage += $"\n{i}";
				}
				throw new NotFoundException(errorMessage);
			}

		}

		public async Task<string> createOrderAsync(List<string> productIds)
		{
			if (HelpFullFunctions.nullCheckObjectProps(productIds))
			{
				//product id lerden biri null gelmiş throw fırlatalım
				_logger.LogDebug("productIds parametresi null olamaz");
				throw new BadRequestException("productIds parametresi null olamaz");
			}
			//bu product idler ile ilişkili ürün olup olmadığını kontrol edelim
			//(sipariş oluşturulurken her bir ürün için ayrı ayrı kayıt gireceğiz kayıt esnasında id ile alakalı ürün bulamazsak işlem yarım kalacak.bazı ürünler kaydedilirken bazıları kaydedilmemiş olabilir.
			// bundan dolayı ürünleri tek tek kayıtlı olup olmadığını kontrol edeceğiz.eğer ürünlerden biri kayıtlı değilse throw fırlatcak )
			//product id check
			await checkProductsAsync(productIds);
			IOrderRepositoryCreateOrdersAsyncRequest orderRequest;
			List<IOrderRepositoryCreateOrdersAsyncRequest> orderRequests = new List<IOrderRepositoryCreateOrdersAsyncRequest>();
			string orderId = createOrderId();

			foreach (string i in productIds)
			{
				IProductRepositoryGetOneProductByIdAsyncResponse? product = await _productRepository.getOneProductByIdAsync(i);
				orderRequest = new IOrderRepositoryCreateOrdersAsyncRequest { OrderId = orderId, ProductId = product.Id, ProductPrice = product.Price };
				orderRequests.Add(orderRequest);
			}
			List<IOrderRepositoryCreateOrdersAsyncResponse>? orderResponses = await _orderRepository.createOrdersAsync(orderRequests);
			if (orderResponses is null)
			{
				_logger.LogDebug("sipariş oluşturma başarısız");
				throw new BadRequestException("sipariş oluşturma başarısız");
			}
			_logger.LogInformation($"sipariş oluşturma başarılı(order id : {orderId})");
			return orderId;
		}

		public async Task<List<IOrderServiceGetAllOrdersAsyncResponse>> getAllOrdersAsync()
		{
			List<IOrderRepositoryGetAllOrdersAsyncResponse> result = await _orderRepository.getAllAsync();
			_logger.LogInformation($"tüm siparişler listelendi (toplam sipariş sayısı {result.Count})");
			return _mapper.Map<List<IOrderServiceGetAllOrdersAsyncResponse>>(result);
		}

		public async Task<List<IOrderServiceGetOrdersByOrderIdAsyncResponse>> getOrdersByOrderIdAsync(string orderId)
		{
			if (HelpFullFunctions.nullCheckObjectProps(new { orderId = orderId }))
			{
				_logger.LogDebug("orderId parametresi null olamaz");
				throw new BadRequestException("orderId parametresi null olamaz");
			}
			List<IOrderRepositoryGetOrdersByOrderIdAsyncResponse>? result = await _orderRepository.getOrdersByOrderIdAsync(orderId);
			if (result is null)
			{
				_logger.LogDebug($"{orderId} order id li siparişler bulunamadı");
				throw new NotFoundException($"{orderId} order id li siparişler bulunamadı");
			}
			_logger.LogInformation($"{orderId} order id li siparişler bulundu");
			return _mapper.Map<List<IOrderServiceGetOrdersByOrderIdAsyncResponse>>(result);
		}

		public async Task<IOrderServiceGetOrderByRowIdAsyncResponse> getOrderByRowIdAsync(int rowId)
		{
			if (HelpFullFunctions.nullCheckObjectProps(new { rowId = rowId }))
			{
				_logger.LogDebug("rowId parametresi null olamaz");
				throw new BadRequestException("rowId parametresi null olamaz");
			}
			IOrderRepositoryGetOneOrderByRowIdAsyncResponse? result = await _orderRepository.getOneOrderByRowIdAsync(rowId);
			if (result is null)
			{
				_logger.LogDebug($"{rowId} row id li sipariş bulunamadı");
				throw new NotFoundException($"{rowId} row id li sipariş bulunamadı");
			}
			_logger.LogInformation($"{rowId} row id li sipariş bulundu(order id : {result.OrderId})");
			return _mapper.Map<IOrderServiceGetOrderByRowIdAsyncResponse>(result);
		}

		public async Task<IOrderServiceUpdateOrderAsyncResponse> updateOrderAsync(IOrderServiceUpdateOrderAsyncRequest order)
		{
			if (HelpFullFunctions.nullCheckObjectProps(order))
			{
				_logger.LogDebug("order parametresi null olamaz");
				throw new BadRequestException("order parametresi null olamaz");
			}
			IOrderRepositoryGetOneOrderByRowIdAsyncResponse? foundOrder = await _orderRepository.getOneOrderByRowIdAsync(order.RowId);
			if (foundOrder is null)
			{
				_logger.LogDebug($"{order.RowId} row id li sipariş bulunamadı");
				throw new NotFoundException($"{order.RowId} row id li sipariş bulunamadı");
			}
			IOrderRepositoryUpdateOneOrderAsyncRequest request = _mapper.Map<IOrderRepositoryUpdateOneOrderAsyncRequest>(order);
			request.OrderId = foundOrder.OrderId;
			request.ProductId = foundOrder.ProductId;
			IOrderRepositoryUpdateOneOrderAsyncResponse? result = await _orderRepository.updateOneOrderAsync(request);
			if (result is null)
			{
				_logger.LogDebug("sipariş güncelleme başarısız");
				throw new BadRequestException("sipariş güncelleme başarısız");
			}
			_logger.LogInformation("sipariş güncelleme başarılı");
			return _mapper.Map<IOrderServiceUpdateOrderAsyncResponse>(result);
		}

		public async Task<bool> deleteOrderbyRowIdAsync(int rowId)
		{
			if (HelpFullFunctions.nullCheckObjectProps(new { rowId = rowId }))
			{
				_logger.LogDebug("rowId parametresi null olamaz");
				throw new BadRequestException("rowId parametresi null olamaz");
			}
			bool result = await _orderRepository.deleteOneOrderbyRowIdAsync(rowId);
			if (!result)
			{
				_logger.LogDebug("sipariş silme başarısız");
				throw new BadRequestException("sipariş silme başarısız");
			}
			_logger.LogInformation($"sipariş silme başarılı (row id : {rowId})");
			return result;
		}

		public async Task<bool> deleteOrdersByOrderIdAsync(string orderId)
		{
			if (HelpFullFunctions.nullCheckObjectProps(new { orderId = orderId }))
			{
				_logger.LogDebug("orderId parametresi null olamaz");
				throw new BadRequestException("orderId parametresi null olamaz");
			}
			bool result = await _orderRepository.deleteOrdersByOrderIdAsync(orderId);
			if (!result)
			{
				_logger.LogDebug("sipariş silme başarısız");
				throw new BadRequestException("sipariş silme başarısız");
			}
			_logger.LogInformation($"sipariş silme başarılı (order id : {orderId})");
			return result;

		}








	}
}
