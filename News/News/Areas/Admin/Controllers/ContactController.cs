using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.Controllers;
using News.Data;
using News.Models;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class ContactController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ContactController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            VmBase model = new VmBase()
            {
                Messages = _context.Messages.OrderByDescending(a => a.AddedDate).ToList(),
            };
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                Notify("You have not selected a message!", notificationType: NotificationType.warning);
                return RedirectToAction("Index");
            }

            Message message = _context.Messages.FirstOrDefault(i => i.Id == id);
            if (message == null)
            {
                Notify("Message not deleted!", notificationType: NotificationType.error);
                return RedirectToAction("Index");
            }


            Notify("Message Deleted");
            _context.Messages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        //Subscribes
        public IActionResult Subscribers()
        {
            List<Subscribe> model = _context.Subscribes.ToList();
            return View(model);
        }

        public IActionResult DeleteSubscriber(int? id)
        {
            if (id == null)
            {
                Notify("You have not selected a message!", notificationType: NotificationType.warning);
                return RedirectToAction("Subscribers");
            }

            Subscribe model = _context.Subscribes.FirstOrDefault(i => i.Id == id);
            if (model == null)
            {
                Notify("Subscriber not deleted!", notificationType: NotificationType.error);
                return RedirectToAction("Subscribers");
            }


            Notify("Subscriber Deleted");
            _context.Subscribes.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Subscribers");
        }

    }
}
