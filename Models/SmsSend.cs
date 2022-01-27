using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class SmsSend
    {

        public int id { get; set; }
        public int SmsType { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}