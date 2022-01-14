#define TEST_PAGINATION_GESTOR
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
#if TEST_PAGINATION_GESTOR
            //PreencherDadosFicticiosCargo(gestorContext);
            //PreencherDadosFicticiosColaboradores(gestorContext);
            //PreencherDadosFicticiosTarefas(gestorContext);
            PreencherDadosReaisCargo(gestorContext);
            PreencherDadosReaisColaborador(gestorContext);
            PreencherDadosReaisTarefas(gestorContext);
            PreencherDadosReaisProjetos(gestorContext);
            
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

        private static void PreencherDadosFicticiosTarefas(GestorProjetosContext gestorContext)
        {
            Projeto projeto = new Projeto();
            projeto.Nome = "TesteTarefa";
            projeto.DataFinalPrevista = new DateTime(2022, 01, 12);
            projeto.DataInicialPrevista = new DateTime(2022, 01, 12);
            projeto.DataFinal = null;
            projeto.DataInicio = null;
            projeto.colaborador = gestorContext.Colaborador.Find(1);
            for (int i = 1; i <= 100; i++)
            {
                gestorContext.Tarefa.Add(new Tarefa
                {
                    Nome = "Teste" + i,
                    Descricao = "descrição" + i,
                    DataPrevistaInicio = new DateTime(2022, 01, 11),
                    DataPrevistaFim = new DateTime(2022, 01, 12),
                    DataInicio = new DateTime(2022, 01, 18),
                    DataFim = new DateTime(2022, 01, 18),
                    Projeto = projeto
                });
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
            Projeto projeto = new Projeto();
            projeto.Nome = "TesteTarefa";
            projeto.DataFinalPrevista = new DateTime(2022, 01, 12);
            projeto.DataInicialPrevista = new DateTime(2022, 01, 12);
            projeto.DataFinal = null;
            projeto.DataInicio = null;
            projeto.colaborador = gestorContext.Colaborador.Find(1);

            gestorContext.Tarefa.Add(new Tarefa
            {
                Nome = "Nova janela",
                Descricao = "Criar uma janela que permita a visualização dos detalhes",
                DataPrevistaInicio = new DateTime(2022,01,05),
                DataPrevistaFim = new DateTime(2022, 01, 10),
                DataInicio = new DateTime(2022, 01, 18),
                DataFim = new DateTime(2022, 01, 18),
                Projeto = projeto
            });

            gestorContext.Tarefa.Add(new Tarefa
            {
                Nome = "Realizar paginação para a tabela Tarefa",
                Descricao = "Fazer a paginação nas views: 'create', 'details', 'edit', 'delete' e 'index'",
                DataPrevistaInicio = new DateTime(2022, 01, 15),
                DataPrevistaFim = new DateTime(2022, 01, 18),
                DataInicio = new DateTime(2022, 01, 18),
                DataFim = new DateTime(2022, 01, 18),
                Projeto = projeto
            });

            gestorContext.Tarefa.Add(new Tarefa
            {
                Nome = "Criar função 'Pesquisa'",
                Descricao = "Criar uma função que permita a pesquisa por nome de um projeto",
                DataPrevistaInicio = new DateTime(2022, 01, 11),
                DataPrevistaFim = new DateTime(2022, 01, 12),
                DataInicio = new DateTime(2022, 01, 18),
                DataFim = new DateTime(2022, 01, 18),
                Projeto = projeto
            });

            gestorContext.SaveChanges();
        }

        private static void PreencherDadosReaisProjetos(GestorProjetosContext gestorContext)
        {
           
            gestorContext.Projeto.Add(new Projeto
            {
                Nome = "Obras",
                DataFinalPrevista = new DateTime(2022, 01, 05),
                DataInicialPrevista = new DateTime(2022, 01, 10),
                DataInicio = null,
                DataFinal = null,
               colaborador = gestorContext.Colaborador.Find(1)   
        });
            gestorContext.Projeto.Add(new Projeto
            {
                Nome = "Biblioteca",
                DataFinalPrevista = new DateTime(2022, 01, 15),
                DataInicialPrevista = new DateTime(2022, 01, 20),
                DataInicio = null,
                DataFinal = null,
                colaborador = gestorContext.Colaborador.Find(2)
            });

            gestorContext.Projeto.Add(new Projeto
            {
                Nome = "Jogo",
                DataFinalPrevista = new DateTime(2022, 01, 21),
                DataInicialPrevista = new DateTime(2022, 01, 22),
                DataInicio = null,
                DataFinal = null,
                colaborador = gestorContext.Colaborador.Find(3)
            });

            gestorContext.SaveChanges();
        }


    }    
}


