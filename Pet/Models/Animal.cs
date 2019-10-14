using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Models
{
    public class Animal : Dados
    {
        public string Raca { get; set; }
        public int Idade { get => DateTime.Now.Year - DataNascimento.Year;}
        public int LocalizacaoId { get; set; }
        public ICollection<Localizacao> Localizacaoes { get; set; } = new List<Localizacao>();
        public Dono Dono { get; set; }
    }
}
