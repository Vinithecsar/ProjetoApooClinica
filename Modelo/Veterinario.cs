﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Veterinario : Usuario
    {
        public string crmv { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
