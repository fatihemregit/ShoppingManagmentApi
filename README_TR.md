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
- MarketService s�n�f�na yeni bir fonksiyon yaz�lmas�.
- IMarketRepository s�n�f�na yeni bir fonksiyon yaz�lmas�.
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
### Yap�labilecek �eyler
- ProductService s�n�f�ndaki not
- Data katman�nda notfoundexception kulan�lmas� bir t�k mant�ks�z