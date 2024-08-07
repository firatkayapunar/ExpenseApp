******************************
Solution
******************************
=> Veri tabanı işlemleri için EF Core ile ilgili yüklemeler yapacağım.
<br>
*Microsoft.EntityFrameworkCore
<br>
*Microsoft.EntityFrameworkCore.SqlServer
<br>
*Microsoft.EntityFrameworkCore.Tools
<br>
*Microsoft.EntityFrameworkCore.Proxies


******************************
Pages/
******************************

--Login Page

=>Burada Bootsnipp.com sitesinden hazır Login Page sayfalarını kullanabiliriz.

--Register Page

******************************
Pages/Expenses/
******************************

--List

=>Burada DataTable kütüphanesini kullanacağım. Bunu yüklemek için wwwroot
altında lib klasörüne gelerek yüklüyorum. <br> (<script src="~/lib/datatables/js/jquery.dataTables.min.js"></script>)


=>Fake Data kullanmak için Nuget paketlerinden bir Fake Data kütüphanesini indireceğim. (MFramework.Services.FakeData)

=>Burada Chart.js'i kullanacağım. <br> (<script src="htttps://cdn.jsdelivr.net/npm/chart.js"></script>)
<br>
**Not:Bunu yüklemek için wwwroot altında lib klasörüne gelerek de yükleme yapabilirdim.

--Create

=> Burada Save düğmesinden sonra gelecek bildirim için Toaster.js'i kullanacağım. Bunu yüklemek için wwwroot
altında lib klasörüne gelerek yüklüyorum.

---Edit

=> Burada Save düğmesinden sonra gelecek bildirim için Toaster.js'i kullanacağım. Bunu yüklemek için wwwroot
altında lib klasörüne gelerek yüklüyorum.

******************************
Pages/Shared/
******************************

--Layout

=>Bootstrap kütüphanesini ekledik. <br> (<link *rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />)

=>Font awesome kütüphanesini ekledik. <br> (<link *rel="stylesheet" href="htttps://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">)

=>Jquery kütüphanesini ekledik. (Javascript) <br> (<script src="~/lib/jquery/dist/jquery.min.js"></script>)

=>Toastr kütüphanesini ekledik. (Javascript) <br> (<script src="~/lib/toastr.js/toastr.min.js"></script>)

=>Bootstrap(Javascript) kütüphanesini ekledik. <br> (<script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>)

=>Ek olarak bir Javascript kütüphanesi daha ekledik. <br> (<script src="~/js/site.js" asp-append-version="true"></script>)

***Not: Burada toastr ayarlarını ekledik.
    
    
