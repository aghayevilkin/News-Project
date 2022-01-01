using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class SocialController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public SocialController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Social> socials = _context.Socials.ToList();

            return View(socials);
        }


        public IActionResult CreateSocial()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateSocial(Social model)
        {
            if (ModelState.IsValid)
            {
                _context.Socials.Add(model);
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return View(model);
        }


        public IActionResult UpdateSocial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Social social = _context.Socials.Find(id);
            if (social == null)
            {
                return NotFound();
            }

            return View(social);
        }

        [HttpPost]
        public IActionResult UpdateSocial(Social model)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();


                return RedirectToAction("index");

            }
            return View(model);
        }


        public IActionResult DeleteSocial(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Social social = _context.Socials.FirstOrDefault(i => i.Id == id);
            if (social == null)
            {
                return NotFound();
            }

            _context.Socials.Remove(social);
            _context.SaveChanges();

            return RedirectToAction("index");
        }



        public IActionResult SocialToUser()
        {
            List<SocialToUser> socialToTeachers = _context.SocialToUsers.ToList();

            return View(socialToTeachers);
        }


        public IActionResult SocialToUserCreate()
        {
            List<CustomUser> users = _context.CustomUsers.ToList();
            users.Insert(0, new CustomUser() { Id = null, Email = "Select" });
            ViewBag.Users = users;

            List<Social> socials = _context.Socials.ToList();
            socials.Insert(0, new Social() { Id = 0, Icon = "Select" });
            ViewBag.Socials = socials;

            return View();
        }


        [HttpPost]
        public IActionResult SocialToUserCreate(SocialToUser model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserId == null)
                {
                    ModelState.AddModelError("UserId", "User secmelisiniz!");
                    List<CustomUser> users = _context.CustomUsers.ToList();
                    users.Insert(0, new CustomUser() { Id = null, Name = "Select" });
                    ViewBag.Users = users;
                    ModelState.AddModelError("SocialId", "Social secmelisiniz!");
                    List<Social> socials = _context.Socials.ToList();
                    socials.Insert(0, new Social() { Id = 0, Icon = "Select" });
                    ViewBag.Socials = socials;

                    return View(model);
                }

                _context.SocialToUsers.Add(model);
                _context.SaveChanges();


                return RedirectToAction("socialtouser");
            }
            return View(model);
        }



        public IActionResult SocialToUserUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            SocialToUser socialToUser = _context.SocialToUsers.Find(id);
            if (socialToUser == null)
            {
                return NotFound();
            }

            List<CustomUser> users = _context.CustomUsers.ToList();
            users.Insert(0, new CustomUser() { Id = null, Email = "Select" });
            ViewBag.Users = users;

            List<Social> socials = _context.Socials.ToList();
            socials.Insert(0, new Social() { Id = 0, Icon = "Select" });
            ViewBag.Socials = socials;



            return View(socialToUser);
        }

        [HttpPost]
        public IActionResult SocialToUserUpdate(SocialToUser model)
        {

            if (ModelState.IsValid)
            {
                if (model.UserId == null)
                {
                    ModelState.AddModelError("UserId", "User secmelisiniz!");
                    List<CustomUser> users = _context.CustomUsers.ToList();
                    users.Insert(0, new CustomUser() { Id = null, Name = "Select" });
                    ViewBag.Users = users;
                    ModelState.AddModelError("SocialId", "Social secmelisiniz!");
                    List<Social> socials = _context.Socials.ToList();
                    socials.Insert(0, new Social() { Id = 0, Icon = "Select" });
                    ViewBag.Socials = socials;

                    return View(model);
                }
                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();


                return RedirectToAction("socialtouser");

            }
            return View(model);
        }


        public IActionResult SocialToUserDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SocialToUser socialToUser = _context.SocialToUsers.FirstOrDefault(i => i.Id == id);
            if (socialToUser == null)
            {
                return NotFound();
            }

            _context.SocialToUsers.Remove(socialToUser);
            _context.SaveChanges();

            return RedirectToAction("socialtouser");
        }


    }
}
