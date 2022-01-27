using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace StudentManagementSystem.Models
{
    public class StudentRegistration
    {
        [Key]
        public int id { get; set; }
        [Display(Name="Registration Number:")]
        public string Reg_No { get; set; }
        [Display(Name = "Student id Number:")]
        [Required(ErrorMessage="Please Enter Id Card Number.")]
        public string Stu_Id { get; set; }
        [Display(Name = "Student Name:")]
        [Required(ErrorMessage = "Please Enter Your Name.")]
        public string Stu_Name { get; set; }
        [Display(Name = "Student Image:")]
       
        public string Stu_imagePath { get; set; }
        [Display(Name = "Fatehr Name:")]
        public string FatherName { get; set; }
        [Display(Name = "Mother Name:")]
        public string MotherName { get; set; }
        [Display(Name = "Phone Number:")]
        [Required(ErrorMessage = "Please Enter Phone Number.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email:")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Not Valid Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Present Address:")]
        public string PresentAddress { get; set; }
        [Display(Name = "Permanet Address:")]
        public string PermanentAddress { get; set; }
        [Display(Name = "Session:")]
        [Required(ErrorMessage = "Please Enter Session.")]
        public string Session { get; set; }
        [Display(Name = "Department:")]
        [Required(ErrorMessage = "Please Enter Department.")]
        public string Department { get; set; }
        [Display(Name = "Batch NO:")]
        [Required(ErrorMessage = "Please Enter Batch.")]
        public string Batch_No { get; set; }


        [NotMapped]
        public IEnumerable< SelectListItem> DepartmentList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> BatchSelectList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SessionSelectList { get; set; }

        
        

    }
}