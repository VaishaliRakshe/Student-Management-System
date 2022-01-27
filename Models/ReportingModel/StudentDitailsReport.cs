using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Manager
{
    public class StudentDitailsReport
    {
        public string StudentName { get; set; }
        public string ResigtationNumber { get; set; }
        public string StudentId { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Session { get; set; }
        public string Department { get; set; }
        public string Batch { get; set; }
    }
}