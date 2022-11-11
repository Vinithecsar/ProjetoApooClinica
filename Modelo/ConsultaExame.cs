using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ConsultaExame
    {
        public int ConsultaExameId { get; set; }
        public int ConsultaId { get; set; }
        public int ExameId { get; set; }
        public virtual Consulta Consulta { get; set; }
        public virtual Exame Exame { get; set; }
    }
}
