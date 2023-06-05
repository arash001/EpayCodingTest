﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20230604133004_databasecreae")]
    partial class databasecreae
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Denomination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PayoutCombinationId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PayoutCombinationId");

                    b.ToTable("Denominations");
                });

            modelBuilder.Entity("Domain.PayoutCombination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PayoutAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PayoutCombinations");
                });

            modelBuilder.Entity("Domain.Denomination", b =>
                {
                    b.HasOne("Domain.PayoutCombination", null)
                        .WithMany("Denominations")
                        .HasForeignKey("PayoutCombinationId");
                });

            modelBuilder.Entity("Domain.PayoutCombination", b =>
                {
                    b.Navigation("Denominations");
                });
#pragma warning restore 612, 618
        }
    }
}
