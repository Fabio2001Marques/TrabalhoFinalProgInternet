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
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage = "As palavras-chave teem de coincidir")]
        public string ConfirmPassword { get; set; }
    }
}
