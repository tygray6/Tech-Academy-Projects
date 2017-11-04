using Bewander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Bewander.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;


namespace Bewander.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private BewanderContext db = new BewanderContext();
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Chat()
        {
            try
            {
                ViewData["senderName"] = GetUserID();
                //If user is logged in, disable the login prompt
                ViewBag.showLoginPrompt1 = "<script>\n$(window).load(function(){";
                ViewBag.showLoginPrompt2 = "$(\"input[type=submit]\").removeAttr('disabled')";
                ViewBag.showLoginPrompt3 = "$</script >";
                return View("Chat");
            }
            catch
            {
                // If user not logged in, display login prompt.
                ViewBag.showLoginPrompt1 = "<script>\n$(window).load(function(){";
                ViewBag.showLoginPrompt2 = "$(\"#myModal\").modal(\"show\");\n});";
                ViewBag.showLoginPrompt3 = "$(\"input[type = submit]\").attr('disabled','disabled');\n</script >";
                return View("Index");
            }
        }

        public string GetUserID()
        {
            // GET: Current Users ID
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            // SET: UserID
            string userID = user.Id;

            return (userID);
        }


        public ActionResult Contact()
        {
            return View();
        }


        //for POST
        [HttpPost]
        public ActionResult Contact(ContactModels c)
        {
            ViewBag.Message = "Contact Page";
            if (ModelState.IsValid)
            {
                try
                {
                    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                    //SmtpClient smtp = new SmtpClient();
                    MailAddress from = new MailAddress(c.Email.ToString());
                    StringBuilder sb = new System.Text.StringBuilder();
                    //Need to update with actual Bewander email address and Host if We use gmail as our smtp client, change code to this:
                    SmtpClient client = new SmtpClient();

                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("support@bewander.com", "bewander"); //Admin (email, password)
                    msg.From = new MailAddress(c.Email.ToString());
                    msg.To.Add("support@bewander.com"); //Admin email
                    msg.Subject = "(Bewander user:) " + c.Subject;
                    msg.IsBodyHtml = false;
                    //smtp.Host = "smtp.gmail.com";
                    //smtp.Port = 25;
                    sb.Append("First name: " + c.FirstName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Last name: " + c.LastName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Subject: " + c.Subject);
                    sb.Append(Environment.NewLine);
                    sb.Append("Message: " + c.Message);
                    msg.Body = sb.ToString();
                    //smtp.Send(msg);
                    client.Send(msg);

                    msg.Dispose();
                    return View("Success");
                }
                catch (Exception e)
                {
                    return View("Error");
                    throw e;
                }

            }
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
        public ActionResult TOS()
        {
            return View();
        }
    }
}