using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalProgInternet.Models
{
    public class Tarefas
    {
        public int TarefaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [StringLength(256, ErrorMessage = "Insira um nome com até 256 carateres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de início")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayName("Data de Início")]
        public DateTime DataDeInicio { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Insira uma data válida")]
        [DisplayName("Data de Finalização")]
        public DateTime DataDeFim { get; set; }


        //TODO: A dicionar chave estrangeira para o model Projeto
    }
}