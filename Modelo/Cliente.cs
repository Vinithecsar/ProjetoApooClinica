using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente : Usuario
    {
        public string Cpf { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
