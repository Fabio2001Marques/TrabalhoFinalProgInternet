using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoFinalProgInternet.Models;

namespace TrabalhoFinalProgInternet.ViewModels
{
    public class ColaboradorViewModel
    {
        public int ColaboradorId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [StringLength(128, ErrorMessage = "O seu nome não pode conter mais do que 128 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cartão de cidadão")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Número de CC inválido")]
        [DisplayName("Cartão de Cidadão")]
        public string NumeroCC { get; set; }

        [Required(ErrorMessage = "Preencha o campo Contacto")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Contacto inválido")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Preencha o campo Email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [DisplayName("Cargo")]
        public int CargoId { get; set; }

        public string NovoCargo { get; set; }

        public ICollection<ColaboradorProjeto> ColaboradorProjetos { get; set; }

    }
}

