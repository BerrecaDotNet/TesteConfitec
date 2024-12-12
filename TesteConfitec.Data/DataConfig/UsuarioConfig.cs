using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteConfitec.Domain.Entities;

namespace TesteTecnico.Data.DataConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(k => k.UsuarioId);
            builder.Property(x => x.UsuarioId).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(x => x.Sobrenome)
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(x => x.Email)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(x => x.DataNascimento)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(x => x.Escolaridade)
               .HasColumnType("int")
               .IsRequired();

        }
    }
}
