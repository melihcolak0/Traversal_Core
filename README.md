# :rocket:ASP.NET Core ile Traversal Rezervasyon Sitesi
Bu repository, Murat Yücedağ'ın Youtube'de bulunan Traversal Rezervasyon Mini Core Projesi kursunu içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

ASP.NET Core Web Application (.NET Core Framework) kullanarak dinamik bir Rezervasyon sitesi oluşturdum. Bu projede N-Tier Architecture (N Katmanlı Mimari) ve MVC tabanlı bir yapı kullandım. SOLID prensiplerine ve dosya organizasyonuna uygun şekilde geliştirme yaparak kod tekrarını en aza indirmeye çalıştım. Entity Framework Core - Code First yaklaşımını kullanarak veritabanı bağlantılarını oluşturdum. FluentValidation ile doğrulamaları gerçekleştirdim.

N-Tier Architecture (N Katmanlı Mimari), yazılım uygulamalarını birden fazla bağımsız katmana (layer) bölerek geliştirmeye olanak tanıyan bir yazılım mimari modelidir.
Bu mimari, uygulamanın farklı katmanlarını belirleyerek modülerlik, ölçeklenebilirlik ve bakım kolaylığı sağlar.

Genel anlamda 7 katman üzerinde projeyi oluşturdum. Presentation Layer (Sunum Katmanı), kullanıcının doğrudan etkileşimde bulunduğu katmandır. Burada HTML5, CSS3, Bootstrap ve JavaScript kullanarak web sayfaları oluşturdum. Business Logic Layer (İş Mantığı Katmanı), uygulamanın kurallarını ve iş mantığını barındırır. Service ve Manager olarak tüm entity'lerin metotlarını oluşturup kontrollerini yaptım. Data Access Layer (Veri Erişim Katmanı), veritabanı ile etkileşimi sağlar. Burada veri tabanındaki verileri gereken şekilde kullandım. Entity Layer (Varlık Katmanı), verileri saklayan katmandır. Burası Code-First yaklaşımının başlangıcıdır. Veri tabanındaki tablolar ve sütunlar yerine bu katmanda sınıflar ve property'ler kullandım. Bir diğer katman da projeye örnek amaçlı eklediğim API katmanı. Bu katman da uygulamanın diğer istemciler (web, mobil, masaüstü vb.) tarafından erişilebilecek şekilde veri sağlayan bir yapı olarak kullanılır. API Controller bu katmanda HTTP tabanlı istekleri (GET, POST, PUT, DELETE vb.) işleyerek veri alıp gönderen bileşenlerdir. API ile anlık olarak bir siteye giriş yapan kullanıcıların ülkelerini bir grafik üzerinden göstermeye çalıştım. API katmanında oluşturduğum Controller ile API Consume katmanında oluşturduğum View'de API'yi tükettim. Bunun dışında CRUD işlemleri sırasında örnek olarak Fluent Validation işlemlerini uyguladım ve bu sayede daha kontrollü ve profesyonel bir yapı elde ettim. Kullanıcı'ların yönetimini Identity ve Roller ile yaptım. ASP.NET Core Identity, kimlik doğrulama (authentication) ve yetkilendirme (authorization) işlemlerini yönetmek için kullanılan bir sistemdir. Kullanıcı giriş-çıkış işlemlerini, rollerle yetkilendirmeyi ve güvenli parola yönetimini kolaylaştırır.

API katmanında anlık bilgi akışını sağlamak için de SignalR kullandım. SignalR, Microsoft'un geliştirdiği bir kütüphanedir ve .NET uygulamalarında gerçek zamanlı web fonksiyonelliği sağlar. SignalR, istemci ve sunucu arasında hızlı bir şekilde iki yönlü iletişim kurarak web uygulamaları için anlık veri iletimi sağlar. Özellikle chat uygulamaları, canlı bildirimler, sosyal medya etkileşimleri gibi senaryolarda kullanılır. SignalR, WebSocket gibi teknolojileri kullanarak istemci ile sunucu arasında sürekli bir bağlantı sağlar, ancak WebSocket desteği olmayan tarayıcılar için diğer protokoller de kullanabilir.

Projenin bir bölümünde de CQRS Design Pattern kullandım. CQRS (Command Query Responsibility Segregation - Komut ve Sorgu Sorumluluğu Ayrımı), veri okuma (Query) ve veri yazma (Command) işlemlerini ayrı ayrı ele alarak sistemin ölçeklenebilirliğini, performansını ve bakımını kolaylaştıran bir tasarım desenidir. CQRS'in Temel Mantığı şu şekilde açıklanabilir. Normal bir CRUD modelinde, verileri okumak ve yazmak için genellikle aynı veri modeli ve aynı veri erişim mantığı kullanılır. Ancak, CQRS modelinde okuma ve yazma işlemleri tamamen ayrıdır. Böylece, Komutlar (Commands), sistemde değişiklik yapan işlemlerdir (Insert, Update, Delete). Sorgular (Queries), sistemde değişiklik yapmadan veri çeken işlemlerdir (Select, Get). Okuma işlemleri için ayrı bir model, yazma işlemleri için ayrı bir model kullanılır.

