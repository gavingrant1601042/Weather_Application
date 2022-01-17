using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Employee
    {
        [Key]
        public string EmailId { get; set; }
        public string FirstName{ get; set; }
        public string Lastname { get; set; }
        public string city{ get; set; }
        public string country { get; set; }
        public string telephone { get; set; }
        public string  role { get; set; }
        public string address_location { get; set; }
        public string password { get; set; }
    }
}
