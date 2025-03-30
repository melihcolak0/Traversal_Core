# :rocket:ASP.NET Core ile Admin ve Kullanıcı Panelli Seyahat Sitesi
Bu repository, Murat Yücedağ'ın Youtube'de bulunan Traversal Rezervasyon Mini Core Projesi kursunu içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

ASP.NET Core Web Application (.NET Core Framework) kullanarak dinamik bir Seyahat sitesi oluşturdum. Bu projede N-Tier Architecture (N Katmanlı Mimari) ve MVC tabanlı bir yapı kullandım. SOLID prensiplerine ve dosya organizasyonuna uygun şekilde geliştirme yaparak kod tekrarını en aza indirmeye çalıştım. Entity Framework Core - Code First yaklaşımını kullanarak veritabanı bağlantılarını oluşturdum. FluentValidation ile doğrulamaları gerçekleştirdim.

N-Tier Architecture (N Katmanlı Mimari), yazılım uygulamalarını birden fazla bağımsız katmana (layer) bölerek geliştirmeye olanak tanıyan bir yazılım mimari modelidir.
Bu mimari, uygulamanın farklı katmanlarını belirleyerek modülerlik, ölçeklenebilirlik ve bakım kolaylığı sağlar.

Genel anlamda 7 katman üzerinde projeyi oluşturdum. Presentation Layer (Sunum Katmanı), kullanıcının doğrudan etkileşimde bulunduğu katmandır. Burada HTML5, CSS3, Bootstrap ve JavaScript kullanarak web sayfaları oluşturdum. Business Logic Layer (İş Mantığı Katmanı), uygulamanın kurallarını ve iş mantığını barındırır. Service ve Manager olarak tüm entity'lerin metotlarını oluşturup kontrollerini yaptım. Data Access Layer (Veri Erişim Katmanı), veritabanı ile etkileşimi sağlar. Burada veri tabanındaki verileri gereken şekilde kullandım. Entity Layer (Varlık Katmanı), verileri saklayan katmandır. Burası Code-First yaklaşımının başlangıcıdır. Veri tabanındaki tablolar ve sütunlar yerine bu katmanda sınıflar ve property'ler kullandım. Bir diğer katman da projeye örnek amaçlı eklediğim API katmanı. Bu katman da uygulamanın diğer istemciler (web, mobil, masaüstü vb.) tarafından erişilebilecek şekilde veri sağlayan bir yapı olarak kullanılır. API Controller bu katmanda HTTP tabanlı istekleri (GET, POST, PUT, DELETE vb.) işleyerek veri alıp gönderen bileşenlerdir. API ile anlık olarak bir siteye giriş yapan kullanıcıların ülkelerini bir grafik üzerinden göstermeye çalıştım. API katmanında oluşturduğum Controller ile API Consume katmanında oluşturduğum View'de API'yi tükettim. Bunun dışında CRUD işlemleri sırasında örnek olarak Fluent Validation işlemlerini uyguladım ve bu sayede daha kontrollü ve profesyonel bir yapı elde ettim. Kullanıcı'ların yönetimini Identity ve Roller ile yaptım. ASP.NET Core Identity, kimlik doğrulama (authentication) ve yetkilendirme (authorization) işlemlerini yönetmek için kullanılan bir sistemdir. Kullanıcı giriş-çıkış işlemlerini, rollerle yetkilendirmeyi ve güvenli parola yönetimini kolaylaştırır.

Bu projede değiştirilmesi gereken bazı noktalar olabilir fakat burada asıl amaç Back-end Development anlamında .Net Core ile admin ve kullanıcı panelli bir sistem kurmaktır. Front-end anlamında düzeltmeler yapılabilir. Ayrıca bu bir eğitim olduğu için tam anlamıyla bir bütünlük kurulmamıştır. Fakat bu eğitimdeki asıl amaç tüm konulardan yola çıkarak tamamen farklı temada bir proje oluşturabilmektir.

Projede genel anlamda 3 farklı bölüm bulunmaktadır;

1- Admin Paneli: Adminler'in giriş yapıp rotalar, yorumlar, deneyimler, hizmetler, mesajlar gibi alanlar ile ilgili CRUD (Create, Read, Update, Delete) işlemlerinin yaptığı bölümdür.  
2- Kullanıcı Paneli: Kullanıcıların sisteme girip mesajlaşma, hesap yönetimi gibi işlemlerini yaptığı bölümdür.  
3- Ana Sayfa: Burada da Melih Çolak ve bu proje ile ilgili bilgiler yer alıyor. Yine tüm kullanıcılar herhangi bir Login işlemi yapmdan bu sayfayı görüntüleyebilir.

## :arrow_forward: Ana Sayfa
Bu eğitimde ilk olarak ana sayfayı oluşturdum. Her kullanıcı bu sayfayı herhangi bir giriş işlemi yapmadan görüntüleyebilir. Bu sayfada benimle ilgili bilgiler bulunmaktadır. Genel anlamda bu sayfa Öne Çıkan, Hakkımda, Hizmetler, Yeteneklerim, Projelerim, Deneyimlerim, Referanslarım ve İletişim bölümlerinden oluşmaktadır.

### :triangular_flag_on_post: Öne Çıkan Bölümü
Öne Çıkan bölümünde ismim, pozisyonum ve sosyal medya hesaplarım yer almaktadır. Bu sayfa, kullanıcıyı karşılayan giriş sayfası olarak düşünülebilir.
<div align="center">
  <img src="https://github.com/melihcolak0/NETCore_Portfolio/blob/c9017bd684dc5e65ee5a89186e79b84a93318a17/ss/showCaseFeature.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Hakkımda Bölümü
Hakkımda bölümünde kendim ile daha detaylı bir bilgi, fotoğrafım ve kişisel bilgilerim yer almaktadır. Telefon numaram, mail üzerinden iletişime geçildiğinde uygun görülürse verilecektir.
<div align="center">
  <img src="https://github.com/melihcolak0/NETCore_Portfolio/blob/c9017bd684dc5e65ee5a89186e79b84a93318a17/ss/showCaseAbout.jpg" alt="image alt">
</div>
