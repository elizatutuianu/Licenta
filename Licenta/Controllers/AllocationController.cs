using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class AllocationController : Controller
    {
        enum TipLoc
        {
            SPECIAL,
            SIMPLU
        }
        
        struct LocuriPerAn : IComparable<LocuriPerAn>
        {
            int an;
            int nr;

            public LocuriPerAn(int an, int nr)
            {
                this.an = an;
                this.nr = nr;
            }

            public int CompareTo(LocuriPerAn other)
            {
                if (this.an > other.an)
                    return 1;
                else if (this.an < other.an)
                    return -1;
                else
                    return 0;
            }
        }
        struct LocuriPerSpecialitate : IComparable<LocuriPerSpecialitate>
        {
            string specialitate;
            int nr;

            public LocuriPerSpecialitate(string specialitate, int nr)
            {
                this.specialitate = specialitate;
                this.nr = nr;
            }

            public int CompareTo(LocuriPerSpecialitate other)
            {
                return this.specialitate.CompareTo(other.specialitate);
            }
        }

        private readonly Repository _repository;
        public double noBedsAvailableInTotal;
        // An -> Specialitate -> Locuri
        private Dictionary<LocuriPerAn, Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, int>>> locuri =
            new Dictionary<LocuriPerAn, Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, int>>>();

        public AllocationController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Allocation()
        {
            if (_repository.GetAllDorms().Any()
                && DeadlinesAdminController.administrator != null
                && DeadlinesAdminController.administrator.DdlFinishProcess != null
                && DeadlinesAdminController.administrator.DdlRegistration != null
                && _repository.GetAllFaculties().Any()
                && _repository.GetAllIdCardStudents().Any()
                && _repository.GetAllSpecializations().Any()
                && _repository.GetAllStudents().Any())
            {
                double dateTime = (DeadlinesAdminController.administrator.DdlFinishProcess - DateTime.Now).Value.TotalMinutes;
                BackgroundJob.Schedule(() => SendEmailWhenDone(), TimeSpan.FromMinutes(dateTime));
                AvailableBeds();
                TempData["error"] = "Process started successfully!";
            }
            else
                TempData["error"] = "You must follow all the previous steps from start before submit!";
            return RedirectToAction("HomePageAdmin", "Admin");
        }

        public void SendEmailWhenDone()
        {
            foreach (Student student in _repository.GetAllStudents())
            {
                if (student.Email.Length != 0)
                {
                    // MailMessage class is present is System.Net.Mail namespace
                    MailMessage mailMessage1 = new MailMessage("tutuianueliza@gmail.com", student.Email);

                    // StringBuilder class is present in System.Text namespace
                    StringBuilder sbEmailBody1 = new StringBuilder();
                    sbEmailBody1.Append("Dear " + student.FirstName + ",<br/><br/>");
                    sbEmailBody1.Append("Allocations were made. You can find the Excel document below.");
                    sbEmailBody1.Append("<br/><br/>");
                    sbEmailBody1.Append("<b>Team SCS by E.Ț.</b>");

                    mailMessage1.IsBodyHtml = true;

                    mailMessage1.Body = sbEmailBody1.ToString();
                    mailMessage1.Subject = "Allocation results";
                    Attachment data1 = new Attachment("Students.xlsx", MediaTypeNames.Application.Octet);
                    mailMessage1.Attachments.Add(data1);
                    SmtpClient smtpClient1 = new SmtpClient("smtp.gmail.com", 587);

                    smtpClient1.Credentials = new System.Net.NetworkCredential()
                    {
                        UserName = "tutuianueliza@gmail.com",
                        Password = "muraturi"
                    };

                    smtpClient1.EnableSsl = true;
                    smtpClient1.Send(mailMessage1);
                }
            }
            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("tutuianueliza@gmail.com", "tutuianueliza@gmail.com");

            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear Administrator,<br/><br/>");
            sbEmailBody.Append("Allocations were made. You can find the Excel document below.");
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>Your beloved Sistem.</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Allocation results";
            Attachment data = new Attachment("Students.xlsx", MediaTypeNames.Application.Octet);
            mailMessage.Attachments.Add(data);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "tutuianueliza@gmail.com",
                Password = "muraturi"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        public void AvailableBeds()
        {
            noBedsAvailableInTotal = _repository.GetAllAvailableBeds();
            double studentsFromProv = _repository.GetStudentsFromProv();

            double noBedsForFirstYear = (_repository.GetStudentsFromFirstYear() / studentsFromProv) * noBedsAvailableInTotal;
            double noBedsForSecondYear = _repository.GetStudentsFromSecondYear() / studentsFromProv * noBedsAvailableInTotal;
            double noBedsForThirdYear = _repository.GetStudentsFromThirdYear() / studentsFromProv * noBedsAvailableInTotal;

            Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, int>> locuriPerSpecializareAn1 = new Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, int>>();
            Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, int>> locuriPerSpecializareAn2 = new Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, int>>();
            Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, int>> locuriPerSpecializareAn3 = new Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, int>>();
            locuri.Add(new LocuriPerAn(1, (int)noBedsForFirstYear), locuriPerSpecializareAn1);
            locuri.Add(new LocuriPerAn(2, (int)noBedsForSecondYear), locuriPerSpecializareAn2);
            locuri.Add(new LocuriPerAn(3, (int)noBedsForThirdYear), locuriPerSpecializareAn3);

            foreach (Faculty faculty in _repository.GetAllFaculties())
            {
                double students1Year = _repository.GetStudentsInFirstYearStudentPerFaculty(faculty.Name);
                double students2Year = _repository.GetStudentsInSecondYearStudentPerFaculty(faculty.Name);
                double students3Year = _repository.GetStudentsInThirdYearStudentPerFaculty(faculty.Name);

                double bedsPerFaculty = studentsFromProv / _repository.GetStudentsFromProvincie() * noBedsAvailableInTotal;
                double bedsForFirstYear = students1Year / studentsFromProv * bedsPerFaculty;
                double bedsForSecondYear = students2Year / studentsFromProv * bedsPerFaculty;
                double bedsForThirdYear = students3Year / studentsFromProv * bedsPerFaculty;

                if (faculty.Specializations != null)
                {
                    foreach (Specialization specialization in faculty.Specializations)
                    {
                        double bedsForFirstYearFromSpecialization = _repository.GetStudentsFromProvinciePerSpecializationInFirstYear(specialization.SpecName) / students1Year * bedsForFirstYear;
                        double bedsForSecondYearFromSpecialization = _repository.GetStudentsFromProvinciePerSpecializationInSecondYear(specialization.SpecName) / students2Year * bedsForSecondYear;
                        double bedsForThirdYearFromSpecialization = _repository.GetStudentsFromProvinciePerSpecializationInThirdYear(specialization.SpecName) / students3Year * bedsForThirdYear;


                        Dictionary<TipLoc, int> locuriFinaleAn1 = new Dictionary<TipLoc, int>();
                        double locuriSpecialeAnul1 = 34 / 100 * bedsForFirstYearFromSpecialization;
                        locuriFinaleAn1.Add(TipLoc.SPECIAL, (int)locuriSpecialeAnul1);
                        double locuriSimpleAnul1 = bedsForFirstYearFromSpecialization - locuriSpecialeAnul1;
                        locuriFinaleAn1.Add(TipLoc.SIMPLU, (int)locuriSimpleAnul1);
                        locuriPerSpecializareAn1.Add(new LocuriPerSpecialitate(specialization.SpecName, (int)bedsForFirstYearFromSpecialization), locuriFinaleAn1);

                        Dictionary<TipLoc, int> locuriFinaleAn2 = new Dictionary<TipLoc, int>();
                        double locuriSpecialeAnul2 = 10 / 100 * bedsForSecondYearFromSpecialization;
                        locuriFinaleAn2.Add(TipLoc.SPECIAL, (int)locuriSpecialeAnul2);
                        double locuriSimpleAnul2 = bedsForSecondYearFromSpecialization - locuriSpecialeAnul2;
                        locuriFinaleAn2.Add(TipLoc.SIMPLU, (int)locuriSimpleAnul2);
                        locuriPerSpecializareAn2.Add(new LocuriPerSpecialitate(specialization.SpecName, (int)bedsForFirstYearFromSpecialization), locuriFinaleAn2);

                        Dictionary<TipLoc, int> locuriFinaleAn3 = new Dictionary<TipLoc, int>();
                        double locuriSpecialeAnul3 = 10 / 100 * bedsForThirdYearFromSpecialization;
                        locuriFinaleAn3.Add(TipLoc.SPECIAL, (int)locuriSpecialeAnul3);
                        double locuriSimpleAnul3 = bedsForThirdYearFromSpecialization - locuriSpecialeAnul3;
                        locuriFinaleAn3.Add(TipLoc.SIMPLU, (int)locuriSimpleAnul3);
                        locuriPerSpecializareAn3.Add(new LocuriPerSpecialitate(specialization.SpecName, (int)bedsForFirstYearFromSpecialization), locuriFinaleAn3);
                    }
                }
                ////locuriPeFacultati.Add(faculty.Name, new Dictionary<string, >);
                //Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, LocuriFinale>> locuriPerAN = new Dictionary<LocuriPerSpecialitate, Dictionary<TipLoc, LocuriFinale>>();
                //locuri.TryGetValue(new LocuriPerAn(1, 0), out locuriPerAN);
                //locuriPerAN.TryGetValue(new LocuriPerSpecialitate('asdad', 0), out )
            }
        }
    }
}