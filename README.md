# ToDoPlanning Project
Uygulama veri tabanından aldığı görevleri geliştiricilere atar ve data sonra bu dataları ekrana yazdırır. Uygulama katmanlı mimari kullanılarak .Net Core ile yazılmıştır.

## Kullanılan Teknolojiler
.Net Core
Postgresql
Docker
MVC
YamlDotNet
Dependecy Injection
Makefile

### Console Application
Mock API lardan gelen dataları database e kayıt eder.
### Data
Bu katmanda database modelleri ve dbContext tanımlanmıştır , veritabanına kayıt ekleyen ve kayıt çeken metodlar buradadır.
### Models
Bu katmanda API lerin response modelleri ve ekrana yazdırılacak modeller tanımlanmıştır.
### Business
Uygulamanın genel iş akışını gerçekleşecek metodlar burada tanımlanmıştır.
### Web Application
Bu katmanda gerekli konfigursayon ayarlamaları ve kullanıcıya verileri gösterme işlemleri yapılmıştır.

### Uygulama Nasıl Çalışır?

#### Terminal
`ToDoPlanning.Web` projesi içinde olduğunuzdan emin olun.
Bilgisayarınızda `Docker` yüklü olmalıdır.
`make database-setup` komutu ile postgresql i hazırlıyoruz.
`make create-migration` komutu ile migration oluşturuyoruz.
`make update-database` komutu migrationu uygular ve veritabanı hazır hale gelir.
`make run-console` Console uygulamasını başlatarak mock servislerden dataları database e kayıt eder.
`make run-web` web uygulamasını başlatır ve anasayfada verileri görebilirsiniz.
Her hangi bir browserdan `http://localhost:5163/` adresine gittiğinizde ekranda atanan taskları ve kaç hafta süreceğini görebilirsiniz.

#### IDE
Eğer her hangi bir `IDE` üzerinde çalıştırmak istiyorsanız. `Docker` in yüklü olduğundan emin olun ve connectionStringde ki database ayarlarını yapın.
Ilk olarak Console uygulamasını çalıştırın ve ardından Web uygulamasını çalıştırın.




