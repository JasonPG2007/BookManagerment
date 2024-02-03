using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Book ID")]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Please fill in this information.")]
        [Display(Name = "Category Book")]
        public int CategoryId { get; set; }
        [Display(Name = "Book Name")]
        [Required(ErrorMessage = "Please fill in this information.")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "Please fill in this information.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please fill in this information.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please fill in this information.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please fill in this information.")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Please fill in this information.")]
        public decimal Price { get; set; } = 0; // If Charges false, the price will have to be entered other than 0
        [Required(ErrorMessage = "Please fill in this information.")]
        public bool Charges { get; set; }
        [Display(Name = "Date time")]
        public DateTime DateTime { get; set; } = DateTime.Now;
        public virtual CategoryBook? Category { get; set; }
    }
}
