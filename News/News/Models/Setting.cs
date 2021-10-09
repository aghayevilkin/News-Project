using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        [MaxLength(250, ErrorMessage = "Maksimum 250 charakter daxil edə bilərsiniz"), Required(ErrorMessage = "Phone boş olmamalıdır!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Footer boş olmamalıdır!")]
        public string Footer { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
