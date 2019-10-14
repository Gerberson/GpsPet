using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Models
{
    public class Dono : Dados
    {
        public int Cpf { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get => DateTime.Now.Year - DataNascimento.Year; }
        public int AnimalId { get; set; }
        public ICollection<Animal> Animais { get; set; } = new List<Animal>();
        public Endereco End { get; set; }
    }
}
