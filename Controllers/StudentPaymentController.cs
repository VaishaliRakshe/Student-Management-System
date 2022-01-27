using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentPaymentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        //
        // GET: /StudentPayment/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            StudentPayment model = new StudentPayment();

            var item = db.StudentResigtrations.Single(x=>x.id==id);

            model.idCard_No = item.Stu_Id;
            model.Name = item.Stu_Name;
            model.Father_Name = item.FatherName;
            model.Mother_Name = item.MotherName;
            model.Department = item.MotherName;
            model.Phone_No = item.PhoneNumber;
            
            
            var DataList = db.StudentResigtrations.ToList();

            SelectList idDataList = new SelectList(DataList, "Stu_Id", "Stu_Id");
            model.idCardNoSelectItem = idDataList;

            SelectList Stu_NameDataList = new SelectList(DataList, "Stu_Name", "Stu_Name");
            model.NameSelectItem = Stu_NameDataList;

            SelectList FatherNameDataList = new SelectList(DataList, "FatherName", "FatherName");
            model.FatherNameSelectItem = FatherNameDataList;

            SelectList MotherNameDataList = new SelectList(DataList, "MotherName", "MotherName");
            model.MotherNameSelectItem = MotherNameDataList;

            SelectList DepartmentDataList = new SelectList(DataList, "Department", "Department");
            model.DepartmentSelectItem = DepartmentDataList;

            SelectList PhoneNumberDataList = new SelectList(DataList, "PhoneNumber", "PhoneNumber");
            model.PhoneNoSelectItem = PhoneNumberDataList;

            var batchDataItem = db.Batchs.ToList();
            SelectList BatchNameDataList = new SelectList(batchDataItem, "Name", "Name");
            model.SemesterSelectItem = BatchNameDataList;


            return View(model);
        }

        [HttpPost]
        public ActionResult Create(StudentPayment model)
        {
            db.StudentPayments.Add(model);
            db.SaveChanges();
            return View(model);
        }


	}
}