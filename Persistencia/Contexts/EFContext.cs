using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CSApoo")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>()); 
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<ConsultaExame> ConsultasExames { get; set; }
        public System.Data.Entity.DbSet<Secretario> Secretarios { get; set; }
        public System.Data.Entity.DbSet<Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Especie> Especies { get; set; }
    }
}