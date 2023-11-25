﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trab_AV2.Model.Models;

public partial class PADARIA_AV2Context : DbContext
{
    public PADARIA_AV2Context(DbContextOptions<PADARIA_AV2Context> options)
        : base(options)
    {
    }
    public PADARIA_AV2Context()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

=> optionsBuilder.UseSqlServer("data source=NOTEBOOK-MARCOS\\SQLEXPRESS;Initial Catalog=PADARIA_AV2;User Id=sa;Password=2000@edu.sau;TrustserverCertificate=True");

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<SimNao> SimNaos { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }
    public virtual DbSet<VwEstoque> VwEstoque {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("PRODUTOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Disp).HasColumnName("DISP");
            entity.Property(e => e.IdUser)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnName("ID_USER");
            entity.Property(e => e.NmProduto)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NM_PRODUTO");
            entity.Property(e => e.Qtd)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("QTD");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("VALOR");
        });

        modelBuilder.Entity<SimNao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SIM_NAO__3214EC27D10DE8D7");

            entity.ToTable("SIM_NAO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("DESCRICAO");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.ToTable("VENDA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DataVenda)
                .HasColumnType("datetime")
                .HasColumnName("DATA_VENDA");
            entity.Property(e => e.IdProduto).HasColumnName("ID_PRODUTO");
            entity.Property(e => e.IdUser)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnName("ID_USER");
            entity.Property(e => e.ValorVenda)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("VALOR_VENDA");
        });

        modelBuilder.Entity<VwEstoque>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_ESTOQUE");

            entity.Property(e => e.ProDescricao)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Procodigo).HasColumnName("PROCODIGO");
            entity.Property(e => e.Quantidade)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("QUANTIDADE");
            entity.Property(e => e.Valorvenda)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VALORVENDA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}