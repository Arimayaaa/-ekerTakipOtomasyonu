 Şeker Takip Otomasyonu (Desktop App)
Bu proje, bir şeker fabrikası veya dağıtım merkezinin stok yönetimini, randevu sistemini ve operasyonel süreçlerini dijitalleştirmek amacıyla geliştirilmiş bir Windows Form Application (C#) uygulamasıdır. Özellikle Türk Şeker Genel Müdürlüğü bünyesinde yaptığım staj süresince gözlemlediğim ihtiyaçlar doğrultusunda, karmaşık veritabanı süreçlerini kullanıcı dostu bir arayüzle yönetmek için tasarlanmıştır.

=> Öne Çıkan Özellikler
Dinamik Filtreleme: Fabrika ve bölge seçimlerine göre (ComboBox etkileşimi) verilerin veritabanından dinamik olarak getirilmesi.

Randevu Yönetimi: Fabrikalara ait randevu süreçlerinin takibi ve veritabanı üzerinden güncellenmesi.

Veritabanı Entegrasyonu: ADO.NET kullanılarak SQL Server ile güvenli ve performanslı veri alışverişi.

Hata Yönetimi (Error Handling): try-catch blokları ile veritabanı bağlantı hatalarının yönetilmesi ve kullanıcıya anlamlı geri bildirimler sunulması.

Katmanlı Mimari Yaklaşımı: Veritabanı bağlantı kodlarının (veritabaniBag.cs) ve iş mantığının birbirinden ayrıştırılması.

=> Teknik Detaylar
Dil: C# (.NET Framework)

Arayüz: Windows Forms (WinForms)

Veritabanı: Microsoft SQL Server

Mimari: Nesne Yönelimli Programlama (OOP), ADO.NET Data Access.

📂 Proje Yapısı
Form1.cs / Form2.cs: Kullanıcı etkileşimlerinin ve arayüz kontrollerinin bulunduğu ana formlar.

veritabaniBag.cs: SQL bağlantı dizesini yöneten ve sorguları çalıştıran merkezi sınıf.

randevuislemleri.cs: İş mantığına (Business Logic) özel operasyonel kodlar.



veritabaniBag.cs içerisindeki Connection String (Bağlantı Adresi) kısmını kendi yerel SQL Server adresinize göre güncelleyin.

Projenin çalışması için gerekli SQL tablolarını oluşturun (Sorgu dosyaları yakında eklenecektir).
