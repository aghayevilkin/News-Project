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

        public IActionResult Index(int? id, int? cateId, int? tagId, int? year, int? month, VmNews VmFilter, string searchData, int page = 1)
        {
            var userId = _userManager.GetUserId(User);
            TempData["Controller"] = "News";
            ViewBag.Page = "news";
            decimal pageItemCount = 6;
            ViewBag.Page = "news";
            ViewBag.UserId = userId;

            

            ViewBag.categoryId = id;
            ViewBag.subcategoryId = cateId;
            IList<News.Models.News> newss = _context.News.Include(saved => saved.SavedNews).Include(lord=>lord.LikeAndDislikes).Include(u => u.User).ThenInclude(us => us.SocialToUsers).ThenInclude(soc => soc.Social).Include(scc=>scc.Category).ThenInclude(scs=>scs.NewsCategory).Where(b => (id != null ? b.Category.NewsCategoryId == id : true) && (cateId != null ? b.CategoryId == cateId : true) &&
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
                Categories = _context.NewsCategories.Include(s=>s.NewsSubCategories).ThenInclude(d=>d.News).Where(aa=>aa.NewsSubCategories.Any(bb=>bb.News.Count != 0 && aa.NewsSubCategories.Count != 0)).ToList(),
                NewsSubCategories = _context.NewsSubCategories.Include(nc=>nc.NewsCategory).Include(b => b.News).Where(bb => bb.News.Any(s => s.NewsStatus == NewsStatus.Active)).ToList(),
                Comments = _context.NewsComments.ToList(),
                Tags = _context.NewsTags.Include(b => b.TagToNews).ThenInclude(bl => bl.News).ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
            };

            return View(model);
        }
        


        public IActionResult Details(int id)
        {
            TempData["Controller"] = "NewsDetails";
            ViewBag.Page = "news";
            int catId = _context.News.Find(id).CategoryId;
            var userIdd = _userManager.GetUserId(User);
            var newsUser = _context.News.Find(id).UserId;
            ViewBag.categoryId = catId;
            VmNews model = new VmNews()
            {
                New = _context.News.Include(t => t.TagToNews).ThenInclude(t => t.Tag).Include(u => u.User).ThenInclude(us => us.SocialToUsers).ThenInclude(soc => soc.Social).Include(saved=>saved.SavedNews).Include(like=>like.LikeAndDislikes).FirstOrDefault(b => b.Id == id),
                News = _context.News.Include(saved => saved.SavedNews).Include(lord => lord.LikeAndDislikes).Include(u => u.User).ThenInclude(us => us.SocialToUsers).ThenInclude(soc => soc.Social).Include(scc => scc.Category).ThenInclude(scs => scs.NewsCategory).Where(aa => aa.User.SocialToUsers.Any(bb => bb.User.Id == newsUser)).ToList(),
                Categories = _context.NewsCategories.Include(s => s.NewsSubCategories).ThenInclude(d => d.News).Where(aa => aa.NewsSubCategories.Any(bb => bb.News.Count != 0 && aa.NewsSubCategories.Count != 0)).ToList(),
                NewsSubCategories = _context.NewsSubCategories.Include(nc => nc.NewsCategory).Include(b => b.News).Where(bb => bb.News.Any(s => s.NewsStatus == NewsStatus.Active)).ToList(),
                Comments = _context.NewsComments.Include(u => u.User).Where(c => c.NewsId == id).ToList(),
                RecentPost = _context.News.Where(s => s.NewsStatus == NewsStatus.Active).OrderByDescending(o => o.AddedDate).Take(3).ToList(),
                Tags = _context.NewsTags.Include(tb => tb.TagToNews).ThenInclude(b => b.News).Where(t => t.TagToNews.Any(tbb => tbb.NewsId == id)).ToList(),
                Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
            };


            return View(model);
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



        public JsonResult addLike(int? newsId)
        {
            var userId = _userManager.GetUserId(User);
            if (newsId == null)
            {
                return Json(404);
            }

            bool isExist = _context.LikeAndDislikes.Any(aa => aa.NewsId == newsId && aa.UserId == userId);
            LikeAndDislike likeOrDislike = _context.LikeAndDislikes.FirstOrDefault(aa => aa.NewsId == newsId && aa.UserId == userId);

            if (!isExist)
            {
                LikeAndDislike model = new LikeAndDislike()
                {
                    NewsId = (int)newsId,
                    UserId = userId,
                    LikeAndDislikeStatus = LikeAndDislikeStatus.Like,
                    AddedDate = DateTime.Now,
                };

                _context.LikeAndDislikes.Add(model);
                _context.SaveChanges();
            }
            else if (likeOrDislike.LikeAndDislikeStatus != LikeAndDislikeStatus.Like)
            {
                LikeAndDislike model = _context.LikeAndDislikes.FirstOrDefault(aa => aa.NewsId == newsId && aa.UserId == userId);

                _context.LikeAndDislikes.Remove(model);
                _context.SaveChanges();


                LikeAndDislike model2 = new LikeAndDislike()
                {
                    NewsId = (int)newsId,
                    UserId = userId,
                    LikeAndDislikeStatus = LikeAndDislikeStatus.Like,
                    AddedDate = DateTime.Now,
                };

                _context.LikeAndDislikes.Add(model2);
                _context.SaveChanges();

                return Json(999);
            }
            else
            {
                return Json(404);
            }



            return Json(200);
        }




        public JsonResult removeFromLike(int? newsId)
        {
            var userId = _userManager.GetUserId(User);
            if (newsId == null)
            {
                return Json(404);
            }

            bool isExist = _context.LikeAndDislikes.Any(aa => aa.NewsId == newsId && aa.UserId == userId);

            if (isExist)
            {
                LikeAndDislike model = _context.LikeAndDislikes.FirstOrDefault(aa => aa.NewsId == newsId && aa.UserId == userId);

                _context.LikeAndDislikes.Remove(model);
                _context.SaveChanges();
            }
            else
            {
                return Json(404);
            }
            return Json(200);
        }


        public JsonResult addDisLike(int? newsId)
        {
            var userId = _userManager.GetUserId(User);
            if (newsId == null)
            {
                return Json(404);
            }

            bool isExist = _context.LikeAndDislikes.Any(aa => aa.NewsId == newsId && aa.UserId == userId);
            LikeAndDislike likeOrDislike = _context.LikeAndDislikes.FirstOrDefault(aa => aa.NewsId == newsId && aa.UserId == userId);

            if (!isExist)
            {
                LikeAndDislike model = new LikeAndDislike()
                {
                    NewsId = (int)newsId,
                    UserId = userId,
                    LikeAndDislikeStatus = LikeAndDislikeStatus.Dislike,
                    AddedDate = DateTime.Now,
                };

                _context.LikeAndDislikes.Add(model);
                _context.SaveChanges();
            }
            else if (likeOrDislike.LikeAndDislikeStatus!=LikeAndDislikeStatus.Dislike)
            {
                LikeAndDislike model = _context.LikeAndDislikes.FirstOrDefault(aa => aa.NewsId == newsId && aa.UserId == userId);

                _context.LikeAndDislikes.Remove(model);
                _context.SaveChanges();


                LikeAndDislike model2 = new LikeAndDislike()
                {
                    NewsId = (int)newsId,
                    UserId = userId,
                    LikeAndDislikeStatus = LikeAndDislikeStatus.Dislike,
                    AddedDate = DateTime.Now,
                };

                _context.LikeAndDislikes.Add(model2);
                _context.SaveChanges();

                return Json(999);
            }
            else
            {
                return Json(404);
            }




            return Json(200);
        }


        public JsonResult removeFromDisLike(int? newsId)
        {
            var userId = _userManager.GetUserId(User);
            if (newsId == null)
            {
                return Json(404);
            }

            bool isExist = _context.LikeAndDislikes.Any(aa => aa.NewsId == newsId && aa.UserId == userId);

            if (isExist)
            {
                LikeAndDislike model = _context.LikeAndDislikes.FirstOrDefault(aa => aa.NewsId == newsId && aa.UserId == userId);

                _context.LikeAndDislikes.Remove(model);
                _context.SaveChanges();
            }
            else
            {
                return Json(404);
            }
            return Json(200);
        }



        public JsonResult addToNewsCount(int? newsId, int? count )
        {
            if (newsId == null && count==0)
            {
                return Json(404);
            }

            var model = _context.News.Find(newsId);

            var oldCount = model.ViewCount;
            if (model != null)
            {
                model.ViewCount = oldCount + (int)count;

                _context.Entry(model).State = EntityState.Modified;
                _context.Entry(model).Property(a => a.UserId).IsModified = false;
                _context.Entry(model).Property(a => a.AddedDate).IsModified = false;

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
