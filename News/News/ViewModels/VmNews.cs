using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.ViewModels
{
    public class VmNews:VmBase
    {
        public News.Models.News New { get; set; }
        public List<News.Models.News> RecentPost { get; set; }
        public List<NewsSubCategory> NewsSubCategories { get; set; }
        public List<NewsComment> Comments { get; set; }
        public NewsComment Comment { get; set; }
        public List<NewsTag> Tags { get; set; }
        public List<SavedNews> SavedBlogs { get; set; }
        public VmNews Filter { get; set; }
        public int? catId { get; set; }
    }
}
