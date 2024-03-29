﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ParamEmrimdeContext))]
    partial class ParamEmrimdeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityLayer.Concrete.Kalem", b =>
                {
                    b.Property<int>("KalemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KalemAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KalemId");

                    b.ToTable("Kalems","pem");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kasa", b =>
                {
                    b.Property<int>("KasaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KasaAciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("KasaBorcOde")
                        .HasColumnType("bit");

                    b.Property<bool>("KasaKrediKarti")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KasaTarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("KasaTutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KasaTutarDolar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KasaTutarEuro")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KatId")
                        .HasColumnType("int");

                    b.HasKey("KasaId");

                    b.HasIndex("KatId");

                    b.ToTable("Kasas","pem");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kat", b =>
                {
                    b.Property<int>("KatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KalemId")
                        .HasColumnType("int");

                    b.Property<string>("KatAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UyeId")
                        .HasColumnType("int");

                    b.HasKey("KatId");

                    b.HasIndex("KalemId");

                    b.HasIndex("UyeId");

                    b.ToTable("Kats","pem");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Uye", b =>
                {
                    b.Property<int>("UyeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UyeAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UyeEposta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UyeOnay")
                        .HasColumnType("bit");

                    b.Property<string>("UyeSifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UyeSil")
                        .HasColumnType("bit");

                    b.Property<string>("UyeSoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UyeId");

                    b.ToTable("Uyes","pem");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kasa", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kat", "Kat")
                        .WithMany("Kasas")
                        .HasForeignKey("KatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kat", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kalem", "Kalem")
                        .WithMany("Kats")
                        .HasForeignKey("KalemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Uye", "Uye")
                        .WithMany("Kats")
                        .HasForeignKey("UyeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
