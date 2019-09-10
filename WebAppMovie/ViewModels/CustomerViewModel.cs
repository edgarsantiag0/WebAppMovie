using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMovie.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Movie> Movies { get; set; }

        public CustomerViewModel()
        {
              Movies = new List<Movie>();
        }

     

    }
}