using System;
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
        public IQueryable<Consulta> ObterConsultasClassificadosPorId()
        {
            return context.Consultas.OrderBy(b => b.ConsultaId);
        }
        public Consulta ObterConsultasPorId(long id)
        {
            return context.Consultas.Where(f => f.ConsultaId == id).First();
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
