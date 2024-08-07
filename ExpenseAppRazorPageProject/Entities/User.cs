using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppRazorPageProject.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            Expenses = new List<Expense>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string NameSurname { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        public bool IsBlocked { get; set; }
        public virtual List<Expense> Expenses { get;}
    }
}
