using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Utilidades;

namespace BancoDados
{
    public class Contexto : DbContext
    {
        public Contexto() { }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(ConfigurationProvider.Get("ConnectionStrings:ConexaoSQLite"));
            }
        }

        public DbSet<tblUsuario> tblUsuario { get; set; }
        public DbSet<tblTarefa> tblTarefa { get; set; }      
          public DbSet<tblEtapa> tblEtapa { get; set; }

    }
}