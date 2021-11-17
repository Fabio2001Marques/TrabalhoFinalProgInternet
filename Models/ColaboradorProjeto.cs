using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalProgInternet.Models
{
    public class ColaboradorProjeto
    {
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }

        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de entrada")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayName("Data de Entrada")]
        public DateTime DataDeInicio { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayName("Data de Saída")]
        public DateTime DataDeSaida { get; set; }
    }
}
