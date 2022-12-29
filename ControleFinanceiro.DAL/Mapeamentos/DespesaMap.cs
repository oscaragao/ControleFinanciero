using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(c => c.DespesaId);

            builder.Property(c => c.Descricao).IsRequired().HasMaxLength(50);
            
            builder.Property(c => c.Valor).IsRequired();
            
            builder.Property(c => c.Dia).IsRequired();
            
            builder.Property(c => c.Ano).IsRequired();

            builder.HasOne(c => c.Cartao).WithMany(c => c.Despesas).HasForeignKey(c => c.DespesaId).IsRequired();
            builder.HasOne(c => c.Categoria).WithMany(c => c.Despesas).HasForeignKey(c => c.CategoriaId).IsRequired();
            builder.HasOne(c => c.Mes).WithMany(c => c.Despesas).HasForeignKey(c => c.MesId).IsRequired();
            builder.HasOne(c => c.Usuario).WithMany(c => c.Despesas).HasForeignKey(c => c.UsuarioId).IsRequired();


            builder.ToTable("Despesas");
        }
    }
}
