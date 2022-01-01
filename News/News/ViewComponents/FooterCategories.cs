using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.ViewComponents
{
    public class FooterCategories : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        public FooterCategories(SignInManager<IdentityUser> signInManager, AppDbContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<NewsCategory> model = _context.NewsCategories.Include(s => s.NewsSubCategories).ThenInclude(d => d.News).Where(aa => aa.NewsSubCategories.Any(bb => bb.News.Count != 0 && aa.NewsSubCategories.Count != 0)).ToList();

            return View(model);
        }
    }
}
