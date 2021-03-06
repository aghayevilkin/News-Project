using Microsoft.AspNetCore.Authentication;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.ViewModels
{
    public class VmBase
    {
        public VmLogin LoginViewModel { get; set; }
        public VmRegister RegisterViewModel { get; set; }
        public List<Social> Socials { get; set; }
        public List<News.Models.News> News { get; set; }
        public List<News.Models.News> LatestArticles { get; set; }
        public List<NewsTag> Tags { get; set; }
        public List<Message> Messages { get; set; }
        public List<LikeAndDislike> LikeAndDislikes { get; set; }
        public List<Subscribe> Subscribes { get; set; }
        public CustomUser CustomUser { get; set; }
        public Setting Setting { get; set; }
        public About About { get; set; }
        public List<NewsCategory> Categories { get; set; }


        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
