using ExpenseAppRazorPageProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseAppRazorPageProject.Pages.Expenses
{
    public class CreateModel : LoginCheckPageModel
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

        public void OnGet()
        {
            Date = DateTime.Now.Date;
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                var db = new DatabaseContext();
                db.Expenses.Add(
                    new Expense
                    {
                        Date = Date,
                        Price = Price,
                        Category = Category,
                        Description = Description,
                        UserId = HttpContext.Session.GetInt32("userid").Value
                    }
                    );

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
