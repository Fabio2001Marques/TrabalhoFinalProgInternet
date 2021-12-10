using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoFinalProgInternet.Models;

namespace TrabalhoFinalProgInternet.ViewModels
{
    public class ColaboradorListViewModel
    {
        public IEnumerable<Colaborador> Colaboradores { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ProcuraNome { get; set; }
    }
}
