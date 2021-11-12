﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalProgInternet.Models
{
    public class Projetos
    {
        public int ProjetosId { get; set; }

        [Required(ErrorMessage = ("Preencha o campo Nome do projeto"))]
        [StringLength(256)]
        [DisplayName("Nome do projeto")]
        public string Name { get; set; }


    }
}
