using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
using Modelo;
using Persistencia.Contexts;

namespace Persistencia.DAL
{
    public class EnderecoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Endereco> ObterEnderecosClassificadosPorId()
        {
            return context.Enderecos.Include(c => c.Cliente).OrderBy(b => b.EnderecoId);
        }
        public Endereco ObterEnderecosPorId(long id)
        {
            return context.Enderecos.Where(f => f.EnderecoId == id).Include(c => c.Cliente).First();
        }
        public void GravarEndereco(Endereco endereco)
        {
            if (endereco.EnderecoId == 0)
            {
                context.Enderecos.Add(endereco);
            }
            else
            {
                context.Entry(endereco).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Endereco EliminarEnderecoPorId(long id)
        {
            Endereco endereco = ObterEnderecosPorId(id);
            context.Enderecos.Remove(endereco);
            context.SaveChanges();
            return endereco;
        }
    }
}
