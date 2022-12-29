using System;
using System.Collections.Generic;
using System.Text;
using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Descricao).IsRequired().HasMaxLength(50);

            builder.HasData(
                new Funcao 
                {
                  Id = Guid.NewGuid().ToString(),
                  Name = "Administrador",
                  NormalizedName = "ADMINISTRADOR",
                  Descricao = "Administrador do sistema"
                },
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuario",
                    NormalizedName = "USUARIO",
                    Descricao = "Usuario do sistema"
                });

            builder.ToTable("Funcoes");

        }
    }
}
