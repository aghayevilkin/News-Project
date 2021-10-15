using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(500), Required(ErrorMessage = "Title boş olmamalıdır!")]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Column(TypeName = "ntext"), Required(ErrorMessage = "Content boş olmamalıdır!")]
        public string Content { get; set; }
        public DateTime AddedDate { get; set; }

        public NewsStatus NewsStatus { get; set; }

        [Required(ErrorMessage = "Category Secmelisiniz!")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public NewsSubCategory Category { get; set; }
        [NotMapped]
        public int[] TagIds { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CustomUser User { get; set; }
        public List<NewsComment> Comments { get; set; }
        public List<TagToNews> TagToNews { get; set; }
        public List<SavedNews> SavedNews { get; set; }
    }
}
