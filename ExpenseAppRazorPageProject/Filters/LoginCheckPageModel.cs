using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExpenseAppRazorPageProject.Entities
{
    public class LoginCheckPageModel : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (context.HttpContext.Session.Keys.Contains("userid") == false)
            {
                context.Result = new RedirectToPageResult("/Login");
                //metot dönüş tipi void olduğu iiçin sadece return diyip metottan çıkmasını istiyorum. Zaten sistem context.Result'un içini dolu görünce yönlendirecek.
                return;
            }
        }
    }
}
