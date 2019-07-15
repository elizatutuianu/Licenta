using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Licenta.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Licenta.Controllers
{
    public class UploadFilesController : Controller
    {
        private readonly Repository _repository;
        private IHostingEnvironment _hostingEnvironment;

        public UploadFilesController(Repository repository, IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult UploadFiles()
        {
            return View(new ExcelFile());
        }

        public void UploadStudents(ExcelFile fileUpload)
        {
            var file = fileUpload.FileStudents;
            string folderName = "UploadStudents";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls"/* || sFileExtension == ".xlsx"*/)
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        Student stud = new Student();
                        stud.Faculty = _repository.GetFacultyByName(row.GetCell(0).ToString());
                        stud.Specialization = _repository.GetSpecializationByName(row.GetCell(1).ToString());
                        stud.IdCardStudent = _repository.GetIdCardStudentByNumber(row.GetCell(2).ToString());
                        stud.Cnp = row.GetCell(3).ToString();
                        stud.FirstName = row.GetCell(4).ToString();
                        stud.LastName = row.GetCell(5).ToString();
                        stud.Initial = row.GetCell(6).ToString();
                        stud.StudyProgram = row.GetCell(7).ToString();
                        stud.Year = Int32.Parse(row.GetCell(8).ToString());
                        stud.IsSocialCase = Boolean.Parse(row.GetCell(9).ToString());
                        stud.IsMedicalCase = Boolean.Parse(row.GetCell(10).ToString());
                        stud.Media = Double.Parse(row.GetCell(11).ToString());
                        stud.Sex = row.GetCell(12).ToString();
                        stud.Taxa_buget = row.GetCell(13).ToString();
                        stud.Group = Int32.Parse(row.GetCell(14).ToString());
                        stud.Credits = Int32.Parse(row.GetCell(15).ToString());
                        stud.PhoneNo = row.GetCell(16).ToString();
                        //stud.AccomodationRequestId = Int32.Parse(row.GetCell(17).ToString());
                        _repository.InsertStudent(stud);
                    }
                }
            }
        }

        public void UploadIdCards(ExcelFile fileUpload)
        {
            var file = fileUpload.FileIdCards;
            string folderName = "UploadIdCards";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls"/* || sFileExtension == ".xlsx"*/)
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        IdCardStudent idCard = new IdCardStudent();
                        idCard.BirthDate = DateTime.Parse(row.GetCell(0).ToString());
                        idCard.Country = row.GetCell(1).ToString();
                        idCard.IdCardNo = row.GetCell(2).ToString();
                        idCard.IdCardIssuedBy = row.GetCell(3).ToString();
                        idCard.IdCardIssuedDate = DateTime.Parse(row.GetCell(4).ToString());
                        idCard.District = row.GetCell(5).ToString();
                        idCard.Localty = row.GetCell(6).ToString();
                        idCard.Address = row.GetCell(7).ToString();
                        idCard.CivilStatus = row.GetCell(8).ToString();
                        _repository.InsertIdCard(idCard);
                    }
                }
            }
        }

        public void UploadFaculties(ExcelFile fileUpload)
        {
            var file = fileUpload.FileFaculties;
            string folderName = "UploadFaculties";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls"/* || sFileExtension == ".xlsx"*/)
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        Faculty faculty = new Faculty();
                        faculty.Name = row.GetCell(0).ToString();
                        _repository.InsertFaculty(faculty);
                    }
                }
            }
        }

        public void UploadSpecializations(ExcelFile fileUpload)
        {
            var file = fileUpload.FileSpecializations;
            string folderName = "UploadSpecializations";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        Specialization specialization = new Specialization();
                        specialization.SpecName = row.GetCell(0).ToString();
                        specialization.SpecNoOfStudents = Int32.Parse(row.GetCell(1).ToString());
                        specialization.SpecNoOfFemaleStudents = Int32.Parse(row.GetCell(2).ToString());
                        specialization.SpecLanguageOfStudy = row.GetCell(3).ToString();
                        specialization.Faculty = _repository.GetFacultyByName(row.GetCell(4).ToString());
                        _repository.InsertSpecialization(specialization);
                    }
                }
            }
        }

        public void UploadAccomodationRequests(ExcelFile fileUpload)
        {
            var accomodations = new AccomodationRequest[_repository.GetAllStudents().Count()];
            var file = fileUpload.FileAccomodationRequests;
            string folderName = "UploadAccomodationRequests";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        AccomodationRequest accomodationRequest = new AccomodationRequest();
                        for (int j = 0; j < 5; j++)
                        {
                            DormsPreferred dorm = new DormsPreferred();
                            if (row.GetCell(j + 1).ToString().Length > 0 && row.GetCell(j + 1).ToString() != "e")
                            {
                                dorm.DormName = row.GetCell(j + 1).ToString();
                                accomodationRequest.ArDorm.Add(dorm);
                            }
                            else
                                break;

                        }
                        for (int k = 0; k < 5; k++)
                        {
                            if (row.GetCell(k + 6).ToString() != "e")
                            {
                                RoomPreferred room = new RoomPreferred();
                                room.RoomNo = row.GetCell(k + 6).ToString();
                                accomodationRequest.ArRoom.Add(room);
                            }
                            else
                                break;
                        }
                        for (int l = 0; l < 2; l++)
                        {
                            if (row.GetCell(l + 11).ToString() != "e" && row.GetCell(l + 12).ToString() != "e" && row.GetCell(l + 13).ToString() != "e")
                            {
                                Roommate roommate = new Roommate();
                                roommate.FirstName = row.GetCell(l + 11).ToString();
                                roommate.LastName = row.GetCell(l + 12).ToString();
                                roommate.Initial = row.GetCell(l + 13).ToString();
                                accomodationRequest.ArRoommates.Add(roommate);
                            }
                            else
                                break;
                        }
                        if (row.GetCell(17).ToString() != "e")
                            accomodationRequest.LastComfortAccepted = row.GetCell(17).ToString();
                        //_repository.AddAccomodationRequestToDatabase(accomodationRequest);
                        string cnp = row.GetCell(18).ToString();
                        Student student = _repository.GetStudentByCNP(cnp);
                        student.AccomodationRequest = accomodationRequest;
                        student.AccomodationRequestId = accomodationRequest.Id;
                        _repository.UpdateStudent(student);
                    }
                    //var students = _repository.GetStudentsOrderdById().ToList();
                    //for (int i = 0; i < accomodations.Count; i++)
                    //{
                    //    students[i].AccomodationRequest = accomodations[i];
                    //    students[i].AccomodationRequestId = accomodations[i].Id;
                    //}
                }
            }
        }

        [HttpPost]
        public IActionResult UploadFiles(ExcelFile fileUpload)
        {
            if (ModelState.IsValid)
            {
                UploadFaculties(fileUpload);
                _repository.SaveAll();
                UploadSpecializations(fileUpload);
                _repository.SaveAll();
                UploadIdCards(fileUpload);
                _repository.SaveAll();
                UploadStudents(fileUpload);
                _repository.SaveAll();
                UploadAccomodationRequests(fileUpload);
                _repository.SaveAll();
                //var studentsOrdered = _repository.GetStudentsOrderdById();
                //var accomodationsOrdered = _repository.GetAccomodationRequestOrderdById();
                //for (int i = 0; i < accomodationsOrdered.Count; i++)
                //{
                //    studentsOrdered[i].AccomodationRequest = accomodationsOrdered[i];
                //    studentsOrdered[i].AccomodationRequestId = accomodationsOrdered[i].Id;
                //}
                //_repository.SaveAll();

                ViewBag.UploadMessage = "Upload successful.";
            }
            else
            {
                ViewBag.UploadMessage = "Upload unsuccessful.";
            }
            return View();
        }
    }
}