Yine bu projede Unit Of Work tasarım desenine de yer verdik. Unit of Work, bir işlemi mantıksal bir bütün olarak ele alıp tüm veritabanı işlemlerinin tek bir işlem (transaction) içerisinde yönetilmesini sağlayan bir tasarım desenidir. Amaç, birden fazla veri tabanı işleminde tutarlılığı (consistency) sağlamak, bağlantı ve kaynakları verimli kullanmak, veri tabanına gereksiz sorgu gitmesini önlemek. Unit of Work Nasıl Çalışır? Öncelikle işlemler gruplandırılır (Örneğin, bir sipariş oluştururken hem sipariş tablosuna hem de stok tablosuna veri eklenmesi gerekir). Sonrasında bütün işlemler başarılı olursa commit edilir (Veritabanına kalıcı olarak yazılır). Eğer bir hata olursa tüm işlemler geri alınır (rollback) → Böylece veri tutarsızlığı (data inconsistency) önlenir.

Bu projede değiştirilmesi gereken bazı noktalar olabilir fakat burada asıl amaç Back-end Development anlamında .Net Core ile admin ve kullanıcı panelli bir sistem kurmaktır. Front-end anlamında düzeltmeler yapılabilir. Ayrıca bu bir eğitim olduğu için tam anlamıyla bir bütünlük kurulmamıştır. Fakat bu eğitimdeki asıl amaç tüm konulardan yola çıkarak tamamen farklı temada bir proje oluşturabilmektir.

Projede genel anlamda 3 farklı bölüm bulunmaktadır;

1- Admin Paneli: Adminler'in giriş yapıp rotalar, yorumlar, üyeler, duyurular, mesajlar ve rehberler gibi alanlar ile ilgili CRUD (Create, Read, Update, Delete) işlemlerinin yaptığı bölümdür.  
2- Üye Paneli: Kullanıcıların sisteme girip yeni rotalar, hesap yönetimi ve rezervasyon gibi işlemlerini yaptığı bölümdür.  
3- Vitrin Paneli: Burada da Traversal seyahat acentasının rotalarını, rehberlerini, firma iletişim bilgilerini yayınladığı bölümdür.

## :arrow_forward: Vitrin Paneli
Bu eğitimde ilk olarak vitrin panelini oluşturdum. Her kullanıcı bu sayfayı herhangi bir giriş işlemi yapmadan görüntüleyebilir. Bu sayfada rotalar, rehberler ve firma ile ilgili bilgiler bulunmaktadır. Genel anlamda bu sayfa Ana Sayfa, Rotalar, Rehberler ve İletişim bölümlerinden oluşmaktadır.

### :triangular_flag_on_post: Ana Sayfa Bölümü
Ana Sayfa bölümünde müşteriler tarafından sık seyahat edilen rotalar listelenmektedir. Kullanıcılar bu rotaları görüp detaylarını inceleyebilirler. Aynı zamanda istististiki bilgiler ve müşteri yorumları da yer almaktadır.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/vitrineHome1.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/vitrineHome2.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/vitrineHome3.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/vitrineHome4.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/vitrineHome5.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Rotalar Bölümü
Rotalar bölümünde o anda aktif olan seyahat rotaları listelenmiş bir şekilde gösterilemktedir. Kullanıcı fotoğraflar üzerine tıklayarak ilgili rota hakkında detaylı bilgi edinebilir. Detaylarda rota hakkında bilgiler, fotoğraflar, rehber ve müşteri yorumları, son olarak da rota hakkında yorum yazma bölümü bulunmaktadır.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/vitrineDest.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c16333746069959d0362e4fbc5f99623f59745fd/ss2/vitrineDestDet1.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c16333746069959d0362e4fbc5f99623f59745fd/ss2/vitrineDestDet2.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c16333746069959d0362e4fbc5f99623f59745fd/ss2/vitrineDestDet3.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c16333746069959d0362e4fbc5f99623f59745fd/ss2/vitrineDestDet4.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Rehberler Bölümü
Rehberler bölümünde Traversal acentasında aktif olarak çalışan rehberler ve rehberlerin çalıştığı rotalar görülmektedir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/vitrineGuide.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: İletişim Bölümü
Rehberler bölümünde Traversal acentasında aktif olarak çalışan rehberler ve rehberlerin çalıştığı rotalar görülmektedir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/vitrineContact.jpg" alt="image alt">
</div>

