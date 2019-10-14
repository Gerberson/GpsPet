using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
        public Estado Estado { get; set; }
    }
}
