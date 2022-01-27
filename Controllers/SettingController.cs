using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class SettingController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Setting/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddDepartdment()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddDepartdment(Department model)
        {
            db.Departments.Add(model);
            db.SaveChanges();
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult Batch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Batch(Batch model)
        {
            db.Batchs.Add(model);
            db.SaveChanges();
            ModelState.Clear();
            return View("Batch");
        }



        [HttpGet]
        public ActionResult Session()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Session(Session model)
        {
            db.Sessions.Add(model);
            db.SaveChanges();
            ModelState.Clear();
            return View("Session");
        }

	}
}