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
        [StringLength(256, ErrorMessage = "Insira um nome com at� 256 carateres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descri��o")]
        [DisplayName("Descri��o")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de in�cio")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data v�lida")]
        [DisplayName("Data de In�cio")]
        public DateTime DataDeInicio { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data de in�cio")]
        [DataType(DataType.Date, ErrorMessage = "Insira uma data v�lida")]
        [DisplayName("Data Prevista de Finaliza��o")]
        public DateTime DataPrevista { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Insira uma data v�lida")]
        [DisplayName("Data de Finaliza��o")]
        public DateTime DataDeFim { get; set; }

        [DisplayName ("Projeto")]
        public int ProjetoId { get; set; }

        public Projeto Projeto { get; set; }
    }
}