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

            for (int i = 1; i <= 100; i++){
                gestorContext.Cargo.Add(
                new Cargo
                {
                    Nome = "Cargo" + i
                }
                ) ;
            }
            Cargo cargo = gestorContext.Cargo.FirstOrDefault();

            for (int i = 1; i <= 100; i++)
            {
                gestorContext.Colaborador.Add(
                new Colaborador
                {
                    Nome = "Teste" + i,
                    Contacto = "923654178",
                    Email = "teste"+i+"@gmail.com",
                    NumeroCC = "12365478",
                    Cargo = cargo
                }
                );
            }
            gestorContext.SaveChanges();
        }
    }
}
