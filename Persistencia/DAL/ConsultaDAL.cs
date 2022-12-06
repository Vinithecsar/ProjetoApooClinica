﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
using Modelo;
using Persistencia.Contexts;

namespace Persistencia.DAL
{
    public class ConsultaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Consulta> ObterConsultasClassificadasPorId()
        {
            return context.Consultas.Include(c => c.Pet).Include(a => a.Veterinario).OrderBy(b => b.ConsultaId);
        }
        public Consulta ObterConsultasPorId(long id)
        {
            return context.Consultas.Where(f => f.ConsultaId == id).Include(c => c.Pet).Include(a => a.Veterinario).First();
        }
        public void GravarConsulta(Consulta consulta)
        {
            if (consulta.ConsultaId == 0)
            {
                context.Consultas.Add(consulta);
            }
            else
            {
                context.Entry(consulta).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Consulta EliminarConsultaPorId(long id)
        {
            Consulta consulta = ObterConsultasPorId(id);
            context.Consultas.Remove(consulta);
            context.SaveChanges();
            return consulta;
        }
    }
}
