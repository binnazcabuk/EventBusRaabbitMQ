# EventBusRaabbitMQ
EventBusRaabbitMQ-MediatR-AutoMapper-CQRS
<hr>
EventBus yapısını anlamak oluşturulmuş basit bir uygulama.
-Kitap bilgileri mongodb veritabanında tutuluyor.
-Ödünç alma ile ilgili bilgiler mssql veritabanında tutulur.
<hr>
-İki servisin veritabanında kitap ismive kitap id ortak alandır. 
-Veritabanı tutarlılığı için book servisinde kitap isminde yapılan bir güncellemeden borrow servisinin haberdar olması gereklidir.
(Bir kitap isminin güncellenme durumu pek karşılaşılan bir durum olmasada event yapısını basitçe örneklemek için verdiğim bir örnek)

-book servisinde kitap güncellendiği zaman BookChangesNameEvent'ini gönderir.Event içinde ilgili kitapadı ve id bilgisi vardır.

-borrowservis bu event'idinler ve mesaj gelmesi durumunda BookChangesNameEventHandler çalışır. Gelen bilgilerle kendi veritabanında ilgili güncellemeyi yapar.
