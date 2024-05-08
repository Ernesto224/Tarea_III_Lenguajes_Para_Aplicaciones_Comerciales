using Microsoft.EntityFrameworkCore;
using MinisuperZeus.BC.Modelos;
using MinisuperZeus.DA.Entidades;
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

        public DbSet<DeseoDA> deseoDAs { get; set; }

    }
}
