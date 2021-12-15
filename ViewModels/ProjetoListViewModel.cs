using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoFinalProgInternet.Models;

namespace TrabalhoFinalProgInternet.ViewModels
{
    public class ProjetoListViewModel
    {
        public IEnumerable<Projeto> Projetos { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string ProcuraNome { get; set; }
    }
}
