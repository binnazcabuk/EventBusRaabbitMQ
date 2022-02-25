# EventBusRaabbitMQ
<hr>
EventBus yapısını anlamak oluşturulmuş basit bir uygulama.
-Kitap bilgileri mongodb veri tabanında tutuluyor.
-Ödünç alma ile ilgili bilgiler mssql veritabanında tutulur.
<hr>

![Swagger-UI-Google-Chrome-2022-02-25-17-05-28](https://user-images.githubusercontent.com/34273337/155729612-b1be6872-5680-4010-93f8-495c3ace13ec.gif)

![DBeaver-21 3 3-Borrows-2022-02-25-17-06-06](https://user-images.githubusercontent.com/34273337/155729525-c23f8300-83df-40a5-9b93-ecd4be79b0a1.gif)

<hr>
-İki servisin veritabanında kitap ismi ve kitap id ortak alandır. 
-Veritabanı tutarlılığı için book servisinde kitap isminde yapılan bir güncellemeden borrow servisinin haberdar olması gereklidir.
(Bir kitap isminin güncellenme durumu pek karşılaşılan bir durum olmasada event yapısını basitçe örneklemek için verdiğim bir örnek)

-book servisinde kitap güncellendiği zaman BookChangesNameEvent'ini gönderir.Event içinde ilgili kitapadı ve id bilgisi vardır.

-borrowservis bu event'idinler ve mesaj gelmesi durumunda BookChangesNameEventHandler çalışır. Gelen bilgilerle kendi veritabanında ilgili güncellemeyi yapar.
