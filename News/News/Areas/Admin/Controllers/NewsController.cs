using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News.Controllers;
using News.Data;
using News.Models;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace News.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class NewsController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public NewsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            List<NewsCategory> categories = _context.NewsCategories.ToList();
            categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
            ViewBag.Categories = categories;

            List<NewsSubCategory> subcategories = _context.NewsSubCategories.ToList();
            subcategories.Insert(0, new NewsSubCategory() { Id = 0, Name = "Select" });
            ViewBag.SubCategories = subcategories;

            List<NewsTag> tags = _context.NewsTags.ToList();
            ViewBag.Tags = tags;

            VmNews model = new VmNews()
            {
                News = _context.News.Include(g => g.Category).ThenInclude(sc=>sc.NewsCategory).Include(u => u.User).Include(tb => tb.TagToNews).ThenInclude(t => t.Tag).OrderByDescending(added => added.AddedDate).ToList(),
                New = new News.Models.News(),
                Categories = ViewBag.Categories,
                Tags = ViewBag.Tags,
            };
            return View(model);
        }

        public IActionResult ViewAll()
        {
            IList<News.Models.News> news = _context.News.Include(g => g.Category).ThenInclude(sc=>sc.NewsCategory).Include(u => u.User).Include(tb => tb.TagToNews).ThenInclude(t => t.Tag).OrderByDescending(added => added.AddedDate).ToList();
            return View(news);
        }



        //Create
        public IActionResult Create()
        {
            List<NewsCategory> categories = _context.NewsCategories.ToList();
            categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
            ViewBag.Categories = categories;

            List<NewsSubCategory> subcategories = _context.NewsSubCategories.ToList();
            subcategories.Insert(0, new NewsSubCategory() { Id = 0, Name = "Select" });
            ViewBag.SubCategories = subcategories;

            List<NewsTag> tags = _context.NewsTags.ToList();
            ViewBag.Tags = tags;

            VmNews model = new VmNews()
            {
                News = _context.News.Include(g => g.Category).ThenInclude(sc=>sc.NewsCategory).Include(u => u.User).Include(tb => tb.TagToNews).ThenInclude(t => t.Tag).ToList(),
                New = new News.Models.News(),
                Categories = ViewBag.Categories,
                Tags = ViewBag.Tags,
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(VmNews model)
        {
            if (ModelState.IsValid)
            {
                if (model.New.CategoryId == 0)
                {
                    ModelState.AddModelError("CategoryId", "Categoriya secmelisiniz!");
                    List<NewsCategory> categories = _context.NewsCategories.ToList();
                    categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    List<NewsSubCategory> subcategories = _context.NewsSubCategories.ToList();
                    subcategories.Insert(0, new NewsSubCategory() { Id = 0, Name = "Select" });
                    ViewBag.SubCategories = subcategories;

                    List<NewsTag> tags = _context.NewsTags.ToList();
                    ViewBag.Tags = tags;
                    Notify("Categoriya secmelisiniz!", notificationType: NotificationType.warning);
                    return View(model);
                }
                if (model.New.ImageFile != null)
                {
                    if (model.New.ImageFile.ContentType == "image/png" || model.New.ImageFile.ContentType == "image/jpeg" || model.New.ImageFile.ContentType == "image/gif" || model.New.ImageFile.ContentType == "image/svg+xml")
                    {
                        if (model.New.ImageFile.Length <= 2097152)
                        {
                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.New.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/News", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.New.ImageFile.CopyTo(stream);
                            }

                            model.New.Image = fileName;
                            model.New.NewsStatus = NewsStatus.Active;
                            model.New.UserId = _userManager.GetUserId(User);
                            model.New.AddedDate = DateTime.Now;

                            _context.News.Add(model.New);
                            _context.SaveChanges();

                            if (model.New.TagIds == null)
                            {
                                Notify("Tag secmelisiniz!", notificationType: NotificationType.warning);
                                return RedirectToAction("create");
                            }
                            else
                            {
                                foreach (var item in model.New.TagIds)
                                {
                                    TagToNews tagToNews = new TagToNews()
                                    {
                                        NewsId = model.New.Id,
                                        TagId = item
                                    };

                                    _context.TagToNews.Add(tagToNews);
                                }
                            }


                            _context.SaveChanges();
                            Notify("Post Created");

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            Notify("Siz maksimum 2 Mb hecmde fayllari upload ede bilersiniz!", notificationType: NotificationType.warning);
                        }
                    }
                    else
                    {
                        Notify("Siz yalniz .jpeg, .png, .gif tipli fayllari upload ede bilersiniz!", notificationType: NotificationType.warning);
                    }
                }
                else
                {
                    Notify("Image Secmelisiniz!", notificationType: NotificationType.warning);
                }

            }

            Notify("News Not Added!", notificationType: NotificationType.error);
            return RedirectToAction("create");
        }



        //Update
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            News.Models.News model = _context.News.Include(t => t.TagToNews).FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            List<NewsCategory> categories = _context.NewsCategories.ToList();
            categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
            ViewBag.Categories = categories;

            List<NewsSubCategory> subcategories = _context.NewsSubCategories.ToList();
            subcategories.Insert(0, new NewsSubCategory() { Id = 0, Name = "Select" });
            ViewBag.SubCategories = subcategories;

            List<NewsTag> tags = _context.NewsTags.ToList();
            ViewBag.Tags = tags;

            List<int> tagIds = new List<int>();

            foreach (var item in model.TagToNews)
            {
                tagIds.Add(item.TagId);
            }

            model.TagIds = tagIds.ToArray();

            return View(model);
        }



        [HttpPost]
        public IActionResult Update(News.Models.News model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.CategoryId == 0)
                    {
                        ModelState.AddModelError("CategoryId", "Categoriya secmelisiniz!");
                        List<NewsCategory> categories = _context.NewsCategories.ToList();
                        categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
                        ViewBag.Categories = categories;

                        List<NewsSubCategory> subcategories = _context.NewsSubCategories.ToList();
                        subcategories.Insert(0, new NewsSubCategory() { Id = 0, Name = "Select" });
                        ViewBag.SubCategories = subcategories;

                        List<NewsTag> tags = _context.NewsTags.ToList();
                        ViewBag.Tags = tags;
                        Notify("Categoriya secmelisiniz!", notificationType: NotificationType.warning);
                        return View(model);
                    }
                    if (model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif" || model.ImageFile.ContentType == "image/svg+xml")
                    {
                        if (model.ImageFile.Length <= 2097152)
                        {
                            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/News", model.Image);
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }

                            string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/News", fileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;

                            _context.Entry(model).State = EntityState.Modified;
                            _context.Entry(model).Property(a => a.UserId).IsModified = false;
                            _context.Entry(model).Property(a => a.AddedDate).IsModified = false;

                            _context.SaveChanges();


                            foreach (var item in _context.News.Include(a => a.TagToNews).FirstOrDefault(i => i.Id == model.Id).TagToNews)
                            {
                                _context.TagToNews.Remove(item);
                            }
                            _context.SaveChanges();


                            foreach (var item in model.TagIds)
                            {
                                TagToNews tagToNews = new TagToNews()
                                {
                                    NewsId = model.Id,
                                    TagId = item
                                };

                                _context.TagToNews.Add(tagToNews);
                            }
                            _context.SaveChanges();

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "Siz maksimum 2 Mb hecmde fayllari upload ede bilersiniz!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Siz yalniz .jpeg, .png, .gif tipli fayllari upload ede bilersiniz!");
                    }
                }
                else
                {
                    if (model.CategoryId == 0)
                    {
                        ModelState.AddModelError("CategoryId", "Categoriya secmelisiniz!");
                        List<NewsCategory> categories = _context.NewsCategories.ToList();
                        categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
                        ViewBag.Categories = categories;

                        List<NewsSubCategory> subcategories = _context.NewsSubCategories.ToList();
                        subcategories.Insert(0, new NewsSubCategory() { Id = 0, Name = "Select" });
                        ViewBag.SubCategories = subcategories;

                        List<NewsTag> tags = _context.NewsTags.ToList();
                        ViewBag.Tags = tags;
                        return View(model);
                    }

                    _context.Entry(model).State = EntityState.Modified;
                    _context.Entry(model).Property(a => a.UserId).IsModified = false;
                    _context.Entry(model).Property(a => a.AddedDate).IsModified = false;

                    _context.SaveChanges();


                    foreach (var item in _context.News.Include(a => a.TagToNews).FirstOrDefault(i => i.Id == model.Id).TagToNews)
                    {
                        _context.TagToNews.Remove(item);
                    }
                    _context.SaveChanges();


                    foreach (var item in model.TagIds)
                    {
                        TagToNews tagToNews = new TagToNews()
                        {
                            NewsId = model.Id,
                            TagId = item
                        };

                        _context.TagToNews.Add(tagToNews);
                    }
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            return View(model);
        }


        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News.Models.News news = _context.News.Include(a => a.TagToNews).FirstOrDefault(i => i.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            //Delete image
            string oldFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads/Images/News", news.Image);
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }


            //Delete tags
            foreach (var item in news.TagToNews)
            {
                _context.TagToNews.Remove(item);
            }

            _context.News.Remove(news);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        //Category
        public IActionResult Category()
        {
            List<NewsCategory> model = _context.NewsCategories.ToList();
            return View(model);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(NewsCategory model)
        {
            if (ModelState.IsValid)
            {

                _context.NewsCategories.Add(model);
                _context.SaveChanges();
                Notify("Category Created");
                return RedirectToAction("Category");

            }
            return View(model);
        }

        public IActionResult UpdateCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            NewsCategory model = _context.NewsCategories.FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateCategory(NewsCategory model)
        {
            if (ModelState.IsValid)
            {

                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();
                Notify("Category Updated");

                return RedirectToAction("Category");

            }
            return View(model);
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsCategory model = _context.NewsCategories.FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }


            _context.NewsCategories.Remove(model);
            _context.SaveChanges();
            Notify("Category Deleted");
            return RedirectToAction("Category");
        }


        //SubCategory
        public IActionResult SubCategory()
        {
            List<NewsSubCategory> model = _context.NewsSubCategories.Include(c=>c.NewsCategory).OrderByDescending(i=>i.Id).ToList();
            return View(model);
        }

        public IActionResult CreateSubCategory()
        {
            List<NewsCategory> categories = _context.NewsCategories.ToList();
            categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult CreateSubCategory(NewsSubCategory model)
        {
            if (ModelState.IsValid)
            {

                if (model.NewsCategoryId == 0)
                {
                    ModelState.AddModelError("NewsCategoryId", "Categoriya secmelisiniz!");
                    List<NewsCategory> categories = _context.NewsCategories.ToList();
                    categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    Notify("Categoriya secmelisiniz!", notificationType: NotificationType.warning);
                    return RedirectToAction("CreateSubCategory");
                }

                _context.NewsSubCategories.Add(model);
                _context.SaveChanges();
                Notify("Sub Category Created");
                return RedirectToAction("SubCategory");

            }
            return View(model);
        }

        public IActionResult UpdateSubCategory(int? id)
        {
            List<NewsCategory> categories = _context.NewsCategories.ToList();
            categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
            ViewBag.Categories = categories;

            if (id == null)
            {
                return NotFound();
            }
            NewsSubCategory model = _context.NewsSubCategories.FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateSubCategory(NewsSubCategory model)
        {
            if (ModelState.IsValid)
            {
                if (model.NewsCategoryId == 0)
                {
                    ModelState.AddModelError("NewsCategoryId", "Categoriya secmelisiniz!");
                    List<NewsCategory> categories = _context.NewsCategories.ToList();
                    categories.Insert(0, new NewsCategory() { Id = 0, Name = "Select" });
                    ViewBag.Categories = categories;

                    Notify("Categoriya secmelisiniz!", notificationType: NotificationType.warning);
                    return RedirectToAction("UpdateSubCategory");
                }

                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();
                Notify("Sub Category Updated");

                return RedirectToAction("SubCategory");

            }
            return View(model);
        }

        public IActionResult DeleteSubCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsSubCategory model = _context.NewsSubCategories.FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }


            _context.NewsSubCategories.Remove(model);
            _context.SaveChanges();
            Notify("Sub Category Deleted");
            return RedirectToAction("SubCategory");
        }


        public IActionResult Tag()
        {
            List<NewsTag> tags = _context.NewsTags.ToList();
            return View(tags);
        }

        public IActionResult CreateTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTag(NewsTag model)
        {
            if (ModelState.IsValid)
            {

                _context.NewsTags.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Tag");

            }
            return View(model);
        }

        public IActionResult UpdateTag(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            NewsTag tag = _context.NewsTags.FirstOrDefault(i => i.Id == id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }


        [HttpPost]
        public IActionResult UpdateTag(NewsTag model)
        {
            if (ModelState.IsValid)
            {

                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();


                return RedirectToAction("Tag");

            }
            return View(model);
        }

        public IActionResult DeleteTag(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewsTag tag = _context.NewsTags.FirstOrDefault(i => i.Id == id);
            if (tag == null)
            {
                return NotFound();
            }


            _context.NewsTags.Remove(tag);
            _context.SaveChanges();

            return RedirectToAction("Tag");
        }





        public IActionResult CascadeList()
        {
            ViewBag.Category = new SelectList(_context.NewsCategories, "Id", "Name");

            return View();
        }

        public JsonResult LoadSubCategory(int id)
        {
            var subcategory = _context.NewsSubCategories.Where(z => z.NewsCategoryId == id).ToList();
            return Json(new SelectList(subcategory, "Id", "Name"));
        }

    }
}
