using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pet.Models;

namespace Pet.Models
{
    public class PetContext : DbContext
    {
        public PetContext (DbContextOptions<PetContext> options)
            : base(options)
        {
        }
        public DbSet<Pet.Models.Estado> Estado { get; set; }
        public DbSet<Pet.Models.Cidade> Cidade { get; set; }
        public DbSet<Pet.Models.Endereco> Endereco { get; set; }
        public DbSet<Pet.Models.Dados> Dados { get; set; }
        public DbSet<Pet.Models.Animal> Animal { get; set; }
        public DbSet<Pet.Models.Localizacao> Localizacao { get; set; }
        public DbSet<Pet.Models.Rastreador> Rastreador { get; set; }
        public DbSet<Pet.Models.Dono> Dono { get; set; }
    }
}
