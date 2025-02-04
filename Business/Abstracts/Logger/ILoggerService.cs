using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.ILoggerService;

namespace Business.Abstracts.Logger
{
	public interface ILoggerService
	{
		
		//Business Layer
		void sucessInBusinessLayer(string message,object item);
		void unSucessInBusinessLayer(string message,object item);
		//Data Layer
		void sucessInDataLayer(string message, object item);
		void unSucessInDataLayer(string message, object item);

		//Main Layer(hata yönetiminde hata fırlatıldığında loglama)
		void logToError(int statusCode,string message,string stackTrace);

		/*
		 böyle yazmak yerine bir tane parametere olarak message ve obje alan sucess adında bir metod
		ve metot ta mesajı ve objenin değerlerini logladığımız bir metot.

		bir tane de  parametere olarak message ve obje alan unSucess adında bir metod
		ve metot ta mesajı ve objenin değerlerini logladığımız bir metot.
		yazsak?
		 */


		////Business Layer
		////AuthService
		//void refreshTokenCreated(string refreshToken);
		//void AccessTokenCreated(string accessToken);

		//void newUserCreated(ILoggerServiceNewUserCreatedRequest user);

		//void newUserNotCreated(ILoggerServiceNewUserNotCreatedRequest user);

		//void newUserNotCreated(string message);

		//void checkRefreshTokenSucess(string refreshToken);
		//void checkRefreshTokenNotSucess(string refreshToken);

		//void newAcessTokenSucess(string refreshToken);
		//void newAcessTokenNotSucesswithToken(string refreshToken);

		//void newAcessTokenNotSucesswithMessage(string message);
		////MarketService
		//void checkisAlreadyMarketInDbSucess(string marketName);
		//void checkisAlreadyMarketInDbNotSucess(string message);

		//void createMarketAsyncSucess(string marketName);
		//void createMarketAsyncNotSucess(string message);

		//void getMarketByIdAsyncSucess(int id);

		//void getMarketByIdAsyncNotSucess(string message);

		////OrderService

		////ProductService
		////Data Layer
		////MarketRepository
		////OrderRepository
		////ProductRepository
	}
}
