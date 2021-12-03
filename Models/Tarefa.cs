using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalProgInternet.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [StringLength(256, ErrorMessage = "Insira um nome com até 256 carateres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Selecione a Data Prevista de Início")]
        [DataType(DataType.Date)]
        [DisplayName("Data Prevista de Inicio")]
        public DateTime DataPrevistaInicio { get; set; }

        [Required(ErrorMessage = "Selecione a Data Prevista de Fim")]
        [DataType(DataType.Date)]
        [DisplayName("Data Prevista de Fim")]
        public DateTime DataPrevistaFim { get; set; }

        [DisplayName("Data Inicio")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data Fim")]
        public DateTime DataFim { get; set; }

        [DisplayName ("Projeto")]
        public int ProjetoId { get; set; }

        public Projeto Projeto { get; set; }

    }
}