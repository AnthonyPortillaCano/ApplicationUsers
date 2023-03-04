using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Context.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class BDCompanyContext : DbContext
{
    public BDCompanyContext()
    {
    }

    public BDCompanyContext(DbContextOptions<BDCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
