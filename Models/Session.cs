using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Session
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Please Enter Session.")]
        [Display(Name = "Session:")]
        public string Name { get; set; }
    }
}