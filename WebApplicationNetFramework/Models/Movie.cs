using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationNetFramework.Models
{
    public class Movie
    {
        public int  Id { get; set; }
        public  string Name { get; set; }
        public string Genre { get; set; }

        [Display(Name = "Number in Stock")]
        public int Copies { get; set; } = 0;

        public override string ToString()
        {
            return $"{Id} {Name} {Genre} Copies:{Copies}";
        }
    }
}