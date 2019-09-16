using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMovie.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string Cargo { get; set; }

    }
}