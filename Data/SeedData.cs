using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoFinalProgInternet.Models;

namespace TrabalhoFinalProgInternet.Data
{
    public class SeedData
    {


        private const string DEFAULT_ADMIN_USER = "admin@ipg.pt";
        private const string DEFAULT_ADMIN_PASSWORD = "Secret123$";

        private const string ROLE_ADMINISTRATOR = "Admin";
        private const string ROLE_COLABORADOR = "Colaborador";
        private const string ROLE_GESTOR = "Gestor";

        internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_USER, DEFAULT_ADMIN_PASSWORD, ROLE_ADMINISTRATOR);
        }

        private static async Task EnsureUserIsCreated(UserManager<IdentityUser> userManager, string username, string password, string role)
        {
            IdentityUser user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        internal static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await EnsureRoleIsCreated(roleManager, ROLE_ADMINISTRATOR);
            await EnsureRoleIsCreated(roleManager, ROLE_COLABORADOR);
            await EnsureRoleIsCreated(roleManager, ROLE_GESTOR);
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        internal static async Task SeedDevUsersAsync(UserManager<IdentityUser> userManager)
        {

            //await EnsureUserIsCreated(userManager, "john@ipg.pt", "Secret123$", ROLE_COLABORADOR);
            //await EnsureUserIsCreated(userManager, "mary@ipg.pt", "Secret123$", ROLE_GESTOR);
        }

        internal static void SeedDevData(GestorProjetosContext db)
        {

            //if (db.Colaborador.Any()) return;

            //db.Colaborador.Add(new Colaborador
            //{
            //    Nome = "Mary",
            //    Email = "mary@ipg.pt"
            //});

            //db.SaveChanges();

        }






        internal static void Populate(GestorProjetosContext gestorContext)
        {


            var colaboradoresProjeto = gestorContext.ColaboradorProjeto.FirstOrDefault();

            if (gestorContext.Cargo.FirstOrDefault() == null)
            {
                PreencherDadosReaisCargo(gestorContext);
            }
            if (gestorContext.Colaborador.FirstOrDefault() == null)
            {
                PreencherDadosReaisColaborador(gestorContext);
            }
            if (gestorContext.Projeto.FirstOrDefault() == null)
            {
                PreencherDadosReaisProjetos(gestorContext);
            }
            if (gestorContext.Tarefa.FirstOrDefault() == null)
            {
                PreencherDadosReaisTarefas(gestorContext);
            }



            
            
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
                    Descricao = "descri????o" + i,
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
                Nome = "F??bio Marques",
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
                Descricao = "Criar uma janela que permita a visualiza????o dos detalhes",
                DataPrevistaInicio = new DateTime(2022,01,05),
                DataPrevistaFim = new DateTime(2022, 01, 10),
                DataInicio = null,
                DataFim = null,
                Projeto = gestorContext.Projeto.Find(1),
                Colaborador = gestorContext.Colaborador.Find(1)
            });

            gestorContext.Tarefa.Add(new Tarefa
            {
                Nome = "Realizar pagina????o para a tabela Tarefa",
                Descricao = "Fazer a pagina????o nas views: 'create', 'details', 'edit', 'delete' e 'index'",
                DataPrevistaInicio = new DateTime(2022, 01, 15),
                DataPrevistaFim = new DateTime(2022, 01, 18),
                DataInicio = null,
                DataFim = null,
                Projeto = gestorContext.Projeto.Find(1),
                Colaborador = gestorContext.Colaborador.Find(1)
            });

            gestorContext.Tarefa.Add(new Tarefa
            {
                Nome = "Criar fun????o 'Pesquisa'",
                Descricao = "Criar uma fun????o que permita a pesquisa por nome de um projeto",
                DataPrevistaInicio = new DateTime(2022, 01, 11),
                DataPrevistaFim = new DateTime(2022, 01, 12),
                DataInicio = null,
                DataFim = null, 
                Projeto = gestorContext.Projeto.Find(1),
                Colaborador = gestorContext.Colaborador.Find(1)
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


