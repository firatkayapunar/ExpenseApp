******************************
Solution
******************************
=> Veri tabanı işlemleri için EF Core ile ilgili yüklemeler yapacağım.
*Microsoft.EntityFrameworkCore
*Microsoft.EntityFrameworkCore.SqlServer
*Microsoft.EntityFrameworkCore.Tools
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
--Burada DataTable kütüphanesini kullanacağım. Bunu yüklemek için wwwroot
altında lib klasörüne gelerek yüklüyorum. (<script src="~/lib/datatables/js/jquery.dataTables.min.js"></script>)

--Fake Data kullanmak için Nuget paketlerinden bir Fake Data kütüphanesini
indireceğim. (MFramework.Services.FakeData)

--Burada Chart.js'i kullanacağım.(<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>)
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

=>Bootstrap kütüphanesini ekledik. (<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />)

=>Toastr kütüphanesini ekledik. (<link href="~/lib/toastr.js/toastr.min.css" rel="stylesheet" />)

=>Font awesome kütüphanesini ekledik. (<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">)

=>Jquery kütüphanesini ekledik. (Javascript) (<script src="~/lib/jquery/dist/jquery.min.js"></script>)

=>Toastr kütüphanesini ekledik. (Javascript) (<script src="~/lib/toastr.js/toastr.min.js"></script>)

=>Bootstrap(Javascript) kütüphanesini ekledik. (<script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>)

=>Ek olarak bir Javascript kütüphanesi daha ekledik. (<script src="~/js/site.js" asp-append-version="true"></script>)
***Not: Burada toastr ayarlarını ekledik.
    
    
