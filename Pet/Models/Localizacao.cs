using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Models
{
    public class Localizacao
    {
        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Rastreador Rastreador { get; set; }
        public Animal Animal { get; set; }
    }
}
