using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class CustomUser : IdentityUser
    {
        [Required(ErrorMessage = "Name boş olmamalıdır!"), MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname boş olmamalıdır!"), MaxLength(30)]
        public string Surname { get; set; }
        public string Image { get; set; }
        [Required]
        public bool IsVerify { get; set; }

        public string Profision { get; set; }
        public string About { get; set; }
        public string Adress { get; set; }

        [NotMapped]
        public IFormFile ImageFileTwo { get; set; }
        [NotMapped]
        public string RoleId { get; set; }

        [NotMapped]
        public List<SelectListItem> Roles { get; set; }

        public List<SocialToUser> SocialToUsers { get; set; }
        public List<NewsComment> NewsComments { get; set; }
        public List<SavedNews> SavedNews { get; set; }
        public List<LikeAndDislike> LikeAndDislikes { get; set; }
    }
}
