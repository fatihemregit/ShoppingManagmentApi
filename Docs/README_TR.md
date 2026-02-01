# 🛒  Shopping Management API

[![DotNet](https://img.shields.io/badge/.NET-5.0+-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

[**English**](https://github.com/fatihemregit/ShoppingManagmentApi/blob/master/README.md) | [**Türkçe**](https://github.com/fatihemregit/ShoppingManagmentApi/blob/master/Docs/README_TR.md)

## 🇹🇷 Türkçe

### 📝 Proje Hakkında
**Shopping Management API**, market alışverişi sırasında yaşanan "hesap makinesi ameleliğini" ortadan kaldırmak için geliştirilmiş bir backend çözümüdür. Barkod tarama yoluyla ürün fiyatlarının anlık takibini sağlar ve sepet tutarını otomatik olarak hesaplar.

### 💡 Projenin Hikayesi (Kişisel Bir Problem)
Bu proje tamamen kişisel bir ihtiyaçtan doğdu. Market alışverişi yaparken ürünlerin ne kadar tuttuğunu telefonun hesap makinesinden tek tek toplamak hem yorucu hem de hata yapmaya çok müsaitti.

Bu sorunu çözmek için bu API'yi geliştirdim. Şu an sadece benim kullandığım bir mobil uygulama ile bu API'yi besliyorum. Sadece ürünün barkodunu okutuyorum; fiyat değiştiyse güncelliyor ve o anki sepetimin toplam tutarını anında görebiliyorum. Bu sistem, alışveriş sürecini çok daha hızlı ve kontrol edilebilir kılıyor.

### 🚀 Kullanım Senaryosu
1.  **Markette:** Bir ürün aldınız ve mobil uygulama üzerinden barkodunu okuttunuz.
2.  **Anlık Senkronizasyon:** Uygulama, bu API üzerinden ürünün sistemdeki son fiyatını getirir.
3.  **Fiyat Güncelleme:** Eğer raftaki fiyat farklıysa, o an güncelleyerek sistemin güncel kalmasını sağlarsınız.
4.  **Canlı Toplam:** Ürün ekledikçe API "Alışveriş Oturumunu" yönetir ve kasaya gitmeden ödeyeceğiniz tutarı net olarak söyler.

### 🛠 Teknoloji Yığını
* **Framework:** .NET / ASP.NET Core
* **Veritabanı:** PostgreSQL / MS SQL Server
* **ORM:** Entity Framework Core
* **Mimari:** RESTful API

### 🔧 Kurulum
1.  **Projeyi klonlayın:**
    ```bash
    git clone [https://github.com/fatihemregit/ShoppingManagmentApi.git](https://github.com/fatihemregit/ShoppingManagmentApi.git)
    ```
2.  **Yapılandırma:** `appsettings.json` dosyasındaki veritabanı bağlantı adresini (Connection String) düzenleyin.
3.  **Migration Uygulama:**
    ```bash
    dotnet ef database update
    ```
4.  **Çalıştır:**
    ```bash
    dotnet run
    ```

### 🗺 Gelecek Planları (Yol Haritası)
* **Refactoring:** Kod kalitesinin artırılması ve performans iyileştirmeleri.
* **Fiyat Analizi:** Ürünlerin zaman içindeki zam oranlarını hesaplama (Örn: Bir ürünün Ocak 2025 - Haziran 2025 arası fiyat değişim yüzdesi).
* **Gelişmiş İstatistikler:** Aylık harcama raporları ve kategori bazlı analizler.
Developed by [Fatih Emre KILINÇ](https://github.com/fatihemregit)

[Proje geliştirilme süreci](https://github.com/fatihemregit/ShoppingManagmentApi/blob/master/Docs/projectLogs/TR_project_log.md)