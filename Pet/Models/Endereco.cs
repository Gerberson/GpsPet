using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public int DonoId { get; set; }
        public ICollection<Dono> Dono { get; set; } = new List<Dono>();
        public Cidade Cidade { get; set; }
    }
}
