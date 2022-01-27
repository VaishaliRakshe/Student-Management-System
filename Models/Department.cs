using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage="Please Enter Department Name")]
        [Display(Name="Department Name:")]
        public string Name { get; set; }
    }
}