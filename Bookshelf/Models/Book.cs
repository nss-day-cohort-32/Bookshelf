using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Published Date")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual Author Author { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
