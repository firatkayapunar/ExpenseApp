*It is an Expense App created by applying the Razor Pages method, one of the application development methods.*
******************************
Solution
******************************
=> I will install EF Core for database operations.
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

=> Here we can use ready-made Login Page pages from Bootsnipp.com.

--Register Page

******************************
Pages/Expenses/
******************************

--List

=> I will use the DataTable library here. To install this, I go to the lib folder under wwwroot and install it.
<br> (<script src="~/lib/datatables/js/jquery.dataTables.min.js"></script>)

=> To use Fake Data, I will download a Fake Data library from Nuget packages. <br> (MFramework.Services.FakeData)

=> I will use Chart.js here. <br> (<script src="htttps://cdn.jsdelivr.net/npm/chart.js"></script>)
<br>
**Note: To install this, I could also install it by going to the lib folder under wwwroot.

--Create

=> Here I will use Toaster.js for the notification that will come after the Save button. wwwroot to install this
I go to the lib folder under it and install it.

---Edit

=> Here I will use Toaster.js for the notification that will come after the Save button. wwwroot to install this
I go to the lib folder under it and install it.

******************************
Pages/Shared/
******************************

--Layout

=> We added the Bootstrap library. <br> (<link *rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />)

=> We added the font awesome library. <br> (<link *rel="stylesheet" href="htttps://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">)

=> We added the jquery library. (Javascript) <br> (<script src="~/lib/jquery/dist/jquery.min.js"></script>)

=>We added the Toastr library.(Javascript) <br> (<script src="~/lib/toastr.js/toastr.min.js"></script>)

=>We added the Bootstrap (Javascript) library. <br> (<script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>)

=>Additionally, we added another Javascript library. <br> (<script src="~/js/site.js" asp-append-version="true"></script>)

***Note: We added toastr settings here.
    
    
