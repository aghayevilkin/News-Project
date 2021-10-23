using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using News.Data;
using News.Models;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }


        public IActionResult Index()
        {
            TempData["Controller"] = "Home";
            var userId = _userManager.GetUserId(User);
            ViewBag.UserId = userId;
            VmBase model = new VmBase()
            {
                News = _context.News.Include(saved => saved.SavedNews).Include(lord=>lord.LikeAndDislikes).Include(u => u.User).ThenInclude(us => us.SocialToUsers).ThenInclude(soc => soc.Social).Include(scc=>scc.Category).ThenInclude(scs=>scs.NewsCategory).OrderByDescending(added=>added.AddedDate).ToList(),
                Categories = _context.NewsCategories.Include(s => s.NewsSubCategories).ThenInclude(d => d.News).Where(aa => aa.NewsSubCategories.Any(bb => bb.News.Count != 0 && aa.NewsSubCategories.Count != 0)).ToList(),
            };

            return View(model);
        }

    }
}
