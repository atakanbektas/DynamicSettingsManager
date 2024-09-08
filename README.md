# DynamicSettingsManager

**DynamicSettingsManager**, belirli bir sorunu çözmek amacıyla geliştirilmiş bir uygulamadır. Proje, veritabanına dinamik erişim sağlar ve konfigürasyon yönetimi yaparak gerektiğinde gerçek zamanlı güncellemeler sunar.

## İçindekiler
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Teknolojiler](#teknolojiler)
- [Proje Geliştiricisi](#proje-geliştiricisi)

## Kurulum

Projeyi yerel ortamda çalıştırmak için aşağıdaki adımları izleyin:

1. **Projeyi Local Ortamınıza Klonlayın**:
   ```bash
   git clone https://github.com/atakanbektas/DynamicSettingsManager.git

2. **Persistence Katmanındaki Migrationları uygulayın"**
   ```bash
   2 Adex Context olduğundan Package Manager Console da update-database yerine : 
   Update-Database -Context SettingManagerDBContext
   Update-Database -Context ProductDBContext
   uygulayın
3. **Presentation/MVC projesini çalıştırın**

## Kullanım
   - localhost/config  
     (Konfigurasyon kayıtlarına gider. Ekleme güncelleme filtreleme gibi işlemler yapabilirsiniz.)

   - localhost/product  
     (Ürün sayfasına gider. Sayfanın en üstünde ürün servisine ait kayıtlar listelenir. Eğer config ayarlarında bir değişiklik olursa sayfa yenilemeden ilgili ayarlar güncellenir. Not: Ürünler default değerler ile rastgele oluşturulmuştur.)


## Teknolojiler
- **ASP.NET Core MVC**  
  Web uygulaması geliştirmek için kullanılan framework.
  
- **Entity Framework Core**  
  Veritabanı işlemleri için kullanılan ORM aracı.
  
- **SignalR**  
  Gerçek zamanlı güncellemeler için kullanılan framework.
  
- **In-Memory Cache**  
  Geçici veri saklama için kullanılan cache mekanizması.
  
- **xUnit**  
  Birim testleri için kullanılan test framework'ü.
  
- **Soğan Mimarisi (Onion Architecture)**  
  Katmanlı mimari yapısını destekleyen ve bağımlılıkları azaltan bir mimari.
  
- **Repository Design Pattern**  
  Veritabanı işlemlerini soyutlayarak daha temiz ve sürdürülebilir kod yapısı sağlayan tasarım deseni.
  
- **MSSQL**  
  Projede kullanılan ilişkisel veritabanı yönetim sistemi.


  ### Proje Geliştiricisi
  ATAKAN BEKTAŞ