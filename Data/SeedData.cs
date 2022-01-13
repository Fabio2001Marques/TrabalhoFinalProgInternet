//#define TEST_PAGINATION_BOOKS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoFinalProgInternet.Models;

namespace TrabalhoFinalProgInternet.Data
{
    public class SeedData
    {
        internal static void Populate(GestorProjetosContext gestorContext)
        {
#if TEST_PAGINATION_BOOKS
            //PreencherDadosFicticiosCargo(gestorContext);
            //PreencherDadosFicticiosColaboradores(gestorContext);
            PreencherDadosReaisCargo(gestorContext);
            PreencherDadosReaisColaborador(gestorContext);
#endif
        }
        private static void PreencherDadosFicticiosCargo(GestorProjetosContext gestorContext)
        {
            for (int i = 1; i <= 100; i++)
            {
                gestorContext.Cargo.Add(new Cargo{Nome = "Cargo" + i});
            }
            gestorContext.SaveChanges();
        }
        private static void PreencherDadosFicticiosColaboradores(GestorProjetosContext gestorContext)
        {
            Cargo cargo = gestorContext.Cargo.FirstOrDefault();
            for (int i = 1; i <= 100; i++)
            {
                gestorContext.Colaborador.Add(new Colaborador{
                    Nome = "Teste" + i,
                    Contacto = "923654178",
                    Email = "teste" + i + "@gmail.com",
                    NumeroCC = "12365478",
                    Cargo = cargo});
            }
            gestorContext.SaveChanges();
        }
        private static void PreencherDadosReaisCargo(GestorProjetosContext gestorContext)
        {
            gestorContext.Cargo.Add(new Cargo { Nome = "Gestor" });
            gestorContext.Cargo.Add(new Cargo { Nome = "Programador" });
            gestorContext.Cargo.Add(new Cargo { Nome = "Tester" });
            gestorContext.SaveChanges();
        }
        private static void PreencherDadosReaisColaborador(GestorProjetosContext gestorContext)
        {
            gestorContext.Colaborador.Add(new Colaborador{
                Nome = "Fábio Marques",
                Contacto = "923654178",
                Email = "fabio2001marques@gmail.com",
                NumeroCC = "12365478",
                Cargo = gestorContext.Cargo.Find(1)});

            gestorContext.Colaborador.Add(new Colaborador{
                Nome = "Diogo Saraiva",
                Contacto = "912547896",
                Email = "diogosaraiva@gmail.com",
                NumeroCC = "32654178",
                Cargo = gestorContext.Cargo.Find(2)});

            gestorContext.Colaborador.Add(new Colaborador{
                Nome = "Rafael Santos",
                Contacto = "965874123",
                Email = "rafaelsantos@gmail.com",
                NumeroCC = "12547896",
                Cargo = gestorContext.Cargo.Find(3)});

            gestorContext.SaveChanges();
        }

        private static void PreencherDadosReaisTarefas(GestorProjetosContext gestorContext)
        {
            gestorContext.Tarefa.Add(new Tarefa
            {
                Nome = "Nova janela",
                Descricao = "Criar uma janela que permita a visualização dos detalhes",
                DataPrevistaInicio = new DateTime(2022,01,05),
                DataPrevistaFim = new DateTime(2022, 01, 10),
                DataInicio = null,
                DataFim = null,
                Projeto = gestorContext.Projeto.Find(1)
            });


            gestorContext.SaveChanges();
        }



    }    
}


