using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Licenta.Models;
using Licenta.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace Licenta.Controllers
{
    public class AppController : Controller
    {
        private readonly DBContext _context;
        private readonly Repository _repository;
        public static Student student;
        public static string emailToChangePassword;

        public AppController(DBContext context, Repository repo)
        {
            this._context = context;
            this._repository = repo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {

            if (user != null)
                if (user.Email == "tutuianueliza@gmail.com" && user.Password == "123Admin!")
                    return RedirectToAction("HomePageAdmin", "Admin");
                else
                {
                    student = _repository.VerifyStudent(user);
                    if (student == null)
                    {
                        ViewBag.LoginMessage = "Please register!";
                        return View();
                    }
                    return RedirectToAction("HomePageStudent", "HomePageStudent");
                }
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        private void SendPasswordResetEmail(string ToEmail, string UserName)
        {
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("tutuianueliza@gmail.com", ToEmail);

            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>"); sbEmailBody.Append("https://localhost:44383/app/changepassword");
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>Team SCS by E.Ț.</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "tutuianueliza@gmail.com",
                Password = "muraturi"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        [HttpPost]
        public IActionResult ResetPassword(User user)
        {
            User u = _repository.GetUserByEmail(user.Email);
            if (u != null)
            {
                emailToChangePassword = u.Email;
                SendPasswordResetEmail(u.Email, ((Student)u).FirstName);
                ViewBag.Text = "An email with instructions to reset your password is sent to your registered email";
                return View();
            }
            ViewBag.Text = "Username not found!";
            return View();
        }

        [HttpGet("/app/getstudents")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return Ok(_repository.GetAllStudents());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get students");
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(User user)
        {
            if (_repository.ChangePassword(user, emailToChangePassword) == 1)
            {
                _repository.SaveAll();
                return RedirectToAction("Login", "App");
            }
            else
            {
                ViewBag.Message = "Try again!";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "App");
        }
    }
}
