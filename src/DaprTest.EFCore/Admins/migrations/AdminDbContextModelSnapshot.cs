﻿// <auto-generated />
using System;
using DaprTest.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DaprTest.EFCore.Admins.migrations
{
    [DbContext(typeof(AdminDbContext))]
    partial class AdminDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("DaprTest.Domain.Entities.Admins.AdminUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordSecert")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("DaprTest.Domain.Entities.Admins.ApplicationClient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AllowedCorsOrigins")
                        .HasColumnType("longtext");

                    b.Property<string>("AllowedScopes")
                        .HasColumnType("longtext");

                    b.Property<string>("ClientId")
                        .HasColumnType("longtext");

                    b.Property<string>("ClientSecert")
                        .HasColumnType("longtext");

                    b.Property<int>("ClientType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LogoutRedirectUris")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("RedirectUris")
                        .HasColumnType("longtext");

                    b.Property<bool>("RequireClientSecret")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TenantCode")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationClients");
                });

            modelBuilder.Entity("DaprTest.Domain.Entities.Admins.TenantInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("TenantCode")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("TenantInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
