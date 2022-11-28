using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        [Key]
        public long UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

    }
}
