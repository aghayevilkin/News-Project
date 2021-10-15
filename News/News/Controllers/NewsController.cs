using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Models;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class NewsController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public NewsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index(int? id, int? tagId, int? year, int? month, VmNews VmFilter, string searchData, int page = 1)
        {
            var userId = _userManager.GetUserId(User);
            TempData["Controller"] = "News";

            decimal pageItemCount = 6;
            ViewBag.Page = "blog";
            ViewBag.UserId = userId;


            ViewBag.categoryId = id;
            IList<News.Models.News> newss = _context.News.Include(saved => saved.SavedNews).Include(u => u.User).ThenInclude(us => us.SocialToUsers).ThenInclude(soc => soc.Social).Include(scc=>scc.Category).ThenInclude(scs=>scs.NewsCategory).Where(b => (id != null ? b.CategoryId == id : true) &&
                                                                (tagId != null ? b.TagToNews.Any(t => t.TagId == tagId) : true) &&
                                                                (year != null ? b.AddedDate.Year == year : true) &&
                                                                (month != null ? b.AddedDate.Month == month : true) &&
                                                                (b.NewsStatus == NewsStatus.Active)
                                                          ).Where(sr =>
                                                                  ((searchData != null ? sr.Title.Contains(searchData) : true) || (searchData != null ? sr.Category.Name.Contains(searchData) : true)) &&
                                                                  (VmFilter.catId != null ? sr.CategoryId == VmFilter.catId : true))
                                                     .ToList();


            decimal b = Math.Ceiling(newss.Count / pageItemCount);
            ViewBag.PageCount = Convert.ToInt32(b);
            ViewBag.ActivePage = page;
            ViewBag.prewPage = page - 1;
            ViewBag.nextPage = page + 1;

            List<News.Models.News> products = newss.OrderBy(p => p.Id)
                                                     .OrderByDescending(added => added.AddedDate).Skip((page - 1) * (int)pageItemCount).Take((int)pageItemCount)
                                                     .ToList();
            VmNews model = new VmNews()
            {
                News = products,
                RecentPost = _context.News.Include(c => c.User).Where(s => s.NewsStatus == NewsStatus.Active).OrderByDescending(o => o.AddedDate).Take(4).ToList(),
                Categories = _context.NewsCategories.Include(b => b.NewsSubCategories).Where(bb => bb.News.Any(s => s.NewsStatus == NewsStatus.Active)).ToList(),
                Comments = _context.NewsComments.ToList(),
                Tags = _context.NewsTags.Include(b => b.TagToNews).ThenInclude(bl => bl.News).ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
            };

            return View(model);
        }
        


        public IActionResult Details()
        {
            TempData["Controller"] = "NewsDetails";
            return View();
        }





        public JsonResult addToBookmarked(int? newsId)
        {
            var userId = _userManager.GetUserId(User);
            if (newsId == null)
            {
                return Json(404);
            }

            bool isExist = _context.SavedNews.Any(aa => aa.NewsId == newsId && aa.UserId == userId);

            if (!isExist)
            {
                SavedNews model = new SavedNews()
                {
                    NewsId = (int)newsId,
                    UserId = userId,
                    AddedDate = DateTime.Now,
                };

                _context.SavedNews.Add(model);
                _context.SaveChanges();
            }
            else
            {
                return Json(404);
            }



            return Json(200);
        }

        public JsonResult removeFromBookmarked(int? newsId)
        {
            var userId = _userManager.GetUserId(User);
            if (newsId == null)
            {
                return Json(404);
            }

            bool isExist = _context.SavedNews.Any(aa => aa.NewsId == newsId && aa.UserId == userId);

            if (isExist)
            {
                SavedNews model = _context.SavedNews.FirstOrDefault(aa => aa.NewsId == newsId && aa.UserId == userId);

                _context.SavedNews.Remove(model);
                _context.SaveChanges();
            }
            else
            {
                return Json(404);
            }
            return Json(200);
        }


    }
}
