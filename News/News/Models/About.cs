using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class About
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "Maksimum 30 charakter daxil edə bilərsiniz"), Required(ErrorMessage = "Title boş olmamalıdır!")]
        public string Title { get; set; }

        [Column(TypeName = "ntext"), Required(ErrorMessage = "Content boş olmamalıdır!")]
        public string Content { get; set; }
    }
}
