# Shopping Managment Projesi
Kendi i�imi markette kolayla�t�rmak i�in yazd���m proje
## Projenin Amac�
Markette �r�nlerinin fiyat�n� hesaplarken i�imi kolayla�t�rmak.
Kullan�c� �r�n barkodunu okutur.
<br>
�r�n�n veritaban�ndaki bilgileri backend den gelir.
<br>
Al��veri� sonunda �r�n listesi backend e g�nderilir ve sipari� kaydedilir.
## Bu Committe Yap�lan i�lemler
- Loglama sistemi i�in gerekli olan dosyalar�n baz�lar�n�n silinmesi
- Projeye yeni bir katman eklenmesi
## Proje g�nl���
### G�n 1 (26.12.2024)
- Api Projesi olu�turuldu(ShoppingManagment).
- Katmanl� mimari i�in gerekli projeler olu�turuldu(Business,Data,Entity).
- Dto nesneleri(Entity/Dto/ProductDto.cs ve MarketDto.cs) yaz�ld�
- Data Katman�nda d�zenli kod yaz�m� i�in gerekli klas�r yap�s� Olu�turuldu(Abstracts,Efcore,Efcore/Config,EfCore/Context,EfCore/Migrations).
- Data Katman�nda Entity Framework Core(EfCore) i�in gerekli k�t�phaneler y�klendi(Microsoft.EntityFrameworkCore,Microsoft.EntityFrameworkCore.Design,Microsoft.EntityFrameworkCore.SqlServer,Microsoft.EntityFrameworkCore.Tools).
- ApplicationDbContext(Data/EfCore/Context) s�n�f� yaz�ld�.
- MarketDtoConfig ve ProductDtoConfig (Data/EfCore/Config) s�n�f� yaz�ld�.
- Api Projesindeki appsettings.json dosyas�na Veritaban� ba�lant� metni(Connection string) yaz�ld�.
- Data Katman�ndaki program.cs implemantasyonlar� i�in DataExtensions(Data/Utils/Extensions/) s�n�f� olu�turuldu.
- Veritaban� ba�lant� metni ile ApplicationDbContext aras�ndaki ba�lant� kodu (DataExtensions daki ConfigureSqlContextForDataLayer metodu) yaz�ld�.
- Program.cs ile DataExtensions(Data/Utils) s�n�f� aras�ndaki ba�lant� kodu(builder.services. ...) yaz�ld�
- Migrationlar�n Ana Projeye de�il data katman�nda olu�mas� i�in gerekli kod par�ac��� eklendi(DataExtensions daki ConfigureSqlContextForDataLayer metodu)
- �lk Migration olu�turuldu ve localdeki veri taban� sunucusuna uyguland�.
- IProductRepository interface i (Data/Abstracts/Product) yaz�ld� ve fonksiyonlarda kullan�lan nesneler(IProductRepositoryCreateOneProductAsync,IProductRepositoryGetAllAsync,IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync,IProductRepositoryGetOneProductByIdAsync,IProductRepositoryUpdateOneProductAsync),s�n�f�n bulundu�u klas�re olu�turuldu
- ProductRepository s�n�f�(Data/EfCore) yaz�ld� ve fonksiyonlar�nda kullan�lan nesneler yaz�ld�(interface a�amas�nda s�n�flar�n i�i bo�tu,dolduruldu)
- Entity katman�nda IProductRepository klas�r� olu�turuldu ve IProductRepository ile alakal� nesneler(IProductRepositoryCreateOneProductAsync,IProductRepositoryGetAllAsync,IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync,IProductRepositoryGetOneProductByIdAsync,IProductRepositoryUpdateOneProductAsync) klas�re ta��nd�.
- MarketRepository s�n�f� yaz�ld� ve fonksiyonlarda kullan�lan nesneler(IMarketRepositoryCreateOneMarketAsync,IMarketRepositoryGetAllAsync,IMarketRepositoryGetOneMarketByIdAsync,IMarketRepositoryUpdateOneMarketAsync) ayn� klas�rde olu�turuldu,yaz�ld�
- IMarketRepository interface i MarketRepository s�n�f�na g�re yaz�ld�.
- Entity katman�nda IMarketRepository klas�r� olu�turuldu ve IMarketRepository ile alakal� nesneler(IMarketRepositoryCreateOneMarketAsync,IMarketRepositoryGetAllAsync,IMarketRepositoryGetOneMarketByIdAsync,IMarketRepositoryUpdateOneMarketAsync) klas�re ta��nd�.
- Versiyon kontrol sistemi i�in README_TR ve README dosyalar� olu�turuldu.
- Readme dosyalar�n�n i�eri�i yaz�ld�.
- Versiyon kontrol sistemi(Github) ba�lant�s� yap�ld�.
- Versiyon kontrol sistemi i�in gitignore dosyas� olu�turuldu.
### G�n 2 (27.12.2024)
- Business Katman�nda,d�zenli kod yaz�m� i�in gerekli klas�r yap�s� Olu�turuldu(Abstracts,Abstracts/Market,Abstracts/Product,Concretes,Concretes/Market,Concretes/Product,Utils,Utils/AutoMapper,Utils/Extensions).
- MappingProfileForBusinessLayer(Business/Utils/AutoMapper) ve ServiceExtensions(Business/Utils/Extensions) s�n�flar� olu�turuldu.
- Business Katman�nda,AutoMapper k�t�phanesi y�klendi ve implementasyon i�in gerekli kodlar(ServiceExtensions daki setAutoMapperForBusinessLayer) yaz�ld�.
- Program.cs ile ServiceExtensions(Business/Utils) s�n�f� aras�ndaki ba�lant� kodu(builder.services. ...) yaz�ld�.
- Custom Exceptions klas�r� olu�turuldu (Entity/Exceptions) ve Custom Exceptions s�n�flar�(BadRequestException,ConflictException,OkException) yaz�ld�
- IProductService(Business/Abstracts/Product) interface i olu�turuldu.
- ProductService s�n�f�(Business/Concretes/Product) olu�turuldu,s�n�fa baz� fonksiyonlar(getProductWithBarcodeNumberAndMarketId,createProduct,CheckIsAlreadyProductInDb) yaz�ld�,Bu metotlara �zg� nesneler(IProductServiceCreateProduct,IProductServiceGetProductWithBarcodeNumberAndMarketId) yaz�ld�,gerekli mapleme kodlar� MappingProfileForBusinessLayer(Business/Utils/AutoMapper) s�n�f�na yaz�ld�
### G�n 3 (28.12.2024)
- ProductService s�n�f�na yeni bir fonksiyon(updateProduct) yaz�ld�
### G�n 4 (29.12.2024)
- ProductService s�n�f�na yeni bir fonksiyon(deleteProduct) yaz�ld�
- IProductRepository interface inde kullan�lan fonksiyon s�n�flar� request,response a g�re yeniden yaz�ld�
- IMarketRepository interface inde kullan�lan fonksiyon s�n�flar� request,response a g�re yeniden yaz�ld�
- ProductRepository s�n�f�ndaki createOneProductAsync metodunda de�i�iklik yap�ld� (id propunun bulunma y�nteminin de�i�tirilmesi)
- Readme Dosyas� d�zenlendi
- IProductService interface inde kullan�lan fonksiyon s�n�flar� request,response a g�re yeniden yaz�ld�.
- IProductService interface inde kullan�lan fonksiyonlar�n isimlerine Async kelimesi eklendi.
- IProductService interface inde kullan�lan baz� fonksiyonlar�n isimlerine(updateProduct,deleteProduct) Async kelimesi eklendi
- ProductService s�n�f�na g�re IProductService interface i yaz�ld�
- ProductService s�n�f�na,IProductService interface i uyguland�.
- Custom Error Handling sistemi kuruldu,ve kodlara implemantasyonu yap�ld�
### G�n 5 (31.12.2024)
- ProductService s�n�f�na parameter null check sistemi yaz�ld�
- MarketService s�n�f�na yeni bir fonksiyon (createMarketAsync) yaz�ld�.
- IMarketRepository s�n�f�na yeni bir fonksiyon(getOneMarketByNameAsync) yaz�ld�.
- ProductRepository s�n�f�ndaki hata f�rlatma sistemi ProductService s�n�f�na ta��nd�.
- MarketRepository s�n�f�ndaki hata f�rlatma sistemi MarketService s�n�f�na ta��nd�.
- MarketService s�n�f�ndaki geri kalan fonksiyonlar(getAllMarketsAsync,getMarketByIdAsync,updateMarketAsync,deleteMarketAsync) yaz�ld�.
- IMarketService interface i MarketService s�n�f�na g�re yaz�ld�
- MarketService s�n�f�na,ImarketService interface i uyguland�.
### G�n 6 (01.01.2025)
- Product Controller olu�turuldu
- Data katman�nda,Interface nesnelerinin somut kar��l�klar� Dependency Injection Container a eklendi(DataExtensions daki setInterfaceConcretesForDataLayer metodu)
- Business katman�nda,Interface nesnelerinin somut kar��l�klar� Dependency Injection Container a eklendi(ServiceExtensions daki setInterfaceConcretesForBusinessLayer metodu)
- Ana projeye AutoMapper k�t�phanesi y�klendi
- Ana projede,program.cs implemantasyonlar� i�in MainExtensions(Utils/Extensions) s�n�f� olu�turuldu
- Automapper �n implementasyonu i�in gerekli kodlar yaz�ld�(MainExtensions s�n�f�ndaki setAutoMapperForMainLayer fonksiyonu,MappingProfileForMainLayer(Utils/AutoMapper) s�n�f�)
- Program.cs ile MainExtensions(Utils/Extensions) s�n�f� aras�ndaki ba�lant� kodu(builder.services. ...) yaz�ld�
- Product Controller a yeni bir fonksiyon yaz�ld�(createProductAsync) ve gerekli fonksiyon nesneleri(ProductControllerCreateProductAsyncRequest,ProductControllerCreateProductAsyncResponse) olu�turuldu
- Business katman�nda yararl� fonksiyonlar i�in bir statik s�n�f olu�turuldu(HelpFullFunctions(Utils/Functions)).Ve null check i�in bir fonkisyon(nullCheckObjectProps) yaz�ld�.
- Product Service deki null check sistemi de�i�tirildi.(HelpFullFunctions.nullCheckObjectProps fonksiyonu)
- Product Controller a yeni bir fonksiyon yaz�ld�(getProductWithBarcodeNumberAndMarketIdAsync) ve gerekli fonksiyon nesnesi(ProductControllerGetProductWithBarcodeNumberAndMarketIdAsyncResponse) olu�turuldu
### G�n 7 (02.01.2025)
- Product Controllera yeni fonksiyonlar yaz�ld�(updateProductAsync,deleteProductAsync) ve gerekli fonksiyon nesneleri(ProductControllerUpdateProductAsyncRequest,ProductControllerUpdateProductAsyncResponse) olu�turuldu.
- ProductDto nesnesine yeni alanlar(CreatedDate,ModifiedDate) eklendi.
- ProductRepository s�n�f�nda de�i�iklikler(yeni eklenen alanlar�n doldurulmas�) yap�ld�
### G�n 8 (03.01.2025)
- MarketController s�n�f� yaz�ld� ve gerekli fonksiyon nesneleri(MarketControllerCreateMarketAsyncRequest,MarketControllerCreateMarketAsyncResponse,MarketControllerGetAllMarketsAsyncResponse,MarketControllerGetMarketByIdAsyncResponse,MarketControllerUpdateMarketAsyncRequest,MarketControllerUpdateMarketAsyncResponse) olu�turuldu
### G�n 9 (04.01.2025)
- OrderDto nesnesi olu�turuldu.
- OrderDto ile alakal� ili�kiler kuruldu
- OrderDtoConfig s�n�f� yaz�ld�.
- OrderDto nun orderId prop u i�in CustomIdGeneratorForOrderDto s�n�f� olu�turuldu.
- OrderDto nesnesi ApplicationDbContext s�n�f�na eklendi.
- OrderDto nesnesi i�in migrationlar olu�turuldu ve veritaban�na uyguland�.
- IOrderRepository interface yaz�ld� ve gerekli fonksiyon nesneleri(IOrderRepositoryCreateOneOrderAsyncRequest,IOrderRepositoryCreateOneOrderAsyncResponse,IOrderRepositoryGetAllOrdersAsyncResponse,IOrderRepositoryGetOrdersByOrderIdAsyncResponse,IOrderRepositoryGetOneOrderByRowIdAsyncResponse,IOrderRepositoryUpdateOneOrderAsyncRequest,IOrderRepositoryUpdateOneOrderAsyncResponse) olu�turuldu.
- OrderRepository s�n�f� olu�turuldu ve baz� fonksiyonlar(createOneOrderAsync,getAllAsync,getOrdersByOrderIdAsync,getOneOrderByRowIdAsync) yaz�ld�.
### G�n 10 (05.01.2025)
- OrderRepository s�n�f�ndaki yaz�lmayan fonksiyonlar(updateOneOrderAsync,deleteOneOrderbyRowIdAsync,deleteOrdersByOrderIdAsync) yaz�ld�
- IOrderService interface i yaz�ld� ve  gerekli fonksiyon nesneleri(IOrderServiceGetAllOrdersAsyncResponse,IOrderServiceGetOrdersByOrderIdAsyncResponse,IOrderServiceGetOrderByRowIdAsyncResponse,IOrderServiceUpdateOrderAsyncResponse,IOrderServiceUpdateOrderAsyncRequest) olu�turuldu.
- OrderService s�n�f� olu�turuldu
- IOrderService interface nin somut kar��l��� Dependency Injection Container a eklendi
- HelpFullFunctions s�n�f�ndaki nullCheckObjectProps fonksiyonunda liste tipi veriler kabul edilmiyordu.Kabul edilebilir hale getirildi ve fonksiyonun gerekli testleri yap�ld�.
- OrderService de ki baz� fonksiyonlar(createOrderAsync,getAllOrdersAsync,getOrdersByOrderIdAsync,getOrderByRowIdAsync) yaz�ld�
- OrderService de ki yaz�lmayan fonksiyonlar(updateOrderAsync,deleteOrderbyRowIdAsync,deleteOrdersByOrderIdAsync) yaz�ld�
- OrderController s�n�f� olu�turuldu ve fonksiyonlar�ndan biri(CreateOrder) yaz�ld�
### G�n 11 (06.01.2025)
- OrderController daki yaz�lmayan fonksiyonlar(getAllOrdersAsync,getOrdersByOrderIdAsync,getOrderByRowIdAsync,updateOrderAsync,deleteOrderbyRowIdAsync,deleteOrdersByOrderIdAsync) yaz�ld� ve gerekli fonksiyon nesneleri(OrderControllerGetAllOrdersAsyncResponse,OrderControllerGetOrdersByOrderIdAsyncResponse,OrderControllerGetOrderByRowIdAsyncResponse,OrderControllerUpdateOrderAsyncRequest,OrderControllerUpdateOrderAsyncResponse) olu�turuldu.
- OrderService s�n�f�ndaki updateOrderAsync metodundaki hata d�zeltildi
### G�n 12 (07.01.2025)
- OrderRepository s�n�f�nda createOrdersAsync metodunda de�i�iklik yap�ld�(tek kay�t de�il,liste kay�t al�m�)
- OrderService s�n�f�ndaki createOrderAsync metodu, OrderRepository s�n�f�ndaki createOrdersAsync metodundaki de�i�ikli�e uygun hale getirildi
### G�n 13 (09.01.2025)
- Devolopment ve Production ortamlar� launchSettings.json da tan�mland�
- Exception s�n�flar�na(ConflictException,NotFoundException,CustomException) production ortam�nda d�nmek �zere ayr� hata kodlar� tan�mland�.
- Rate limiting sistemi kuruldu ve controller lara (ProductController,OrderController,MarketController) gerekli implemantasyonlar yap�ld�.
- Rate limiting ayarlar� ile alakal� kodlar program.cs den  MainExtensions daki setRateLimiter fonksiyonuna ta��nd�
### G�n 14 (10.01.2025)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore k�t�phanesin kuruldu ve kodda gerekli de�i�ikler yap�ld�
<br>
  (data katman�nda ApplicationDbContext in IdentityDbContext e �evirilmesi,Entity Katman�nda AppUser ve AppRole s�n�flar�n�n olu�turulmas�,
  <br> 
   veritaban� migration �n olu�turulmas� ve uygulanmas�)
