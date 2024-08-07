using ExpenseAppRazorPageProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseAppRazorPageProject.Pages
{
    public class LogoutModel : LoginCheckPageModel
    {

        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
