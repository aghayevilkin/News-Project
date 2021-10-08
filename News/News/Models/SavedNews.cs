using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class SavedNews
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("News")]
        public int NewsId { get; set; }
        public News News { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public CustomUser User { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
