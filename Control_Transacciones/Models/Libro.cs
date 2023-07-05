using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Transacciones.Models
{
    public class Libro
    {
        public int Libroid { get; set; }
        public string Titulo { get; set; }
        public int Paginas { get; set; }
        public Genero genero { get; set; }
        public Autor autor { get; set; }



    }
}
