using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalProgInternet.Models
{
    public class TarefaProjeto
    {
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }

        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de início")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayName("Data de Início")]
        public DateTime DataDeInicio { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data prevista de finalização")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayName("Data Prevista de Finalização")]
        public DateTime DataPrevista { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayName("Data de Finalização")]
        public DateTime DataDeFim { get; set; }

        [DisplayName("Colaborar")]
        public int ColaboradorId { get; set; }

        public Colaborador Nome { get; set; }

    }
}