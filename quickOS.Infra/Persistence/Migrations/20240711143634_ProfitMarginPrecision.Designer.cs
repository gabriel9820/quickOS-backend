﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using quickOS.Infra.Persistence;

#nullable disable

namespace quickOS.Infra.Persistence.Migrations
{
    [DbContext(typeof(QuickOSDbContext))]
    [Migration("20240711143634_ProfitMarginPrecision")]
    partial class ProfitMarginPrecision
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("quickOS.Core.Entities.AccountPayable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("DocumentNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPaidOut")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("IssueDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("AccountsPayable");
                });

            modelBuilder.Entity("quickOS.Core.Entities.AccountReceivable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("DocumentNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPaidOut")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("IssueDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<int?>("ServiceOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Value")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("ServiceOrderId");

                    b.HasIndex("TenantId");

                    b.ToTable("AccountsReceivable");
                });

            modelBuilder.Entity("quickOS.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character(15)")
                        .IsFixedLength();

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.HasIndex("Cellphone", "TenantId")
                        .IsUnique();

                    b.HasIndex("Code", "TenantId")
                        .IsUnique();

                    b.HasIndex("Document", "TenantId")
                        .IsUnique();

                    b.HasIndex("Email", "TenantId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("quickOS.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<decimal?>("CostPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<decimal?>("ProfitMargin")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("SellingPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("Stock")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<int>("UnitOfMeasurementId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.HasIndex("UnitOfMeasurementId");

                    b.HasIndex("Code", "TenantId")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EquipmentDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("ProblemDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("TechnicalReport")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("integer");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("TechnicianId");

                    b.HasIndex("TenantId");

                    b.HasIndex("Number", "TenantId")
                        .IsUnique();

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceOrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<int>("Item")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<double>("Quantity")
                        .HasPrecision(6, 2)
                        .HasColumnType("double precision");

                    b.Property<int>("ServiceOrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.HasIndex("ServiceOrderId");

                    b.HasIndex("Item", "ServiceOrderId")
                        .IsUnique();

                    b.ToTable("ServiceOrdersProducts");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceOrderService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<int>("Item")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<double>("Quantity")
                        .HasPrecision(6, 2)
                        .HasColumnType("double precision");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceOrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("ServiceId");

                    b.HasIndex("ServiceOrderId");

                    b.HasIndex("Item", "ServiceOrderId")
                        .IsUnique();

                    b.ToTable("ServiceOrdersServices");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceProvided", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.HasIndex("Code", "TenantId")
                        .IsUnique();

                    b.ToTable("ServicesProvided");
                });

            modelBuilder.Entity("quickOS.Core.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("quickOS.Core.Entities.UnitOfMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Abbreviation")
                        .IsUnique();

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("UnitsOfMeasurement");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviation = "un",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("b25719f0-d241-45c3-b72b-15524a02d26e"),
                            IsActive = true,
                            Name = "Unidade",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            Abbreviation = "pç",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("d0505db2-a3ed-4e3e-943a-61df332631d1"),
                            IsActive = true,
                            Name = "Peça",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            Abbreviation = "cx",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("1756d900-d234-4777-bcf0-86a72ea0f1cc"),
                            IsActive = true,
                            Name = "Caixa",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            Abbreviation = "pa",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("586762f7-90d5-4821-b1cc-a0679917fe6d"),
                            IsActive = true,
                            Name = "Par",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            Abbreviation = "cm",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("c0ef61a9-fdf1-4b8e-89f5-7882e2ffc1fa"),
                            IsActive = true,
                            Name = "Centímetro",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 6,
                            Abbreviation = "m",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("ccdfb575-2492-441f-83fb-5047c1d34a0c"),
                            IsActive = true,
                            Name = "Metro",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 7,
                            Abbreviation = "g",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("30a78d4e-62b6-42d5-95fe-4f5ee0cb0257"),
                            IsActive = true,
                            Name = "Grama",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 8,
                            Abbreviation = "kg",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("9b485104-de70-4964-8b64-dae14a085b97"),
                            IsActive = true,
                            Name = "Quilograma",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9,
                            Abbreviation = "ml",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("97623f28-4d25-4e8c-a65b-62e219d4922b"),
                            IsActive = true,
                            Name = "Mililitro",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 10,
                            Abbreviation = "l",
                            CreatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc),
                            ExternalId = new Guid("bb489c91-3400-4520-9033-15b7db5eb18d"),
                            IsActive = true,
                            Name = "Litro",
                            UpdatedAt = new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("quickOS.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character(15)")
                        .IsFixedLength();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("RefreshToken")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("RefreshTokenExpiresIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("TenantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Cellphone")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("RefreshToken")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("quickOS.Core.Entities.AccountPayable", b =>
                {
                    b.HasOne("quickOS.Core.Entities.Tenant", "Tenant")
                        .WithMany("AccountsPayable")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("quickOS.Core.Entities.AccountReceivable", b =>
                {
                    b.HasOne("quickOS.Core.Entities.Customer", "Customer")
                        .WithMany("AccountsReceivable")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("quickOS.Core.Entities.ServiceOrder", "ServiceOrder")
                        .WithMany("AccountsReceivable")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("quickOS.Core.Entities.Tenant", "Tenant")
                        .WithMany("AccountsReceivable")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("ServiceOrder");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("quickOS.Core.Entities.Customer", b =>
                {
                    b.HasOne("quickOS.Core.Entities.Tenant", "Tenant")
                        .WithMany("Customers")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("quickOS.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .HasColumnType("integer");

                            b1.Property<string>("City")
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)");

                            b1.Property<string>("Details")
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("Neighborhood")
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)");

                            b1.Property<string>("Number")
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)");

                            b1.Property<string>("State")
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)");

                            b1.Property<string>("Street")
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)");

                            b1.Property<string>("ZipCode")
                                .HasMaxLength(9)
                                .HasColumnType("character(9)")
                                .IsFixedLength();

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("quickOS.Core.Entities.Product", b =>
                {
                    b.HasOne("quickOS.Core.Entities.Tenant", "Tenant")
                        .WithMany("Products")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("quickOS.Core.Entities.UnitOfMeasurement", "UnitOfMeasurement")
                        .WithMany("Products")
                        .HasForeignKey("UnitOfMeasurementId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");

                    b.Navigation("UnitOfMeasurement");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceOrder", b =>
                {
                    b.HasOne("quickOS.Core.Entities.Customer", "Customer")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("quickOS.Core.Entities.User", "Technician")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("quickOS.Core.Entities.Tenant", "Tenant")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Technician");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceOrderProduct", b =>
                {
                    b.HasOne("quickOS.Core.Entities.Product", "Product")
                        .WithMany("ServiceOrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("quickOS.Core.Entities.ServiceOrder", "ServiceOrder")
                        .WithMany("Products")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceOrderService", b =>
                {
                    b.HasOne("quickOS.Core.Entities.ServiceProvided", "Service")
                        .WithMany("ServiceOrderServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("quickOS.Core.Entities.ServiceOrder", "ServiceOrder")
                        .WithMany("Services")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceProvided", b =>
                {
                    b.HasOne("quickOS.Core.Entities.Tenant", "Tenant")
                        .WithMany("ServicesProvided")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("quickOS.Core.Entities.User", b =>
                {
                    b.HasOne("quickOS.Core.Entities.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("quickOS.Core.Entities.Customer", b =>
                {
                    b.Navigation("AccountsReceivable");

                    b.Navigation("ServiceOrders");
                });

            modelBuilder.Entity("quickOS.Core.Entities.Product", b =>
                {
                    b.Navigation("ServiceOrderProducts");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceOrder", b =>
                {
                    b.Navigation("AccountsReceivable");

                    b.Navigation("Products");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("quickOS.Core.Entities.ServiceProvided", b =>
                {
                    b.Navigation("ServiceOrderServices");
                });

            modelBuilder.Entity("quickOS.Core.Entities.Tenant", b =>
                {
                    b.Navigation("AccountsPayable");

                    b.Navigation("AccountsReceivable");

                    b.Navigation("Customers");

                    b.Navigation("Products");

                    b.Navigation("ServiceOrders");

                    b.Navigation("ServicesProvided");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("quickOS.Core.Entities.UnitOfMeasurement", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("quickOS.Core.Entities.User", b =>
                {
                    b.Navigation("ServiceOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
