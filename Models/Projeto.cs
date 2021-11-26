using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalProgInternet.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }

        [Required(ErrorMessage = ("Preencha o campo Nome do projeto"))]
        [StringLength(256)]
        [DisplayName("Nome do projeto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = ("Preencha a Data do inicio do projeto"))]
        [DataType(DataType.Date)]
        [DisplayName("Data Inicio")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = ("Preencha com a data prevista do fim do projeto"))]
        [DataType(DataType.Date)]
        [DisplayName("Data Prevista")]
        public DateTime DataPrevista { get; set; }


        [DataType(DataType.Date)]
        [DisplayName("Data Final")]
        public DateTime DataFinal { get; set; }

        [Required(ErrorMessage = ("Preencha com o nome do Responsável/Gestor"))]
        [DisplayName("Gestor")]
        public int ColaboradorId { get; set; }

        public Colaborador colaborador { get; set; }


        public ICollection<ColaboradorProjeto> ProjetoColaboradores { get; set; }

        public ICollection<TarefaProjeto> ProjetoTarefas { get; set; }

    }
}

