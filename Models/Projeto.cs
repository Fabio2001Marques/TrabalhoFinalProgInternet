﻿using System;
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

        [Required(ErrorMessage = ("Preencha o campo Nome do projeto"))]
        [DataType(DataType.Date)]
        [DisplayName("Data Inicio")]
        public DateTime DataInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data Final")]
        public DateTime DataFinal { get; set; }

        public ICollection<ColaboradorProjeto> ProjetoColaboradores { get; set; }

    }
}
