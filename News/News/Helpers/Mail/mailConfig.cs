using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Helpers.Mail
{
    public static class mailConfig
    {
        public static string BaseUrl = "https://localhost:44312/";
        public static string ProjectName = "News Managements";
        public static string ConfirmPath = BaseUrl + "account/ConfirmEmail";
        public static string MailFrom = "transxmanagement@gmail.com";
        public static string MailPasswrd = "lhieoyaivmdladfi";
    }
}
