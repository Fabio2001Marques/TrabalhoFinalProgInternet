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

            modelBuilder.Entity<ColaboradorProjeto>()
                .HasOne(cp => cp.Colaborador)
                .WithMany(c => c.ColaboradorProjetos)
                .HasForeignKey(cp => cp.ColaboradorId);

            modelBuilder.Entity<ColaboradorProjeto>()
                .HasOne(cp => cp.Projeto)
                .WithMany(p => p.ProjetoColaboradores)
                .HasForeignKey(cp => cp.ProjetoId);

            modelBuilder.Entity<TarefaProjeto>()
                .HasKey(tp => new { tp.TarefaId, tp.ProjetoId });

            modelBuilder.Entity<TarefaProjeto>()
                .HasOne(tp => tp.Tarefa)
                .WithMany(t => t.TarefaProjetos)
                .HasForeignKey(tp => tp.TarefaId);

            modelBuilder.Entity<TarefaProjeto>()
                .HasOne(tp => tp.Projeto)
                .WithMany(p => p.ProjetoTarefas)
                .HasForeignKey(tp => tp.ProjetoId);


            var foreignKeysWithCascadeDelete = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in foreignKeysWithCascadeDelete)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            
            
        }


            

        public DbSet<TrabalhoFinalProgInternet.Models.Colaborador> Colaborador { get; set; }

        public DbSet<TrabalhoFinalProgInternet.Models.Projeto> Projeto { get; set; }

        public DbSet<TrabalhoFinalProgInternet.Models.Tarefa> Tarefa { get; set; }

        public DbSet<TrabalhoFinalProgInternet.Models.Cargo> Cargo { get; set; }

        public DbSet<TrabalhoFinalProgInternet.Models.ColaboradorProjeto> ColaboradorProjeto { get; set; }

        public DbSet<TrabalhoFinalProgInternet.Models.TarefaProjeto> TarefaProjetos { get; set; }

    }
}
