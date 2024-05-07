using Microsoft.EntityFrameworkCore;
using MinisuperZeus.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinisuperZeus.DA.Contexto
{
    public class MinisuperZeusContext : DbContext
    {
        public MinisuperZeusContext(DbContextOptions options) 
        : base(options) 
        { 
        }

        public DbSet<ProductoDA> productoDAs { get; set; }
    }
}
