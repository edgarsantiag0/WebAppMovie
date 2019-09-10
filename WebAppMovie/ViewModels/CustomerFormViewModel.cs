using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMovie.Models;

namespace WebAppMovie.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}