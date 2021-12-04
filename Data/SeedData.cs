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
            //// Preencher Tabela Cargo
            //for (int i = 1; i <= 100; i++){
            //    gestorContext.Cargo.Add(
            //    new Cargo
            //    {
            //        Nome = "Cargo" + i
            //    }
            //    ) ;
            //}
            //gestorContext.SaveChanges();
            //Cargo cargo = gestorContext.Cargo.FirstOrDefault();

            //// Preencher Tabela Colaboradores
            //for (int i = 1; i <= 100; i++)
            //{
            //    gestorContext.Colaborador.Add(
            //    new Colaborador
            //    {
            //        Nome = "Teste" + i,
            //        Contacto = "923654178",
            //        Email = "teste"+i+"@gmail.com",
            //        NumeroCC = "12365478",
            //        Cargo = cargo
            //    }
            //    );
            //}
            //gestorContext.SaveChanges();

            ////== Preencher Tabela Cargo com dados reais


            //gestorContext.Cargo.Add(new Cargo { Nome = "Gestor" });
            //gestorContext.Cargo.Add(new Cargo { Nome = "Programador" });
            //gestorContext.Cargo.Add(new Cargo { Nome = "Tester" });
            //gestorContext.SaveChanges();

            ////== Preencher Tabela Colaborador com dados reais

            //gestorContext.Colaborador.Add(new Colaborador
            //{
            //    Nome = "Fábio Marques",
            //    Contacto = "923654178",
            //    Email = "fabio2001marques@gmail.com",
            //    NumeroCC = "12365478",
            //    Cargo = gestorContext.Cargo.Find(1)
            //});
            //gestorContext.Colaborador.Add(new Colaborador
            //{
            //    Nome = "Diogo Saraiva",
            //    Contacto = "912547896",
            //    Email = "diogosaraiva@gmail.com",
            //    NumeroCC = "32654178",
            //    Cargo = gestorContext.Cargo.Find(2)
            //});
            //gestorContext.Colaborador.Add(new Colaborador
            //{
            //    Nome = "Rafael Santos",
            //    Contacto = "965874123",
            //    Email = "rafaelsantos@gmail.com",
            //    NumeroCC = "12547896",
            //    Cargo = gestorContext.Cargo.Find(3)
            //});
            //gestorContext.SaveChanges();
            //}
        }
    }
