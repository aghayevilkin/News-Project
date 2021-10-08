using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.ViewModels
{
    public class VmProfile : VmBase
    {
        public News.Models.News Post { get; set; }
        public CustomUser User { get; set; }
        public IList<CustomUser> UserS { get; set; }
        public IList<News.Models.News> Posts { get; set; }
        public IList<SavedNews> SavedNews { get; set; }
        public List<NewsTag> Tags { get; set; }
        public VmChangePassword VmChangePassword { get; set; }
        public VmAddPassword VmAddPassword { get; set; }
        public SocialToUser SocialToUser { get; set; }
        public List<NewsCategory> Categories { get; set; }
    }
}
