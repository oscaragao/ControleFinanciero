using System;
using System.Collections.Generic;
using System.Text;
using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class GanhoMap : IEntityTypeConfiguration<Ganho>
    {
        public void Configure(EntityTypeBuilder<Ganho> builder)
        {
            builder.HasKey(c => c.GanhoId);

            builder.Property(c => c.Descricao).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Valor).IsRequired();

            builder.Property(c => c.Dia).IsRequired();

            builder.Property(c => c.Ano).IsRequired();

            builder.HasOne(c => c.Categoria).WithMany(c => c.Ganhos).HasForeignKey(c => c.CategoriaId).IsRequired();
            builder.HasOne(c => c.Usuario).WithMany(c => c.Ganhos).HasForeignKey(c => c.UsuarioId).IsRequired();
            builder.HasOne(c => c.Mes).WithMany(c => c.Ganhos).HasForeignKey(c => c.MesId).IsRequired();
            

            builder.ToTable("Ganhos");
        }
    }
}
