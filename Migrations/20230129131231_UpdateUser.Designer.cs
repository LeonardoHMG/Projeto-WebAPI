﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Usuario.Data;

#nullable disable

namespace Usuario.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230129131231_UpdateUser")]
    partial class UpdateUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("Usuario.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT")
                        .HasColumnName("data_nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_usuario", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
