# Shopping Managment Projesi
Kendi iþimi markette kolaylaþtýrmak için yazdýðým proje
## Projenin Amacý
Markette ürünlerinin fiyatýný hesaplarken iþimi kolaylaþtýrmak.
Kullanýcý ürün barkodunu okutur.
<br>
Ürünün veritabanýndaki bilgileri backend den gelir.
<br>
Alýþveriþ sonunda ürün listesi backend e gönderilir ve sipariþ kaydedilir.
## Bu Committe Yapýlan iþlemler
- MarketService sýnýfýna yeni bir fonksiyon yazýlmasý.
- IMarketRepository sýnýfýna yeni bir fonksiyon yazýlmasý.
## Proje günlüðü
### Gün 1 (26.12.2024)
- Api Projesi oluþturuldu(ShoppingManagment).
- Katmanlý mimari için gerekli projeler oluþturuldu(Business,Data,Entity).
- Dto nesneleri(Entity/Dto/ProductDto.cs ve MarketDto.cs) yazýldý
- Data Katmanýnda düzenli kod yazýmý için gerekli klasör yapýsý Oluþturuldu(Abstracts,Efcore,Efcore/Config,EfCore/Context,EfCore/Migrations).
- Data Katmanýnda Entity Framework Core(EfCore) için gerekli kütüphaneler yüklendi(Microsoft.EntityFrameworkCore,Microsoft.EntityFrameworkCore.Design,Microsoft.EntityFrameworkCore.SqlServer,Microsoft.EntityFrameworkCore.Tools).
- ApplicationDbContext(Data/EfCore/Context) sýnýfý yazýldý.
- MarketDtoConfig ve ProductDtoConfig (Data/EfCore/Config) sýnýfý yazýldý.
- Api Projesindeki appsettings.json dosyasýna Veritabaný baðlantý metni(Connection string) yazýldý.
- Data Katmanýndaki program.cs implemantasyonlarý için DataExtensions(Data/Utils/Extensions/) sýnýfý oluþturuldu.
- Veritabaný baðlantý metni ile ApplicationDbContext arasýndaki baðlantý kodu (DataExtensions daki ConfigureSqlContextForDataLayer metodu) yazýldý.
- Program.cs ile DataExtensions(Data/Utils) sýnýfý arasýndaki baðlantý kodu(builder.services. ...) yazýldý
- Migrationlarýn Ana Projeye deðil data katmanýnda oluþmasý için gerekli kod parçacýðý eklendi(DataExtensions daki ConfigureSqlContextForDataLayer metodu)
- Ýlk Migration oluþturuldu ve localdeki veri tabaný sunucusuna uygulandý.
- IProductRepository interface i (Data/Abstracts/Product) yazýldý ve fonksiyonlarda kullanýlan nesneler(IProductRepositoryCreateOneProductAsync,IProductRepositoryGetAllAsync,IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync,IProductRepositoryGetOneProductByIdAsync,IProductRepositoryUpdateOneProductAsync),sýnýfýn bulunduðu klasöre oluþturuldu
- ProductRepository sýnýfý(Data/EfCore) yazýldý ve fonksiyonlarýnda kullanýlan nesneler yazýldý(interface aþamasýnda sýnýflarýn içi boþtu,dolduruldu)
- Entity katmanýnda IProductRepository klasörü oluþturuldu ve IProductRepository ile alakalý nesneler(IProductRepositoryCreateOneProductAsync,IProductRepositoryGetAllAsync,IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync,IProductRepositoryGetOneProductByIdAsync,IProductRepositoryUpdateOneProductAsync) klasöre taþýndý.
- MarketRepository sýnýfý yazýldý ve fonksiyonlarda kullanýlan nesneler(IMarketRepositoryCreateOneMarketAsync,IMarketRepositoryGetAllAsync,IMarketRepositoryGetOneMarketByIdAsync,IMarketRepositoryUpdateOneMarketAsync) ayný klasörde oluþturuldu,yazýldý
- IMarketRepository interface i MarketRepository sýnýfýna göre yazýldý.
- Entity katmanýnda IMarketRepository klasörü oluþturuldu ve IMarketRepository ile alakalý nesneler(IMarketRepositoryCreateOneMarketAsync,IMarketRepositoryGetAllAsync,IMarketRepositoryGetOneMarketByIdAsync,IMarketRepositoryUpdateOneMarketAsync) klasöre taþýndý.
- Versiyon kontrol sistemi için README_TR ve README dosyalarý oluþturuldu.
- Readme dosyalarýnýn içeriði yazýldý.
- Versiyon kontrol sistemi(Github) baðlantýsý yapýldý.
- Versiyon kontrol sistemi için gitignore dosyasý oluþturuldu.
### Gün 2 (27.12.2024)
- Business Katmanýnda,düzenli kod yazýmý için gerekli klasör yapýsý Oluþturuldu(Abstracts,Abstracts/Market,Abstracts/Product,Concretes,Concretes/Market,Concretes/Product,Utils,Utils/AutoMapper,Utils/Extensions).
- MappingProfileForBusinessLayer(Business/Utils/AutoMapper) ve ServiceExtensions(Business/Utils/Extensions) sýnýflarý oluþturuldu.
- Business Katmanýnda,AutoMapper kütüphanesi yüklendi ve implementasyon için gerekli kodlar(ServiceExtensions daki setAutoMapperForBusinessLayer) yazýldý.
- Program.cs ile ServiceExtensions(Business/Utils) sýnýfý arasýndaki baðlantý kodu(builder.services. ...) yazýldý.
- Custom Exceptions klasörü oluþturuldu (Entity/Exceptions) ve Custom Exceptions sýnýflarý(BadRequestException,ConflictException,OkException) yazýldý
- IProductService(Business/Abstracts/Product) interface i oluþturuldu.
- ProductService sýnýfý(Business/Concretes/Product) oluþturuldu,sýnýfa bazý fonksiyonlar(getProductWithBarcodeNumberAndMarketId,createProduct,CheckIsAlreadyProductInDb) yazýldý,Bu metotlara özgü nesneler(IProductServiceCreateProduct,IProductServiceGetProductWithBarcodeNumberAndMarketId) yazýldý,gerekli mapleme kodlarý MappingProfileForBusinessLayer(Business/Utils/AutoMapper) sýnýfýna yazýldý
### Gün 3 (28.12.2024)
- ProductService sýnýfýna yeni bir fonksiyon(updateProduct) yazýldý
### Gün 4 (29.12.2024)
- ProductService sýnýfýna yeni bir fonksiyon(deleteProduct) yazýldý
- IProductRepository interface inde kullanýlan fonksiyon sýnýflarý request,response a göre yeniden yazýldý
- IMarketRepository interface inde kullanýlan fonksiyon sýnýflarý request,response a göre yeniden yazýldý
- ProductRepository sýnýfýndaki createOneProductAsync metodunda deðiþiklik yapýldý (id propunun bulunma yönteminin deðiþtirilmesi)
- Readme Dosyasý düzenlendi
- IProductService interface inde kullanýlan fonksiyon sýnýflarý request,response a göre yeniden yazýldý.
- IProductService interface inde kullanýlan fonksiyonlarýn isimlerine Async kelimesi eklendi.
- IProductService interface inde kullanýlan bazý fonksiyonlarýn isimlerine(updateProduct,deleteProduct) Async kelimesi eklendi
- ProductService sýnýfýna göre IProductService interface i yazýldý
- ProductService sýnýfýna,IProductService interface i uygulandý.
- Custom Error Handling sistemi kuruldu,ve kodlara implemantasyonu yapýldý
### Gün 5 (31.12.2024)
- ProductService sýnýfýna parameter null check sistemi yazýldý
- MarketService sýnýfýna yeni bir fonksiyon (createMarketAsync) yazýldý.
- IMarketRepository sýnýfýna yeni bir fonksiyon(getOneMarketByNameAsync) yazýldý.
### Yapýlabilecek þeyler
- ProductService sýnýfýndaki not
- Data katmanýnda notfoundexception kulanýlmasý bir týk mantýksýz