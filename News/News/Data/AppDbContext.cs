using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<SocialToUser> SocialToUsers { get; set; }
        public DbSet<News.Models.News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<NewsSubCategory> NewsSubCategories { get; set; }
        public DbSet<NewsComment> NewsComments { get; set; }
        public DbSet<NewsTag> NewsTags { get; set; }
        public DbSet<TagToNews> TagToNews { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<SavedNews> SavedNews { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<LikeAndDislike> LikeAndDislikes { get; set; }

    }
}
