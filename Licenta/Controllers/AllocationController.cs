using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //struct LocuriFinale
        //{
        //    int locuriTaxa;
        //    int locuriBuget;

        //    public LocuriFinale( int taxa, int buget)
        //    {
        //        this.locuriTaxa = taxa;
        //        this.locuriBuget = buget;
        //    }
        //}
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
            CalculeazaLocuriDisponibile();
            @ViewBag.ErrorMessage = "You must follow the previous steps before start!";
            return RedirectToAction("HomePageAdmin", "Admin");
        }

        public void CalculeazaLocuriDisponibile()
        {
            if (_repository.GetAllDorms().Any()
                //&& DeadlinesAdminController.administrator != null
                && _repository.GetAllFaculties().Any()
                && _repository.GetAllIdCardStudents().Any()
                && _repository.GetAllSpecializations().Any()
                && _repository.GetAllStudents().Any())
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
}