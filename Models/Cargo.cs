using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalProgInternet.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string cargo { get; set; }
    }
}