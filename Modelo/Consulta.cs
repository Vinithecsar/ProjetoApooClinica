using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Consulta
    {
        public long ConsultaId { get; set; }
        public DateTime Data_hora { get; set; }
        public string Sintomas { get; set; }
        public virtual ICollection<Exame> Exames { get; set; }
        public long PetId { get; set; }
        public Pet Pet { get; set; }
        public long UsuarioId { get; set; }
        public Veterinario Veterinario { get; set; }
    }
}
