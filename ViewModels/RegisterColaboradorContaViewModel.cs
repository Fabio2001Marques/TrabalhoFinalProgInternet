using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoFinalProgInternet.ViewModels
{
    public class RegisterColaboradorContaViewModel
    {
        public int ColaboradorContaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage ="The {0} deve ser pelo menos {2} e no maximo {1} carateres.",MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [DataType(DataType.Password)]
        [Display(Name = "Confirma a palavra-passe")]
        [Compare("Password",ErrorMessage = "As palavras-chave teem de coincidir")]
        public string ConfirmPassword { get; set; }
    }
}
