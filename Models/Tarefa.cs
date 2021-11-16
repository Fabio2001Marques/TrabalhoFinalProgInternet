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
        [StringLength(256, ErrorMessage = "Insira um nome com at� 256 carateres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descri��o")]
        [DisplayName("Descri��o")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de in�cio")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data v�lida")]
        [DisplayName("Data de In�cio")]
        public DateTime DataDeInicio { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Insira uma data v�lida")]
        [DisplayName("Data de Finaliza��o")]
        public DateTime DataDeFim { get; set; }


        //TODO: A dicionar chave estrangeira para o model Projeto
    }
}