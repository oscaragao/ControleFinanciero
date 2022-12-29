using System;
using System.Collections.Generic;
using System.Text;
using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.CPF).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.CPF).IsUnique();

            builder.Property(c => c.Profissao).IsRequired().HasMaxLength(30);


            builder.HasMany(c => c.Cartoes).WithOne(c => c.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Despesas).WithOne(c => c.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Ganhos).WithOne(c => c.Usuario).OnDelete(DeleteBehavior.NoAction); 

            builder.ToTable("Usuarios");
        }
    }
}
