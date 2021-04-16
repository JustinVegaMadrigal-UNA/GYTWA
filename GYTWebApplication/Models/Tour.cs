using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYTWebApplication.Models
{
    //public class Tour
    //{
    //}

    public class Tour
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Destino { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaArrivo { get; set; }
        public double Precio { get; set; }
        public string IncluyePaquete { get; set; }
        public string NoIncluyePaquete { get; set; }
        public int cupoMaximo { get; set; }
        //public List<TourCategoria> ToursCategoria { get; set; }
    }
}
