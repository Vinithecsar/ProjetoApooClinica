using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
using Modelo;
using Persistencia.Contexts;

namespace Persistencia.DAL
{
    public class ExameDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Exame> ObterExamesClassificadosPorId()
        {
            return context.Exames.OrderBy(b => b.ExameId);
        }
        public Exame ObterExamesPorId(long id)
        {
            return context.Exames.Where(f => f.ExameId == id).First();
        }
        public void GravarExame(Exame exame)
        {
            if (exame.ExameId == 0)
            {
                context.Exames.Add(exame);
            }
            else
            {
                context.Entry(exame).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Exame EliminarExamePorId(long id)
        {
            Exame exame = ObterExamesPorId(id);
            context.Exames.Remove(exame);
            context.SaveChanges();
            return exame;
        }
    }
}
