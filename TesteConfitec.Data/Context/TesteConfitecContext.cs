using Microsoft.EntityFrameworkCore;
using TesteConfitec.Domain.Entities;
using TesteTecnico.Data.DataConfig;

namespace TesteConfitec.Data.Context
{
    public class TesteConfitecContext : DbContext
    {
        public TesteConfitecContext(DbContextOptions<TesteConfitecContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>(new UsuarioConfig().Configure);
            base.OnModelCreating(builder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

