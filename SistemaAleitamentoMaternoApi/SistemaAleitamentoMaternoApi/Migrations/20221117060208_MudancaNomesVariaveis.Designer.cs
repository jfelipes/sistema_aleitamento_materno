﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaAleitamentoMaternoApi.Data;

#nullable disable

namespace SistemaAleitamentoMaternoApi.Migrations
{
    [DbContext(typeof(SistemaContext))]
    [Migration("20221117060208_MudancaNomesVariaveis")]
    partial class MudancaNomesVariaveis
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Agendamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataTermino")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OperacaoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OperacaoId");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.BancoAleitamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ResponsavelId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("BancosAleitamento");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Comprovante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OperacaoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Comprovantes");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Dado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.LeiteMaterno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BancoAleitamentoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataEntrada")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataRetirada")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("boolean");

                    b.Property<Guid>("DoadorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ReceptorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BancoAleitamentoId");

                    b.ToTable("LeitesMaterno");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Operacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Detalhes")
                        .HasColumnType("text");

                    b.Property<Guid?>("LocalId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ResponsavelId")
                        .HasColumnType("uuid");

                    b.Property<string>("TipoOperacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Operacoes");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool?>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("EnderecoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Agendamento", b =>
                {
                    b.HasOne("SistemaAleitamentoMaternoApi.Models.Operacao", "Operacao")
                        .WithMany()
                        .HasForeignKey("OperacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operacao");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.BancoAleitamento", b =>
                {
                    b.HasOne("SistemaAleitamentoMaternoApi.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Contato", b =>
                {
                    b.HasOne("SistemaAleitamentoMaternoApi.Models.Pessoa", null)
                        .WithMany("Contatos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.LeiteMaterno", b =>
                {
                    b.HasOne("SistemaAleitamentoMaternoApi.Models.BancoAleitamento", "BancoAleitamento")
                        .WithMany("Estoque")
                        .HasForeignKey("BancoAleitamentoId");

                    b.Navigation("BancoAleitamento");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Pessoa", b =>
                {
                    b.HasOne("SistemaAleitamentoMaternoApi.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.BancoAleitamento", b =>
                {
                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("SistemaAleitamentoMaternoApi.Models.Pessoa", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}
