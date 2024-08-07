using ExpenseAppRazorPageProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExpenseAppRazorPageProject.Pages
{
    public class RegisterModel : PageModel
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
        [BindProperty]
        [Required(ErrorMessage = "{0} field cannot be left empty.")]
        [Compare(nameof(Password), ErrorMessage = "Field {0} does not match field {1}.")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "The {0} field can have a maximum of {1} and a minimum of {2} characters.")]
        [Display(Name = "RePassword", Prompt = "******")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var db = new DatabaseContext();

                UserName = UserName?.Trim().ToLower();

                var user = db.Users.SingleOrDefault(x => x.UserName == UserName);

                if (user == null)
                {
                    user = new User
                    {
                        UserName = UserName,
                        Password = Password
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    return RedirectToPage("Login");
                }
                else
                {
                    ModelState.AddModelError(nameof(UserName), "Bu kullanıcı adı zaten kullanılıyor.");
                }
            }

            return Page();
        }
    }
}
