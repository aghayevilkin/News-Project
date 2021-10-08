using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewsComment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(2000)]
        public string Message { get; set; }
        public int NewsId { get; set; }

        [ForeignKey("NewsId")]
        public News News { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public CustomUser User { get; set; }

        public int? CommentId { get; set; }
        [ForeignKey("CommentId")]
        public NewsComment ParentComment { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
