using ExpenseAppRazorPageProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExpenseAppRazorPageProject.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "{0} field cannot be left empty.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The {0} field can have a maximum of {1} and a minimum of {2} characters.")]
        [Display(Name = "UserName", Prompt = "Refik")]
        public string UserName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "{0} field cannot be left empty.")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "The {0} field can have a maximum of {1} and a minimum of {2} characters.")]
        [Display(Name = "Password", Prompt = "******")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var db = new DatabaseContext();

                //? operatörü, UserName değişkeninin null olabileceğini ve eğer null değilse işlemlerin yapılacağını belirtir.

                UserName = UserName?.Trim().ToLower();

                var user = db.Users.SingleOrDefault(x => x.UserName == UserName && x.Password == Password);

                if (user != null)
                {
                    /*
                    
                 1. Kullanıcıların İlk Girişi (Login) ve Oturum Açılması

                        Adım Adım Süreç:

                        Kullanıcı Giriş Formu:
                            Ahmet ve Fırat, giriş (login) formunu doldurup sunucuya bir POST isteği gönderirler. Bu istek, kullanıcı adı ve şifre bilgilerini içerir.

                        Kullanıcı Kimlik Doğrulaması:
                            Sunucu, gelen isteklerdeki kullanıcı adı ve şifre bilgilerini alır ve veritabanında bu bilgileri doğrular.
                            Eğer bilgiler doğruysa, kimlik doğrulaması başarılı olur.

                        Oturum ID'si Oluşturulması:
                            Kimlik doğrulaması başarılı olduktan sonra, sunucu yeni bir oturum (session) başlatır.
                            Sunucu, her kullanıcı için benzersiz bir oturum ID'si (session ID) oluşturur. Bu ID, kullanıcının tarayıcısına bir cookie olarak gönderilir.

                       Oturum Verilerinin Saklanması:
                           Sunucu, oturum verilerini saklamak için oturum ID'sini kullanır. Bu veriler, bellek (in-memory), Redis veya SQL Server gibi bir oturum sağlayıcısında saklanabilir.
                           Oturum verilerine kullanıcı ID'si, kullanıcı adı gibi bilgileri ekler.
                            Örneğin:
                            HttpContext.Session.SetInt32("userid", user.Id);

                       Oturum Cookie'sinin Tarayıcıya Gönderilmesi:
                            Sunucu, oturum ID'sini içeren cookie'yi tarayıcıya gönderir.
                            Tarayıcı, bu cookie'yi saklar ve sonraki tüm isteklerde sunucuya otomatik olarak gönderir.

                2. Sonraki İsteklerde Oturum Tanımlanması ve Yönetimi

                       Adım Adım Süreç:

                       Kullanıcı İsteği Gönderir:
                       Ahmet ve Fırat, giriş yaptıktan sonra sunucuya bir GET veya POST isteği gönderirler.
                       Tarayıcı, bu istekle birlikte oturum ID'sini içeren cookie'yi de sunucuya gönderir.

                       Oturum Middleware'inin Devreye Girmesi:
                       Oturum middleware'i, gelen isteği yakalar(Middleware, gelen istekteki cookie'leri okur ve oturum cookie'sini arar.) ve cookie'deki oturum ID'sini okur.
                       Oturum ID'sini kullanarak oturum sağlayıcısından (örneğin, Redis veya SQL Server) oturum verilerini yükler.

                       Oturum Verilerinin Yüklenmesi:
                       Middleware, oturum ID'sini kullanarak oturum verilerini oturum sağlayıcısından çeker.
                       Yüklenen veriler HttpContext.Session nesnesine atanır.
                       Örneğin:
                       int? userId = HttpContext.Session.GetInt32("userid");

                       Kullanıcının Tanınması:
                       Sunucu, oturum verilerinden kullanıcıyı tanır.
                       Örneğin, userId değerine göre kullanıcının kim olduğunu belirler.
                    
                       Örnek Senaryo:

                       1. Ahmet ve Fırat'ın İlk Girişi:

                       Ahmet giriş yaptı:
                       Ahmet'in kimlik doğrulaması başarılı oldu.
                       Sunucu, Ahmet için yeni bir oturum ID'si (örneğin, sessionId1) oluşturdu.
                       Sunucu, Ahmet'in kullanıcı ID'sini oturuma ekledi ve tarayıcıya sessionId1 cookie'sini gönderdi.
                       Fırat giriş yaptı:
                       Fırat'ın kimlik doğrulaması başarılı oldu.
                       Sunucu, Fırat için yeni bir oturum ID'si (örneğin, sessionId2) oluşturdu.
                       Sunucu, Fırat'ın kullanıcı ID'sini oturuma ekledi ve tarayıcıya sessionId2 cookie'sini gönderdi.
                    
                       2. Sonraki İsteklerde Ahmet ve Fırat'ın Tanınması:

                       Ahmet, giriş yaptıktan sonra bir istek gönderdi:
                       Tarayıcı, istekle birlikte sessionId1 cookie'sini gönderdi.
                       Middleware, sessionId1 kullanarak oturum verilerini yükledi ve HttpContext.Session nesnesine atadı.
                       Sunucu, HttpContext.Session.GetInt32("userid") çağrısı ile Ahmet'in kullanıcı ID'sini aldı ve Ahmet'i tanıdı.
                       Fırat, giriş yaptıktan sonra bir istek gönderdi:
                       Tarayıcı, istekle birlikte sessionId2 cookie'sini gönderdi.
                       Middleware, sessionId2 kullanarak oturum verilerini yükledi ve HttpContext.Session nesnesine atadı.
                       Sunucu, HttpContext.Session.GetInt32("userid") çağrısı ile Fırat'ın kullanıcı ID'sini aldı ve Fırat'ı tanıdı.

                        Not: 
                        Web sunucuları, gelen her HTTP isteğini bağımsız bir iş parçacığında işler. Bu, her isteğin ayrı olarak ele alınmasını ve diğer isteklerden bağımsız olmasını sağlar. Örneğin, iki kullanıcı (Ahmet ve Fırat) aynı anda bir web sayfasına eriştiğinde, her ikisinin isteği de farklı iş parçacıklarında işlenir. 
                        Bu, ASP.NET Core'un her bir isteği bağımsız olarak işlemesini sağlar. Her iş parçacığı, kendi yerel değişkenlerine ve oturum verilerine sahiptir. Ancak, statik değişkenler bu iş parçacıkları arasında paylaşılan verilerdir.
                                       
                     */

                    HttpContext.Session.SetInt32("userid", user.Id);
                    HttpContext.Session.SetString("username", user.UserName);
                    HttpContext.Session.SetString("namesurname", user.NameSurname ?? string.Empty);

                    return RedirectToPage("/Expenses/List");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı ya da şifre eşleşmiyor veya böyle bir kullanıcı bulunmuyor.");
                }
            }
            return Page();
        }
    }

    /*

    Mvc de Post işlemi aşağıdaki gibi olur.

     [HttpPost]
     public ActionResult Login(LoginModel model)
     {
        if (ModelState.IsValid)
        {
            using (var db = new DatabaseContext())
            {
                var userName = model.UserName?.Trim().ToLower();
                var user = db.Users.SingleOrDefault(x => x.UserName == userName && x.Password == model.Password);

                if (user != null)
                {
                    // Oturuma veriler yazılacak.
                    return RedirectToAction("List", "Expenses");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı ya da şifre eşleşmiyor veya böyle bir kullanıcı bulunmuyor.");
                }
            }
        }
        return View(model);
    }

     */
}
