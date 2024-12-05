using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactManagementSystem.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}