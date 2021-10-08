using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class TagToNews
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("News")]
        public int NewsId { get; set; }
        public News News { get; set; }


        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public NewsTag Tag { get; set; }
    }
}
