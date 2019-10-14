using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Models
{
    public class Rastreador
    {
        [Key]
        public int Id { get; set; }
        public string NumeroDeSerie { get; set; }
        public int LocalizacaoId { get; set; }
        public ICollection<Localizacao> Localizacaoes { get; set; } = new List<Localizacao>();
    }
}
