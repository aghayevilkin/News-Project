using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Controllers;
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
    public class AboutController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AboutController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            About model = _context.Abouts.FirstOrDefault();
            return View(model);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(About model)
        {
            if (ModelState.IsValid)
            {
                _context.Abouts.Add(model);
                _context.SaveChanges();

                return RedirectToAction("index");
            }
            return View(model);
        }


        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            About model = _context.Abouts.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(About model)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(model).State = EntityState.Modified;

                _context.SaveChanges();


                return RedirectToAction("index");

            }
            return View(model);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            About model = _context.Abouts.FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Abouts.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

    }
}
