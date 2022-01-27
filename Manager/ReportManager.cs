using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ReportingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Manager
{
    public class ReportManager
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<StudentInfoReport> GetData()
        {
            var list = new List<StudentInfoReport>();

            var studentList = _db.StudentResigtrations.ToList();

            foreach (var student in studentList)
            {
                var s = new StudentInfoReport()
                {
                    Name = student.Stu_Name,
                    RegistrationNumber = student.Reg_No,
                    StudentId = student.Stu_Id,
                    FatherName = student.FatherName,
                    MotherName = student.MotherName,
                    PhoneNumber = student.PhoneNumber
                };

                list.Add(s);
            }

            return list;
        }


        public StudentDitailsReport GetStudentData(int studentId)
        {

            var studens = _db.StudentResigtrations.Single(c => c.id == studentId);

            var s = new StudentDitailsReport()
            {
                StudentName = studens.Stu_Name,
                ResigtationNumber = studens.Reg_No,
                StudentId = studens.Stu_Id,
                FatherName = studens.FatherName,
                MotherName = studens.MotherName,
                PhoneNumber = studens.PhoneNumber,
                EmailAddress = studens.EmailAddress,
                PresentAddress = studens.PresentAddress,
                PermanentAddress = studens.PermanentAddress,
                Session = studens.Session,
                Department = studens.Department,
                Batch = studens.Batch_No
            };

            return s;
        }

        public IEnumerable<StudentPayment> GetAll()
        {
            var infos = _db.StudentPayments.ToList();
            return infos;
        }

    }
}