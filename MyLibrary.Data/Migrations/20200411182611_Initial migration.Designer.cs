﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLibrary.Data;

namespace MyLibrary.Data.Migrations
{
    [DbContext(typeof(MyLibraryContext))]
    [Migration("20200411182611_Initial migration")]
    partial class Initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyLibrary.Data.Model.BibliotecaAtivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstatoId")
                        .HasColumnType("int");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("varchar(120)");

                    b.Property<int?>("LocalizacaoId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroDeCopia")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EstatoId");

                    b.HasIndex("LocalizacaoId");

                    b.ToTable("BibliotecaAtivos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BibliotecaAtivo");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.BibliotecaCartao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEmissaoCartao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Honorarios")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("BibliotecaCartaos");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.BibliotecaFilial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dataabertura")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("BibliotecaFilias");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.Espera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BibliotecaAtivoId")
                        .HasColumnType("int");

                    b.Property<int?>("BibliotecaCartaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEspera")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecaAtivoId");

                    b.HasIndex("BibliotecaCartaoId");

                    b.ToTable("Esperas");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.Estato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Estatos");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.FilialHora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiaDaSemana")
                        .HasColumnType("int");

                    b.Property<int?>("FilialId")
                        .HasColumnType("int");

                    b.Property<int>("HoraDeFechar")
                        .HasColumnType("int");

                    b.Property<int>("HoradeAbertura")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilialId");

                    b.ToTable("FilialHoras");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.Patrono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BibliotecaCartaoId")
                        .HasColumnType("int");

                    b.Property<int?>("BibliotecaFilialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Genero")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecaCartaoId");

                    b.HasIndex("BibliotecaFilialId");

                    b.ToTable("Patronos");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.TipoAtivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoAtivos");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.VerificarHistorico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BibliotecaAtivoId")
                        .HasColumnType("int");

                    b.Property<int>("BibliotecaCartaoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Verificado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VerificarSaida")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecaAtivoId");

                    b.HasIndex("BibliotecaCartaoId");

                    b.ToTable("VerificarHistoricos");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.VerificarSaida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Ate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BibliotecaAtivoId")
                        .HasColumnType("int");

                    b.Property<int?>("BibliotecaCartaoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Desde")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BibliotecaAtivoId");

                    b.HasIndex("BibliotecaCartaoId");

                    b.ToTable("VerificarSaidas");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.Livro", b =>
                {
                    b.HasBaseType("MyLibrary.Data.Model.BibliotecaAtivo");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DeweyIndex")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasDiscriminator().HasValue("Livro");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.Video", b =>
                {
                    b.HasBaseType("MyLibrary.Data.Model.BibliotecaAtivo");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.BibliotecaAtivo", b =>
                {
                    b.HasOne("MyLibrary.Data.Model.Estato", "Estato")
                        .WithMany()
                        .HasForeignKey("EstatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyLibrary.Data.Model.BibliotecaFilial", "Localizacao")
                        .WithMany("BibliotecaAtivos")
                        .HasForeignKey("LocalizacaoId");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.Espera", b =>
                {
                    b.HasOne("MyLibrary.Data.Model.BibliotecaAtivo", "BibliotecaAtivo")
                        .WithMany()
                        .HasForeignKey("BibliotecaAtivoId");

                    b.HasOne("MyLibrary.Data.Model.BibliotecaCartao", "BibliotecaCartao")
                        .WithMany()
                        .HasForeignKey("BibliotecaCartaoId");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.FilialHora", b =>
                {
                    b.HasOne("MyLibrary.Data.Model.BibliotecaFilial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialId");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.Patrono", b =>
                {
                    b.HasOne("MyLibrary.Data.Model.BibliotecaCartao", "BibliotecaCartao")
                        .WithMany()
                        .HasForeignKey("BibliotecaCartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyLibrary.Data.Model.BibliotecaFilial", "BibliotecaFilial")
                        .WithMany("Patronos")
                        .HasForeignKey("BibliotecaFilialId");
                });

            modelBuilder.Entity("MyLibrary.Data.Model.VerificarHistorico", b =>
                {
                    b.HasOne("MyLibrary.Data.Model.BibliotecaAtivo", "BibliotecaAtivo")
                        .WithMany()
                        .HasForeignKey("BibliotecaAtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyLibrary.Data.Model.BibliotecaCartao", "BibliotecaCartao")
                        .WithMany()
                        .HasForeignKey("BibliotecaCartaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyLibrary.Data.Model.VerificarSaida", b =>
                {
                    b.HasOne("MyLibrary.Data.Model.BibliotecaAtivo", "BibliotecaAtivo")
                        .WithMany("VerificarSaidas")
                        .HasForeignKey("BibliotecaAtivoId");

                    b.HasOne("MyLibrary.Data.Model.BibliotecaCartao", "BibliotecaCartao")
                        .WithMany("VerificarSaidas")
                        .HasForeignKey("BibliotecaCartaoId");
                });
#pragma warning restore 612, 618
        }
    }
}
