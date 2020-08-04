﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taxas.Data.Context;

namespace Taxas.Data.Migrations
{
    [DbContext(typeof(TaxasDbContext))]
    [Migration("20200804151144_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Taxas.Domain.TaxaDeJuros.TaxaDeJuros", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Excluido")
                        .HasColumnType("bit");

                    b.Property<decimal>("Percentual")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TaxasDeJuros");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7772b216-a9e0-47d8-88da-529ecfbf9023"),
                            Excluido = false,
                            Percentual = 0.01m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
