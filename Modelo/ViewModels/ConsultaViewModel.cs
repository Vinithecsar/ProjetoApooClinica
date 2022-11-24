using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.ViewModels
{
    public class ConsultaViewModel
    {
        public long ConsultaId { get; set; }
        public DateTime Data_hora { get; set; }
        public string Sintomas { get; set; }
        public List<CheckBoxViewModel> Exames { get; set; }
    }
}
