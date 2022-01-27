using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models
{
    public class StudentPayment
    {
        [Key]
        public int id { get; set; }
        [Display(Name="Id Card No: ")]
        [Required(ErrorMessage="Please Select id No.")]
        public string idCard_No { get; set; }
        [Required(ErrorMessage = "Please Select Name.")]
        public string Name { get; set; }
        [Display(Name = "Father Name: ")]
        [Required(ErrorMessage = "Please Select Father name.")]
        public string Father_Name { get; set; }
        [Display(Name = "Mother Name: ")]
        [Required(ErrorMessage = "Please Select mother name.")]
        public string Mother_Name { get; set; }
        [Display(Name = "Department: ")]
        [Required(ErrorMessage = "Please Select Department.")]
        public string Department { get; set; }
        [Display(Name = "Phone No: ")]
        [Required(ErrorMessage = "Please Select phone No.")]
        public string Phone_No { get; set; }
        [Display(Name = "Semester: ")]
        [Required(ErrorMessage = "Please Select Semester.")]
        public string Semester { get; set; }
        [Display(Name = "Semester Fee: ")]
        [Required(ErrorMessage = "Please Enter Semester Fee.")]
        public string Amount { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> idCardNoSelectItem { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> NameSelectItem { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> FatherNameSelectItem { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> MotherNameSelectItem { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DepartmentSelectItem { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> PhoneNoSelectItem { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SemesterSelectItem { get; set; }

    }
}