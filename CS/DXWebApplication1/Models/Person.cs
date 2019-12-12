using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models {
    public class Person {
        public Person() { }
        [Key]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Field is required")]
        public string LastName { get; set; }

        public int Age { get; set; }
        public int Status { get; set; }
    }
}