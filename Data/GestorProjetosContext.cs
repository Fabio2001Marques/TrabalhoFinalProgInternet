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

        public DbSet<TrabalhoFinalProgInternet.Models.Colaborador> Colaborador { get; set; }

        public DbSet<TrabalhoFinalProgInternet.Models.Projeto> Projeto { get; set; }

        public DbSet<TrabalhoFinalProgInternet.Models.Tarefa> Tarefa { get; set; }

        public DbSet<TrabalhoFinalProgInternet.Models.Cargo> Cargo { get; set; }

    }
}
