using ExpenseAppRazorPageProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExpenseAppRazorPageProject.Pages.Expenses
{
    public class EditModel : LoginCheckPageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "{0} field cannot be left empty.")]
        [Display(Name = "Date", Prompt = "01.01.2021 20:30")]
        public DateTime Date { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0} field cannot be left empty.")]
        [Display(Name = "Price", Prompt = "10,00")]
        public decimal Price { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0} field cannot be left empty.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The {0} field can have a maximum of {1} and a minimum of {2} characters.")]
        [Display(Name = "Category", Prompt = "Transport")]
        public string Category { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "{0} field cannot be left empty.")]
        [StringLength(160, ErrorMessage = "The field {0} can have a maximum of {1} characters.")]
        [Display(Name = "Description", Prompt = "")]
        public string Description { get; set; }

        [BindProperty]
        public int Id { get; set; }
        public IActionResult OnGet(int id)
        {
            int userId = HttpContext.Session.GetInt32("userid").Value;

            var db = new DatabaseContext();
            var expense = db.Expenses.SingleOrDefault(x => x.Id == id && x.UserId == userId);

            if (expense == null)
                return RedirectToPage("List");

            Id = expense.Id;
            Date = expense.Date;
            Category = expense.Category;
            Price = expense.Price;
            Description = expense.Description;

            return Page();
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {

                int userId = HttpContext.Session.GetInt32("userid").Value;

                var db = new DatabaseContext();
                var expense = db.Expenses.SingleOrDefault(x => x.Id == Id && x.UserId == userId);

                expense.Date = Date;
                expense.Category = Category;
                expense.Price = Price;
                expense.Description = Description;


                if (db.SaveChanges() > 0)
                    ViewData["result"] = "ok";
                else
                    ViewData["result"] = "error";
            }
            else
                ViewData["result"] = "error";
        }
    }
}
