using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewsCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name boş olmamalıdır!")]
        public string Name { get; set; }

        public List<News> News { get; set; }
        public List<NewsSubCategory> NewsSubCategories { get; set; }

    }
}
