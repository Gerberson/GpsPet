﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pet.Models;

namespace Pet.Migrations
{
    [DbContext(typeof(PetContext))]
    [Migration("20191014141924_Add_Entidades_Dominio")]
    partial class Add_Entidades_Dominio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Pet.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EnderecoId");

                    b.Property<int?>("EstadoId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Pet.Models.Dados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataDeCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.Property<int>("Sexo");

                    b.HasKey("Id");

                    b.ToTable("Dados");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Dados");
                });

            modelBuilder.Entity("Pet.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cep");

                    b.Property<int?>("CidadeId");

                    b.Property<string>("Complemento");

                    b.Property<int>("DonoId");

                    b.Property<string>("Logradouro");

                    b.Property<int>("Numero");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Pet.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Pet.Models.Localizacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnimalId");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<int?>("RastreadorId");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("RastreadorId");

                    b.ToTable("Localizacao");
                });

            modelBuilder.Entity("Pet.Models.Rastreador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocalizacaoId");

                    b.Property<string>("NumeroDeSerie");

                    b.HasKey("Id");

                    b.ToTable("Rastreador");
                });

            modelBuilder.Entity("Pet.Models.Animal", b =>
                {
                    b.HasBaseType("Pet.Models.Dados");

                    b.Property<int?>("DonoId");

                    b.Property<int>("LocalizacaoId");

                    b.Property<string>("Raca");

                    b.HasIndex("DonoId");

                    b.ToTable("Animal");

                    b.HasDiscriminator().HasValue("Animal");
                });

            modelBuilder.Entity("Pet.Models.Dono", b =>
                {
                    b.HasBaseType("Pet.Models.Dados");

                    b.Property<int>("AnimalId");

                    b.Property<int>("Cpf");

                    b.Property<int?>("EndId");

                    b.Property<string>("Sobrenome");

                    b.HasIndex("EndId");

                    b.ToTable("Dono");

                    b.HasDiscriminator().HasValue("Dono");
                });

            modelBuilder.Entity("Pet.Models.Cidade", b =>
                {
                    b.HasOne("Pet.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");
                });

            modelBuilder.Entity("Pet.Models.Endereco", b =>
                {
                    b.HasOne("Pet.Models.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("CidadeId");
                });

            modelBuilder.Entity("Pet.Models.Localizacao", b =>
                {
                    b.HasOne("Pet.Models.Animal", "Animal")
                        .WithMany("Localizacaoes")
                        .HasForeignKey("AnimalId");

                    b.HasOne("Pet.Models.Rastreador", "Rastreador")
                        .WithMany("Localizacaoes")
                        .HasForeignKey("RastreadorId");
                });

            modelBuilder.Entity("Pet.Models.Animal", b =>
                {
                    b.HasOne("Pet.Models.Dono", "Dono")
                        .WithMany("Animais")
                        .HasForeignKey("DonoId");
                });

            modelBuilder.Entity("Pet.Models.Dono", b =>
                {
                    b.HasOne("Pet.Models.Endereco", "End")
                        .WithMany("Dono")
                        .HasForeignKey("EndId");
                });
#pragma warning restore 612, 618
        }
    }
}
