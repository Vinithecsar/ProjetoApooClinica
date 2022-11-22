﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ConsultaExame
    {
        public long ConsultaExameId { get; set; }
        public long ConsultaId { get; set; }
        public long ExameId { get; set; }
        public virtual Consulta Consulta { get; set; }
        public virtual Exame Exame { get; set; }
    }
}
