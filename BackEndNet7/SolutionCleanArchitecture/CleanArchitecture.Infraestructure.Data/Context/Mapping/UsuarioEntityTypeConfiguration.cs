using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.Data.Context.Mapping
{
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07DB8FA73C");

            builder.ToTable("Usuario");

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Token)
                .HasMaxLength(300)
                .IsUnicode(false);
            builder.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
