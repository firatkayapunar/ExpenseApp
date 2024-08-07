using ExpenseAppRazorPageProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;


namespace ExpenseAppRazorPageProject.Pages.Expenses
{
    public class ListModel : LoginCheckPageModel
    {
        public List<Expense> Expenses { get; set; } = new List<Expense>();
        public void OnGet()
        {
            var databaseContext = new DatabaseContext();

            if (HttpContext.Session.GetInt32("userid") != null)
            {
                int userId = HttpContext.Session.GetInt32("userid").Value;

                Expenses = databaseContext.Expenses.Where(x => x.UserId == userId).ToList();
            }
        }

        public IActionResult OnGetDelete(int id)
        {
            var databaseContext = new DatabaseContext();

            int userId = HttpContext.Session.GetInt32("userid").Value;

            var expense = databaseContext.Expenses.SingleOrDefault(x => x.Id == id && x.UserId == userId);

            if (expense != null)
            {
                databaseContext.Expenses.Remove(expense);
                databaseContext.SaveChanges();
            }

            return RedirectToPage("List");
        }
    }
}