## :arrow_forward: Admin Paneli
Bu eğitimde ikinci olarak admin panelini oluşturdum. Admin, vitrin panelindeki bilgiler, rotalar, yorumlar, üyeler, rehberler gibi bölümlerin CRUD işlemlerini yapmakla görevlendirilmiştir.

### :triangular_flag_on_post: Dashboard Bölümü
Dashboard bölümünde Traversal acentasının hesapları ile ilgili istatistiki bilgiler yer almaktadır.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/adminDashboard.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Rotalar Bölümü
Rotalar bölümünde Admin, aktif olarak hangi rotaların olduğunu belirler ve bu rotalar hakkında değişiklik yapar.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/adminDestination.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Yorumlar Bölümü
Yorumlar bölümünde Admin, rotalar hakkında yapılmış tüm yorumları görebilir ve bunlar üzerinde görüntüleme ve silme işlemlerini yapabilir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/adminComment.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Üyeler Bölümü
Üyeler bölümünde Admin, siteye kayıt olmuş olan üyelerin yorumnları ve geçmiş rezervasyonları gibi bilgileri görülmektedir. Ayrıca üyeler üzerine düzenleme ve silme işlemleri de yapılabilmektedir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/adminMembers.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Duyurular Bölümü
Duyurular bölümünde Admin, kullanıcılara iletmek istediği önemli bilgileri bu bölümden kullanıcılara iletebilir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/adminAnnouncement.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Mesajlar Bölümü
Mesajlar bölümünde Admin, vitrin panelinde bulunan bize ulaşın ksımından gönderieln mesajları görebilir ve silebilir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/adminContactUs.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Rehberler Bölümü
Rehberler bölümünde Admin, rehberler ile ilgilisilme ve güncelleme işlemleri yapabilir. Aynı zamanda rehberin rotalarını düzenleyebilir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/adminGuide.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Rol İşlemleri Bölümü
Rehberler bölümünde Admin, rehberler ile ilgilisilme ve güncelleme işlemleri yapabilir. Aynı zamanda rehberin rotalarını düzenleyebilir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/adminRoles.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Çıkış Yap Bölümü
Çıkış Yap bölümünde admin düz kullanıcı rolüne geri döner ve sitedeki bazı özellikleri kullanamaz hale gelir.

## :arrow_forward: Üye Paneli
Bu eğitimde son olarak üye panelini oluşturdum. Üyeler, bu panel üzerinde kendi hakkında bilgiler, rehberler ve aktif rotalar ve kendi rezervasyonları gibi bilgileri görebilir.

### :triangular_flag_on_post: Dashboard Bölümü
Dashboard bölümünde üyeler, kendi bilgilerini rehberleri ve son eklenen rotaları görüntüleyebilir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/memberDashboard.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/memberDashboard2.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Rotalar Bölümü
Rotalar bölümünde üyeler, aktif rotaları görüntülemeyi ve rota detaylarına ulaşımı sağlayabilir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/memberDestinations.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Profil Bölümü
Profil bölümünde üyeler, kendi bilgilerini görüntüleyebilir, şifre ve bilgi güncellemesi yapabilir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/memberProfile.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Rezervasyonlarım Bölümü
Rezervasyonlarım bölümü dört farklı ayrı bölümden oluşuyor. Geçmiş, onaylanmış ve onaylanmayı bekleyen ve yeni rezervasyon oluşturma olarak dört farklı bölüm bulunmaktadır. Geçmiş, onaylanmış ve onaylanmayı bekleyen rezervasyonlar görüntülenebilirken yeni bir rezervasyon da oluşturulabilir ve yeni oluşturulan rota doğrudan onay bekleyen listesinde görüntülenir. Acenta tarafından onaylanması beklenir.
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/memberResrv1.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/memberResrv2.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/memberResrv3.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/c00bd4d6fd8d8fcfe7b60a96ca49e62df14e1776/ss/memberResrv4.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Siteye Git Bölümü
Siteye Git bölümünde kullanıcı vitrin paneline gidebilir.

### :triangular_flag_on_post: Çıkış Yap Bölümü
Çıkış Yap bölümünde kullanıcı düz kullanıcı rolüne geri döner ve sitedeki bazı özellikleri kullanamaz hale gelir.

## :arrow_forward: Giriş Yapma Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/5be6bad1ad0107e00ee0598e486cdb3f32a9cf60/ss3/login.jpg" alt="image alt">
</div>

## :arrow_forward: Kayıt Olma Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/5be6bad1ad0107e00ee0598e486cdb3f32a9cf60/ss3/register.jpg" alt="image alt">
</div>

## :arrow_forward: Hata Sayfası
<div align="center">
  <img src="https://github.com/melihcolak0/Traversal_Core/blob/5be6bad1ad0107e00ee0598e486cdb3f32a9cf60/ss3/error.jpg" alt="image alt">
</div>
