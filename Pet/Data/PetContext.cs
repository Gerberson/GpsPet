using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pet.Models
{
    public class PetContext : DbContext
    {
        public PetContext (DbContextOptions<PetContext> options)
            : base(options)
        {
        }
    }
}