- Program.cs de Auth Ayarlar� yap�ld�(MainExtensions daki setAuthentication metodu)
### G�n 15 (11.01.2025)
- secrets.json daki "jwt:issuer"  ve "jwt:audience" de�erlerinin daha g�venli hale getirilmesi
- AuthController s�n�f� olu�turuldu,yeni kullan�c� kayd� ve token olu�turma ile ilgili kodlar yaz�ld�.
- Yeni kullan�c� kayd�nda �artlar(MainExtensions daki setAuthentication metodundaki AddIdentity k�sm�) eklendi.
- Hali haz�rda olan kullan�c�n�n RefreshToken ile AcessToken �n� yenilemesi i�in gerekli kodlar yaz�ld�.
- Login i�lemi i�in gerekli kodlar yaz�ld�
- AuthController daki ufak hatalar giderildi.
- IdentityException s�n�f�nda de�i�iklik(production hata kodu 401 e �ekildi) yap�ld�
### G�n 16 (13.01.2025)
- AuthControllerdeki kodlar�n Business Katman�na ta��nmas� i�in IAuthService interface i ,AuthService s�n�f� ve fonksiyon nesneleri olu�turudu
### G�n 17 (28.01.2025)
- AuthService s�n�f� yaz�ld�.ve IauthService ile aras�ndaki ba�lant� kodu(AddScoped) yaz�ld�.
- AuthController da AuthService S�n�f�n�n test edilmesi i�in haz�rl�k yap�ld� ancak Test edilmedi
- AuthService s�n�f� test edildi.(Herhangi bir problem g�z�km�yor)
- AuthController �n business katman�ndaki Authservice s�n�f�na ba�lant�s� yap�ld�
- AuthControllerdaki gereksiz kodlar silindi
- AuthService s�n�f�na parameter null check eklendi
### G�n 18(29.01.2025)
- OrderService S�n�f�ndaki baz� fonksiyonlara(deleteOrderbyRowIdAsync,deleteOrdersByOrderIdAsync) parameter null check eklendi
- MarketService S�n�f�ndaki fonksiyonlardaki parameter null check sistemi de�i�tirildi.
- MainExtensions da AuthController i�in rate limit kural� tan�mland�
- AuthControllerda,rateLimit aktif edildi(EnableRateLimiting)
- MarketController ve ProductController da Authorize aktif edildi(Authorize(AuthenticationSchemes = "Bearer"))
### G�n 19(01.02.2025)
- Logging sistemi(nlog) ile alakal� k�t�phaneler y�klendi(NLog,NLog.Extensions.Logging)
- Loglama sistemi ile alakal� konfig�rasyonlar(nlog.config,Program.cs) yap�ld� ve loglama sistemi test edildi(DenemeController)
### G�n 20(04.02.2025)
- Loglama sistemi �ok katmanl� mimari sistemine uygun hale getirildi
- Loglama sistemi,Dependency Injection ayarlar�(Business.Utils.Extensions.ServiceExtensions s�n�f� setInterfaceConcretesForBusinessLayer metodu,Data.Utils.Extensions.DataExtensions s�n�f� setInterfaceConcretesForDataLayer metodu) yap�ld�
### G�n 21(06.02.2025)
- AuthService s�n�f�nda loglama sisteminin implementasyonu yap�ld�
- MarketService s�n�f�nda loglama sisteminin implementasyonu yap�ld�
## G�n 22 (08.03.2025)
- MarketRepository S�n�f�nda baz� yorum sat�rlar�(20.sat�r) eklendi.
- MarketRepository S�n�f�nda BreakPoint noktalar� eklendi.
### G�n 23(09.03.2025)
- Loglama sistemi i�in gerekli olan dosyalar�n baz�lar�(Business katman�ndaki ILoggerService ve LoggerService s�n�f�,Data Katman�ndaki IBaseLogger ve Nlogger s�n�f�) silindi
- Projeye yeni bir katman(Core katman�) eklendi
### Yap�labilecek �eyler
- LoggerService teki writeObject metodunun d�zenlemesi
- HelpFullFunctions s�n�f�ndaki nullCheckObjectProps daha iyi olabilir(e�er props forEach e girmezse basit veridir)(�z yineleme yapt���m�z yerde verileri objeye d�n��t�rebiliriz)
- Detayl� bir logging sistemi
- Fark ettiysen servis fonksiyonlar�n�n s�n�flar� ile repository fonksiyonlar�n�n s�n�flar� aras�nda bir benzerlik var.Acaba bunlar birbirinden kal�t�labilir mi
- Logger sisteminin ta��nmas