using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;
using System.IO;
using System.Net;
using System.Data.Entity;
using StudentManagementSystem.Models.ReportingModel;
using System.Globalization;

using Microsoft.Reporting.WebForms;
using StudentManagementSystem.Manager;


namespace StudentManagementSystem.Controllers
{
    public class StudentRegistrationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        ReportManager _report = new ReportManager();

        //public ActionResult TableDataLoad()
        //{
        //    var data = db.StudentPayments.ToList();
        //    return Json(new {data = data}, JsonRequestBehavior.AllowGet);
        //}

        // GET: /StudentRegistration/
        public ActionResult Index()
        {
            return View(db.StudentResigtrations.ToList());
        }

        public ActionResult Search()
        {
            return View(db.StudentResigtrations.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            StudentRegistration aobjet = new StudentRegistration();

            var dropdownitem = db.Departments.ToList();
            SelectList departmentlist = new SelectList(dropdownitem, "Name", "Name");
            aobjet.DepartmentList = departmentlist;

            var Batchitem = db.Batchs.ToList();
            SelectList BatchitemList = new SelectList(Batchitem, "Name", "Name");
            aobjet.BatchSelectList = BatchitemList;

            var Sessionitem = db.Sessions.ToList();
            SelectList SessionitemList = new SelectList(Sessionitem, "Name", "Name");
            aobjet.SessionSelectList = SessionitemList;


            return View(aobjet);
        }

        [HttpPost]
        public ActionResult Create(StudentRegistration model, HttpPostedFileBase file, int? id)
        {
                if (id != 0)
                {
                    if (file == null)
                    {
                        model.Stu_imagePath = model.Stu_imagePath;
                        if (ModelState.IsValid)
                        {
                            db.Entry(model).State = EntityState.Modified;
                            var isSave = db.SaveChanges();
                            if (isSave > 0)
                            {
                                ViewBag.Message = "Update Successful.";
                            }
                            else
                            {
                                ViewBag.Message = "Update Fail.";
                            }

                            ModelState.Clear();

                            StudentRegistration aobjet = new StudentRegistration();

                            var d = db.Departments.ToList();
                            SelectList dd = new SelectList(d, "Name", "Name");
                            aobjet.DepartmentList = dd;

                            var b = db.Batchs.ToList();
                            SelectList bb = new SelectList(b, "Name", "Name");
                            aobjet.BatchSelectList = bb;

                            var s = db.Sessions.ToList();
                            SelectList ss = new SelectList(s, "Name", "Name");
                            aobjet.SessionSelectList = ss;

                            return View(aobjet);
                        }
                    }
                    else
                    {
                        string filename = Path.GetFileNameWithoutExtension(file.FileName);
                        string extention = Path.GetExtension(file.FileName);
                        filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
                        model.Stu_imagePath = filename;
                        //model.Stu_imagePath = "~/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                        file.SaveAs(filename);

                        if (ModelState.IsValid)
                        {
                            db.Entry(model).State = EntityState.Modified;
                            var isSave = db.SaveChanges();
                            if (isSave > 0)
                            {
                                ViewBag.Message = "Update Successful.";
                            }
                            else
                            {
                                ViewBag.Message = "Update Fail";
                            }
                            ModelState.Clear();

                            StudentRegistration aobjet = new StudentRegistration();

                            var d = db.Departments.ToList();
                            SelectList dd = new SelectList(d, "Name", "Name");
                            aobjet.DepartmentList = dd;

                            var b = db.Batchs.ToList();
                            SelectList bb = new SelectList(b, "Name", "Name");
                            aobjet.BatchSelectList = bb;

                            var s = db.Sessions.ToList();
                            SelectList ss = new SelectList(s, "Name", "Name");
                            aobjet.SessionSelectList = ss;

                            return View(aobjet);
                        }
                    }
                  
                }

                else
                {
                    string filename = Path.GetFileNameWithoutExtension(file.FileName);
                    string extention = Path.GetExtension(file.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extention;
                    model.Stu_imagePath = filename;
                    //model.Stu_imagePath = "~/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                    file.SaveAs(filename);

                    if (ModelState.IsValid)
                    {
                        db.StudentResigtrations.Add(model);
                        var isSave = db.SaveChanges();
                        if (isSave > 0)
                        {
                            ViewBag.Message = "Save Successful.";
                        }
                        else
                        {
                            ViewBag.Message = "Save Fail.";
                        }
                        ModelState.Clear();

                        StudentRegistration aobjet = new StudentRegistration();

                        var d = db.Departments.ToList();
                        SelectList dd = new SelectList(d, "Name", "Name");
                        aobjet.DepartmentList = dd;

                        var b = db.Batchs.ToList();
                        SelectList bb = new SelectList(b, "Name", "Name");
                        aobjet.BatchSelectList = bb;

                        var s = db.Sessions.ToList();
                        SelectList ss = new SelectList(s, "Name", "Name");
                        aobjet.SessionSelectList = ss;

                        return View(aobjet);
                       
                    }
                }
          
            var dropdownitem = db.Departments.ToList();
            SelectList departmentlist = new SelectList(dropdownitem, "Name", "Name");
            model.DepartmentList = departmentlist;

            var Batchitem = db.Batchs.ToList();
            SelectList BatchitemList = new SelectList(Batchitem, "Name", "Name");
            model.BatchSelectList = BatchitemList;

            var Sessionitem = db.Sessions.ToList();
            SelectList SessionitemList = new SelectList(Sessionitem, "Name", "Name");
            model.SessionSelectList = SessionitemList;

            return View(model);
        }

      
        public ActionResult Edit(int? id)
        {
          
            StudentRegistration std = new StudentRegistration();

            var number = db.StudentResigtrations.Single(x => x.id == id);

            std.Stu_Name = number.Stu_Name;
            std.Stu_imagePath = number.Stu_imagePath;
            std.Stu_Id = number.Stu_Id;
            std.Session = number.Session;
            std.Reg_No = number.Reg_No;
            std.PhoneNumber = number.PhoneNumber;
            std.PresentAddress = number.PresentAddress;
            std.PermanentAddress = number.PermanentAddress;
            std.FatherName = number.FatherName;
            std.MotherName = number.MotherName;
            std.EmailAddress = number.EmailAddress;
            std.Batch_No = number.Batch_No;
            std.Department = number.Department;
            std.Stu_imagePath = number.Stu_imagePath;

            ViewBag.data = number.Stu_imagePath;

            var dropdownitem = db.Departments.ToList();
            SelectList departmentlist = new SelectList(dropdownitem, "Name", "Name");
            std.DepartmentList = departmentlist;

            var Batchitem = db.Batchs.ToList();
            SelectList BatchitemList = new SelectList(Batchitem, "Name", "Name");
            std.BatchSelectList = BatchitemList;

            var Sessionitem = db.Sessions.ToList();
            SelectList SessionitemList = new SelectList(Sessionitem, "Name", "Name");
            std.SessionSelectList = SessionitemList;

            return View(std);
        }

        public ActionResult Delete(int? id)
        {

            StudentRegistration model = db.StudentResigtrations.Find(id);
            db.StudentResigtrations.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Search");
        }

        public ActionResult Details(int? id)
        {

            StudentRegistration std = new StudentRegistration();

            var number = db.StudentResigtrations.Single(x => x.id == id);

            std.Stu_Name = number.Stu_Name;
            std.Stu_imagePath = number.Stu_imagePath;
            std.Stu_Id = number.Stu_Id;
            std.Session = number.Session;
            std.Reg_No = number.Reg_No;
            std.PhoneNumber = number.PhoneNumber;
            std.PresentAddress = number.PresentAddress;
            std.PermanentAddress = number.PermanentAddress;
            std.FatherName = number.FatherName;
            std.MotherName = number.MotherName;
            std.EmailAddress = number.EmailAddress;
            std.Batch_No = number.Batch_No;
            std.Department = number.Department;
            std.Stu_imagePath = number.Stu_imagePath;

            return View(std);
        }

        [HttpGet]
        public ActionResult Fee(int? id, string massage)
        {
            StudentPayment Stu_Pay_model = new StudentPayment();

            var item = db.StudentResigtrations.Single(x => x.id == id);

            Stu_Pay_model.id = item.id;
            Stu_Pay_model.idCard_No = item.Stu_Id;
            Stu_Pay_model.Name = item.Stu_Name;
            Stu_Pay_model.Father_Name = item.FatherName;
            Stu_Pay_model.Mother_Name = item.MotherName;
            Stu_Pay_model.Department = item.Department;
            Stu_Pay_model.Phone_No = item.PhoneNumber;

            
            ViewBag.data = item.Stu_imagePath;

            //var DataList = db.StudentResigtrations.ToList();
            //SelectList idDataList = new SelectList(DataList, "Stu_Id", "Stu_Id");
            //Stu_Pay_model.idCardNoSelectItem = idDataList;

            //SelectList Stu_NameDataList = new SelectList(DataList, "Stu_Name", "Stu_Name");
            //Stu_Pay_model.NameSelectItem = Stu_NameDataList;

            //SelectList FatherNameDataList = new SelectList(DataList, "FatherName", "FatherName");
            //Stu_Pay_model.FatherNameSelectItem = FatherNameDataList;

            //SelectList MotherNameDataList = new SelectList(DataList, "MotherName", "MotherName");
            //Stu_Pay_model.MotherNameSelectItem = MotherNameDataList;

            //SelectList DepartmentDataList = new SelectList(DataList, "Department", "Department");
            //Stu_Pay_model.DepartmentSelectItem = DepartmentDataList;

            //SelectList PhoneNumberDataList = new SelectList(DataList, "PhoneNumber", "PhoneNumber");
            //Stu_Pay_model.PhoneNoSelectItem = PhoneNumberDataList;

            var batchDataItem = db.Batchs.ToList();
            SelectList BatchNameDataList = new SelectList(batchDataItem, "Name", "Name");
            Stu_Pay_model.SemesterSelectItem = BatchNameDataList;

            return View(Stu_Pay_model);
        }

        [HttpPost]
        public ActionResult Fee(StudentPayment dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.StudentPayments.Add(dto);
                    db.SaveChanges();

                    return RedirectToAction("Fee");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return View(dto);
        }

        [HttpPost]
        public ActionResult FeeSave(StudentPayment dto)
        {
            var data = 1;
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult Fee(StudentPayment Stu_Pay_model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.StudentPayments.Add(Stu_Pay_model);
        //        db.SaveChanges();

        //        return RedirectToAction("Fee");
        //    }

        //    var item = db.StudentResigtrations.Single(x => x.id == Stu_Pay_model.id);
        //    ViewBag.data = item.Stu_imagePath;

        //    var batchDataItem = db.Batchs.ToList();
        //    SelectList BatchNameDataList = new SelectList(batchDataItem, "Name", "Name");
        //    Stu_Pay_model.SemesterSelectItem = BatchNameDataList;

        //    return View(Stu_Pay_model);
        //}


        [HttpPost]
        public ActionResult GetReport()
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();


                string path = Path.Combine(Server.MapPath("/Reports"), "StudentInformation.rdlc");
                viewer.LocalReport.ReportPath = path;


                var periodDistribution = _report.GetData().ToList();
                var tr = new ReportDataSource("StudentDataset", periodDistribution);
                viewer.LocalReport.DataSources.Add(tr);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);


                string fileName = DateTime.Now.ToString("dd_MM_yyyy");
                string outputPath = "~/StudentRegistration";
                //var di = new DirectoryInfo(Server.MapPath(outputPath));
                if (System.IO.File.Exists(Server.MapPath(outputPath + fileName + ".pdf")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(outputPath + fileName + ".pdf"));
                    }
                    catch (Exception)
                    {
                        fileName = DateTime.Now.ToString("dd_MM_yyyy");
                    }
                }

                using (var stream = System.IO.File.Create(Path.Combine(Server.MapPath(outputPath), fileName + ".pdf")))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var pdfHref = "/StudentRegistration/" + fileName + ".pdf";

                return Json(pdfHref, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPost]
        public ActionResult StudentDitailsReport(int studentId)
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();


                string path = Path.Combine(Server.MapPath("/Reports"), "StudentDatails.rdlc");
                viewer.LocalReport.ReportPath = path;



                var periodDistribution = _report.GetStudentData(studentId);
                var tr = new ReportDataSource("StudentDitailsDataSet", periodDistribution);
                viewer.LocalReport.DataSources.Add(tr);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out streamIds, out warnings);


                string fileName = DateTime.Now.ToString("dd_MM_yyyy");
                string outputPath = "~/StudentRegistration";
                //var di = new DirectoryInfo(Server.MapPath(outputPath));
                if (System.IO.File.Exists(Server.MapPath(outputPath + fileName + ".pdf")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(outputPath + fileName + ".pdf"));
                    }
                    catch (Exception)
                    {
                        fileName = DateTime.Now.ToString("dd_MM_yyyy");
                    }
                }

                using (var stream = System.IO.File.Create(Path.Combine(Server.MapPath(outputPath), fileName + ".pdf")))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var pdfHref = "/StudentRegistration/" + fileName + ".pdf";

                return Json(pdfHref, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


	}
}


