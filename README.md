# Shopping Managment Project
[trReadmeHere](https://github.com/fatihemregit/ShoppingManagmentApi/blob/master/README_TR.md)
<br>
The project I wrote to make my own work easier in the market
## Project Purpose
To make my job easier when calculating the price of products in the market.
<br>
The user scans the product barcode.
<br>
The information of the product in the database comes from the backend.
<br>
At the end of the shopping, the product list is sent to the backend and the order is saved.
## Tasks Completed in This Commit
- Minor modifications to some files
## Project Log
### Day 1 (26.12.2024)
- Api Project created (ShoppingManagment).
- Created the necessary projects for layered architecture (Business, Data, Entity).
- Dto objects (Entity/Dto/ProductDto.cs and MarketDto.cs) were written
- Created folder structure required for regular code writing in Data Layer (Abstracts,Efcore,Efcore/Config,EfCore/Context,EfCore/Migrations).
- Installed the necessary libraries for Entity Framework Core (EfCore) in the Data Layer (Microsoft.EntityFrameworkCore,Microsoft.EntityFrameworkCore.Design,Microsoft.EntityFrameworkCore.SqlServer,Microsoft.EntityFrameworkCore.Tools).
- ApplicationDbContext(Data/EfCore/Context) class was written.
- MarketDtoConfig and ProductDtoConfig (Data/EfCore/Config) class was written.
- Database connection string was written in appsettings.json file in Api Project.
- Created DataExtensions(Data/Utils/Extensions/) class for program.cs implementations in Data Layer.
- The connection code between the database connection text and ApplicationDbContext (ConfigureSqlContextForDataLayer method in DataExtensions) has been written.
- The connection code between Program.cs and DataExtensions(Data/Utils) class (builder.services. ...) was written
- The necessary code snippet was added for Migrations to occur in the data layer and not in the Main Project (ConfigureSqlContextForDataLayer method in DataExtensions)
- The first Migration was created and applied to the local database server.
- IProductRepository interface (Data/Abstracts/Product) was written and objects used in functions (IProductRepositoryCreateOneProductAsync,IProductRepositoryGetAllAsync,IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync,IProductRepositoryGetOneProductByIdAsync, IProductRepositoryUpdateOneProductAsync), created in the folder where the class is located
- ProductRepository class (Data/EfCore) was written and the objects used in its functions were written (the classes were empty in the interface phase, they were filled)
- Created IProductRepository folder in Entity layer and created IProductRepository related objects (IProductRepositoryCreateOneProductAsync,IProductRepositoryGetAllAsync, IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync,IProductRepositoryGetOneProductByIdAsync,IProductRepositoryUpdateOneProductAsync) moved to the folder.
- MarketRepository class was written and objects used in functions (IMarketRepositoryCreateOneMarketAsync,IMarketRepositoryGetAllAsync,IMarketRepositoryGetOneMarketByIdAsync,IMarketRepositoryUpdateOneMarketAsync) were created and written in the same folder
- IMarketRepository interface was written according to MarketRepository class.
- IMarketRepository folder was created in Entity layer and IMarketRepository related objects (IMarketRepositoryCreateOneMarketAsync,IMarketRepositoryGetAllAsync,IMarketRepositoryGetOneMarketByIdAsync,IMarketRepositoryUpdateOneMarketAsync) were moved to the folder.
- Created README_TR and README files for the version control system.
- The content of the README files was written.
- Version control system (Github) connection was made.
- Created gitignore file for version control system.
### Day 2 (27.12.2024)
- In the Business Layer, the folder structure required for regular code writing was created (Abstracts,Abstracts/Market,Abstracts/Product,Concretes,Concretes/Market,Concretes/Product,Utils,Utils/AutoMapper,Utils/Extensions).
- MappingProfileForBusinessLayer(Business/Utils/AutoMapper) and ServiceExtensions(Business/Utils/Extensions) classes have been created.
- In the Business Layer, the AutoMapper library was loaded and the necessary code for implementation (setAutoMapperForBusinessLayer in ServiceExtensions) was written.
- The connection code between Program.cs and ServiceExtensions (Business/Utils) class (builder.services. ...) was written.
- Custom Exceptions folder was created (Entity/Exceptions) and Custom Exceptions classes (BadRequestException, ConflictException, OkException) were written
- IProductService (Business/Abstracts/Product) interface was created.
- ProductService class (Business/Concretes/Product) was created, some functions (getProductWithBarcodeNumberAndMarketId, createProduct, CheckIsAlreadyProductInDb) were written to the class, Objects specific to these methods (IProductServiceCreateProduct, IProductServiceGetProductWithBarcodeNumberAndMarketId) have been written, necessary mapping codes have been written to MappingProfileForBusinessLayer(Business/Utils/AutoMapper) class
### Day 3 (28.12.2024)
- Added a new function (updateProduct) to the ProductService class
### Day 4 (29.12. 2024)
- A new function (deleteProduct) was written in the ProductService class
- Function classes used in the IProductRepository interface were rewritten according to request,response
- Function classes used in the IMarketRepository interface were rewritten according to request,response
- Changed the createOneProductAsync method in the ProductRepository class (changing the method of finding the id prop)
- Edited Readme File
- Function classes used in the IProductService interface were rewritten according to request,response.
- Added the word Async to the names of the functions used in the IProductService interface.
- Added the word Async to the names of some of the functions used in the IProductService interface (updateProduct, deleteProduct)
- Wrote the IProductService interface according to the ProductService class
- Implemented the IProductService interface to the ProductService class.
- Custom Error Handling system was created and implemented in the code
### Day 5 (31.12.2024)
- Parameter null check system was written to ProductService class
- A new function (createMarketAsync) was written to MarketService class.
- A new function (getOneMarketByNameAsync) has been written to IMarketRepository class.
- Moved the error throwing system in the ProductRepository class to the ProductService class.
- Moved the error throwing system in the MarketRepository class to the MarketService class.
- The remaining functions in the MarketService class (getAllMarketsAsync, getMarketByIdAsync, updateMarketAsync, deleteMarketAsync) have been written.
- ImarketService interface was written according to MarketService class
- ImarketService interface was implemented to MarketService class.
### Day 6 (01.01.2025)
- Created Product Controller
- In Data layer, added concrete counterparts of Interface objects to Dependency Injection Container (setInterfaceConcretesForDataLayer method in DataExtensions)
- In Business layer, added concrete counterparts of Interface objects to Dependency Injection Container (setInterfaceConcretesForBusinessLayer method in ServiceExtensions)
- Installed AutoMapper library in main project
- In main project, created MainExtensions(Utils/Extensions) class for program. cs implementations in the main project
- Created MainExtensions(Utils/Extensions) class for program.cs implementations - Wrote necessary code for Automapper implementation (setAutoMapperForMainLayer function in MainExtensions class, MappingProfileForMainLayer(Utils/AutoMapper) class)
- Wrote connection code between Program.cs and MainExtensions(Utils/Extensions) class (builder.services. ...)
- A new function was written to Product Controller (createProductAsync) and the required function objects (ProductControllerCreateProductAsyncRequest,ProductControllerCreateProductAsyncResponse) were created
- A static class was created for useful functions in the Business layer (HelpFullFunctions(Utils/Functions)).And a function for null check (nullCheckObjectProps) was written.
- Changed the null check system in Product Service.(HelpFullFunctions.nullCheckObjectProps function)
- Created a new function in Product Controller(getProductWithBarcodeNumberAndMarketIdAsync) and created the required function object(ProductControllerGetProductWithBarcodeNumberAndMarketIdAsyncResponse)
### Day 7 (02.01.2025)
- New functions (updateProductAsync, deleteProductAsync) and necessary function objects (ProductControllerUpdateProductAsyncRequest, ProductControllerUpdateProductAsyncResponse) were created in Product Controller.
- Added new fields (CreatedDate, ModifiedDate) to ProductDto object.
- Changes were made to the ProductRepository class (filling the newly added fields)
### Day 8 (03.01. 2025)
- MarketController class was written and necessary function objects (MarketControllerCreateMarketAsyncRequest,MarketControllerCreateMarketAsyncResponse, MarketControllerGetAllMarketsAsyncResponse,MarketControllerGetMarketByIdAsyncResponse,MarketControllerUpdateMarketAsyncRequest,MarketControllerUpdateMarketAsyncResponse) created
### Day 9 (04. 01.2025)
- Created OrderDto object.
- OrderDto related relationships were established
- OrderDtoConfig class was written.
- CustomIdGeneratorForOrderDto class was created for OrderDto's orderId prop.
- OrderDto object was added to ApplicationDbContext class.
- Migrations for OrderDto object were created and applied to the database.
- IOrderRepository interface was written and necessary function objects (IOrderRepositoryCreateOneOrderAsyncRequest,IOrderRepositoryCreateOneOrderAsyncResponse,IOrderRepositoryGetAllOrdersAsyncResponse, IOrderRepositoryGetOrdersByOrderIdAsyncResponse,IOrderRepositoryGetOneOrderByRowIdAsyncResponse,IOrderRepositoryUpdateOneOrderAsyncRequest,IOrderRepositoryUpdateOneOrderAsyncResponse) was created.
- OrderRepository class was created and some functions (createOneOrderAsync,getAllAsync,getOrdersByOrderIdAsync,getOneOrderByRowIdAsync) were written.
### Day 10 (05.01. 2025)
- Unwritten functions in OrderRepository class (updateOneOrderAsync,deleteOneOrderbyRowIdAsync,deleteOrdersByOrderIdAsync) were written
- IOrderService interface was written and necessary function objects (IOrderServiceGetAllOrdersAsyncResponse, IOrderServiceGetOrdersByOrderIdAsyncResponse,IOrderServiceGetOrderByRowIdAsyncResponse,IOrderServiceUpdateOrderAsyncResponse,IOrderServiceUpdateOrderAsyncRequest) was created.
- OrderService class was created
- Concrete equivalent of IOrderService interface was added to Dependency Injection Container
- List type data was not accepted in nullCheckObjectProps function in HelpFullFunctions class.
- Some functions in OrderService (createOrderAsync, getAllOrdersAsync, getOrdersByOrderIdAsync, getOrderByRowIdAsync) were written
- Unwritten functions in OrderService (updateOrderAsync, deleteOrderbyRowIdAsync, deleteOrdersByOrderIdAsync) were written
- OrderController class was created and one of its functions (CreateOrder) was written
### Day 11 (06.01. 2025)
- Unwritten functions in OrderController (getAllOrdersAsync,getOrdersByOrderIdAsync,getOrderByRowIdAsync,updateOrderAsync,deleteOrderbyRowIdAsync,deleteOrdersByOrderIdAsync) have been written and required function objects (OrderControllerGetAllOrdersAsyncResponse, OrderControllerGetOrdersByOrderIdAsyncResponse,OrderControllerGetOrderByRowIdAsyncResponse,OrderControllerUpdateOrderAsyncRequest,OrderControllerUpdateOrderAsyncResponse) has been created.
- Fixed bug in updateOrderAsync method in OrderService class
### Day 12 (07.01.2025)
- Modified the createOrdersAsync method in OrderRepository class (retrieving a list of records, not a single record)
- Modified the createOrderAsync method in OrderService class to match the change in the createOrdersAsync method in OrderRepository class
### Day 13 (09.01.2025)
- Devolopment and Production environments were defined in launchSettings.json
- Separate error codes were defined for Exception classes (ConflictException, NotFoundException, CustomException) to return in production environment.
- Rate limiting system was installed and necessary implementations were made to controllers (ProductController, OrderController, MarketController).
- The codes related to rate limiting settings were moved from program.cs to setRateLimiter function in MainExtensions
### Day 14 (10.01.2025)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore library was installed and necessary changes were made in the code
 (conversion of ApplicationDbContext to IdentityDbContext in data layer, creation of AppUser and AppRole classes in Entity Layer, creation and implementation of
 database migration)
- Auth Settings were made in Program.cs (setAuthentication method in MainExtensions)
### Day 15 (11.01.2025)
- Making "jwt:issuer" and "jwt:audience" values in secrets.json more secure
- AuthController class was created, new user registration and token creation codes were written.
- Conditions (AddIdentity part in the setAuthentication method in MainExtensions) were added for new user registration.
- The necessary codes were written for the existing user to renew the AcessToken with RefreshToken.
- The necessary codes were written for the login process
- Minor errors in AuthController were fixed.
- Changes were made in IdentityException class (production error code was changed to 401)
### Day 16 (13.01.2025)
- Created IAuthService interface, AuthService class and function objects to move the code in AuthControls to the Business Layer
### Day 17 (28.01.2025)
- AuthService class was written. and connection code (AddScoped) between it and IauthService was written.
- Preparation was made to test the AuthService class in AuthController, but it was not tested
- AuthService class was tested. (No problem is seen)
- AuthController was connected to Authservice class in business layer
- Unnecessary code in AuthController was deleted
- Parameter null check was added to AuthService class
### Day 18 (29.01.2025)
- Added parameter null check to some functions in OrderService Class (deleteOrderbyRowIdAsync, deleteOrdersByOrderIdAsync)
- Changed parameter null check system in functions in MarketService Class.
- Defined rate limit rule for AuthController in MainExtensions
- Enabled rateLimit in AuthController (EnableRateLimiting)
- Enabled Authorize in MarketController and ProductController (Authorize(AuthenticationSchemes = "Bearer"))
### Day 19 (01.02.2025)
- Installed logging system (nlog) related libraries (NLog, NLog.Extensions.Logging)
- Configured logging system (nlog.config, Program.cs) and tested logging system (TrialController)
### Day 20 (04.02.2025)
- Logging system has been adapted to multi-tier architecture
- Logging system, Dependency Injection settings (Business.Utils.Extensions.ServiceExtensions class setInterfaceConcretesForBusinessLayer method, Data.Utils.Extensions.DataExtensions class setInterfaceConcretesForDataLayer method) were made
### Day 21 (06.02.2025)
- Implemented logging system in AuthService class
- Implemented logging system in MarketService class
### Day 22 (08.03.2025)
- Added some comment lines (line 20) in MarketRepository Class.
- Added BreakPoint points in MarketRepository Class.
### Day 23 (09.03.2025)
- Deleted some of the files required for the logging system (ILoggerService and LoggerService class in Business layer, IBaseLogger and Nlogger class in Data Layer)
- Added a new layer (Core layer) to the project
### Day 24 (10.03.2025)
- Logging system deleted from Main Project (deletion of libraries (NLog, NLog.Extensions.Logging), deletion of Nlog.config file)
- Created necessary files in Core layer for logging system (Core.Data.Abstracts.Logging.ILoggingRepository,Core.Data.EfCore.Context.CoreDbContext,Core.Data.EfCore.LoggingRepository)
### Day 25 (29.03.2025)
- Logging related statements (lines starting with _logger) in the Busines layer have been moved to the comment line in certain files (AuthService, MarketService).
- In the Business and Data layer, Dependency Injection settings related to logging (services.AddScoped) were added to the comment line.
- minor changes were made in some files (MarketRepository,TrialController).