using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News.Data;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.ViewComponents
{
    public class ExternalLogin : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        public ExternalLogin(SignInManager<IdentityUser> signInManager, AppDbContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            VmBase model = new VmBase()
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };
            return View(model);
        }
    }
}
