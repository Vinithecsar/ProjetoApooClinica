using Modelo;
using Persistencia.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistencia.DAL
{
    public class TelefoneDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Telefone> ObterTelefonesClassificadosPorDdd()
        {
            return context.Telefones.OrderBy(b => b.Ddd);
        }
        public Telefone ObterTelefonePorId(long id)
        {
            return context.Telefones.Where(f => f.TelefoneId == id).First();
        }
        public void GravarTelefone(Telefone telefone)
        {
            if (telefone.TelefoneId == 0)
            {
                context.Telefones.Add(telefone);
            }
            else
            {
                context.Entry(telefone).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Telefone EliminarTelefonePorId(long id)
        {
            Telefone telefone = ObterTelefonePorId(id);
            context.Telefones.Remove(telefone);
            context.SaveChanges();
            return telefone;
        }
        
    }
}
