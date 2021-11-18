using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoFinalProgInternet.Models;

namespace TrabalhoFinalProgInternet.Data
{
    public class GestorProjetosContext : DbContext
    {
        public GestorProjetosContext(DbContextOptions<GestorProjetosContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColaboradorProjeto>()
                .HasKey(cp => new { cp.ColaboradorId, cp.ProjetoId });
        }

    }
}
