using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string Penname { get; set; }

        [Display(Name = "Preferred Genre")]
        public string PreferredGenre { get; set; }

        [Display(Name = "Created By")]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Created By")]
        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
