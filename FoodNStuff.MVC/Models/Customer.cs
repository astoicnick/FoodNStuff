using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodNStuff.MVC.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        //public string Fullname => $"{FirstName} {LastName}";
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        

    }
}