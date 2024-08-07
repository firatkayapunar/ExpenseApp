using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppRazorPageProject.Entities
{
    [Table("Expenses")]
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        [StringLength(160)]
        public string Description { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string Category { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
