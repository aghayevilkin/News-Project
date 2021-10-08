﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Helpers.Mail;
using News.Models;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace News.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [Authorize]
        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);
            CustomUser customUsers = _context.CustomUsers.Find(userId);
            List<CustomUser> customUserS = _context.CustomUsers.Include(u => u.SocialToUsers).ThenInclude(sc => sc.Social).Where(aa => aa.SocialToUsers.Any(bb => bb.User.Id == userId)).ToList();

            List<Social> socials = _context.Socials.ToList();
            socials.Insert(0, new Social() { Id = 0, Icon = "Select" });
            ViewBag.Socials = socials;

            News.Models.News newsdate = _context.News.Where(u => u.UserId == userId).OrderByDescending(d => d.AddedDate).LastOrDefault();
            if (newsdate != null)
            {
                ViewBag.LastPostDate = newsdate.AddedDate;
            }



            List<NewsTag> tags = _context.NewsTags.ToList();
            ViewBag.Tags = tags;
            VmProfile model = new VmProfile()
            {
                Posts = _context.News.Include(u => u.User).Include(tp => tp.TagToNews).ThenInclude(t => t.Tag).Where(p => p.UserId == userId).OrderByDescending(o => o.AddedDate).ToList(),
                SavedNews = _context.SavedNews.Include(pp => pp.News).ThenInclude(cat => cat.Category).Include(u => u.User).Where(sa => sa.UserId == userId).OrderByDescending(o => o.AddedDate).ToList(),
                Tags = _context.NewsTags.Include(b => b.TagToNews).ThenInclude(bl => bl.News).ToList(),
                Socials = _context.Socials.ToList(),
                User = customUsers,
                UserS = customUserS,
            };
            return View(model);
        }



        public async Task<IActionResult> Login(string returnUrl)
        {
            VmBase model = new VmBase()
            {
                //Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(VmBase model)
        {
            //Setting setting = _context.Settings.FirstOrDefault();
            //model.Setting = setting;
            model.Socials = _context.Socials.ToList();
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(model.LoginViewModel.Email);

                if (user != null && !user.EmailConfirmed &&
                            (await _userManager.CheckPasswordAsync(user, model.LoginViewModel.Password)))
                {
                    Notify("Email not confirmed yet!", notificationType: NotificationType.error);
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet");



                    var token = HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(user));


                    //Sending mail
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(mailConfig.MailFrom, mailConfig.ProjectName + " Confirm Email");
                    mail.To.Add(user.Email);
                    mail.Body = "<table style = 'Margin:0 auto;background:#f6f6f6;border-collapse:collapse;border-color:transparent;border-spacing:0;float:none;margin:0 auto;padding:0;text-align:center;vertical-align:top;width:100%' >Dear " + user.UserName + "<td height = '50px' style='Margin:0;border-collapse:collapse!important;color:#0a0a0a;font-family:Open Sans,sans-serif;font-size:32px;font-weight:400;line-height:32px;margin:0;padding:0;text-align:left;vertical-align:top;word-wrap:break-word'></td></tr></tbody></table><table class='m_4511308450920007087container-radius' style='border-top-width:0;border-top-color:#efefef;border-left-width:0;border-right-width:0;border-bottom-width:1px;border-bottom-color:#efefef;border-right-color:#efefef;border-left-color:#efefef;border-style:solid;border-bottom-left-radius:3px;border-bottom-right-radius:3px;display:table;padding-bottom:50px;border-spacing:60px 0;border-collapse:separate;width:100%;background:#f6f6f6;max-width:800px'><tbody><tr><td><table class='m_4511308450920007087row' style='border-collapse:collapse;border-color:transparent;border-spacing:0;display:table;padding:0;text-align:left;vertical-align:top;width:100%'><tbody><tr style = 'padding:0;text-align:left;vertical-align:top' ></ tr ></ tbody ></ table> Dear " + user.UserName + ",</p><p>Thanks for getting started with our "+ mailConfig.ProjectName + "!</p><p>We need a little more information to complete your registration, including a confirmation of your email address. </p><p>Click below to confirm your email address:<br>" +
                            "<a href='" + mailConfig.ConfirmPath + "?userId=" + user.Id + "&token=" + token + "'>Confirm Email</a>" +
                        "</td></tr></tbody></table></td></tr></tbody></table>";
                    mail.IsBodyHtml = true;
                    mail.Subject = "Confirm Email";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(mailConfig.MailFrom, mailConfig.MailPasswrd);

                    smtpClient.Send(mail);



                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(model.LoginViewModel.Email, model.LoginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "account");

                }
                else
                {
                    ModelState.AddModelError("", "Email or password is incorrect");
                }

            }
            return View(model);
        }



        public async Task<IActionResult> Register()
        {
            VmBase model = new VmBase()
            {
                //Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Register(VmBase model)
        {
            //Setting setting = _context.Settings.FirstOrDefault();
            //model.Setting = setting;
            model.Socials = _context.Socials.ToList();
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var customUser = new CustomUser() { Name = model.RegisterViewModel.Name, Surname = model.RegisterViewModel.Surname, UserName = model.RegisterViewModel.Email, Email = model.RegisterViewModel.Email };
                var result = await _userManager.CreateAsync(customUser, model.RegisterViewModel.Password);
                await _userManager.AddToRoleAsync(customUser, "Customer");

                if (result.Succeeded)
                {

                    var token = HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(customUser));


                    //Sending mail
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(mailConfig.MailFrom, mailConfig.ProjectName + " Confirm Email");
                    mail.To.Add(customUser.Email);
                    mail.Body = "<table style = 'Margin:0 auto;background:#f6f6f6;border-collapse:collapse;border-color:transparent;border-spacing:0;float:none;margin:0 auto;padding:0;text-align:center;vertical-align:top;width:100%' >Dear " + customUser.UserName + "<td height = '50px' style='Margin:0;border-collapse:collapse!important;color:#0a0a0a;font-family:Open Sans,sans-serif;font-size:32px;font-weight:400;line-height:32px;margin:0;padding:0;text-align:left;vertical-align:top;word-wrap:break-word'></td></tr></tbody></table><table class='m_4511308450920007087container-radius' style='border-top-width:0;border-top-color:#efefef;border-left-width:0;border-right-width:0;border-bottom-width:1px;border-bottom-color:#efefef;border-right-color:#efefef;border-left-color:#efefef;border-style:solid;border-bottom-left-radius:3px;border-bottom-right-radius:3px;display:table;padding-bottom:50px;border-spacing:60px 0;border-collapse:separate;width:100%;background:#f6f6f6;max-width:800px'><tbody><tr><td><table class='m_4511308450920007087row' style='border-collapse:collapse;border-color:transparent;border-spacing:0;display:table;padding:0;text-align:left;vertical-align:top;width:100%'><tbody><tr style = 'padding:0;text-align:left;vertical-align:top' ></ tr ></ tbody ></ table> Dear " + customUser.UserName + ",</p><p>Thanks for getting started with our " + mailConfig.ProjectName + "!</p><p>We need a little more information to complete your registration, including a confirmation of your email address. </p><p>Click below to confirm your email address:<br>" +
                            "<a href='" + mailConfig.ConfirmPath + "?userId=" + customUser.Id + "&token=" + token + "'>Confirm Email</a>" +
                        "</td></tr></tbody></table></td></tr></tbody></table>";
                    mail.IsBodyHtml = true;
                    mail.Subject = "Confirm Email";

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(mailConfig.MailFrom, mailConfig.MailPasswrd);

                    smtpClient.Send(mail);
                    //End of sending mail


                    Notify("Send Email Link successfully");


                    return RedirectToAction("login", "account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }


        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                Notify("UserId or Token Invalid!", notificationType: NotificationType.error);
                return RedirectToAction("index", "home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {

                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);

            VmBase model = new VmBase()
            {
                //Setting = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList(),
            };

            if (result.Succeeded)
            {
                Notify("Confirm Email successfully");
                return View(model);
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }












    }
}
