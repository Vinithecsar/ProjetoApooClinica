using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Telefone
    {
        public long TelefoneId { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public long IdCliente { get; set; }
    }
}
