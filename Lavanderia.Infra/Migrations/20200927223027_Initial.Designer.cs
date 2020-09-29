﻿// <auto-generated />
using Lavanderia.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lavanderia.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200927223027_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lavanderia.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Complement")
                        .HasColumnName("complement")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnName("municipality")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnName("number")
                        .HasColumnType("varchar(6)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnName("postal_code")
                        .HasColumnType("varchar(9)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("state")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("street")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("Lavanderia.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnName("address_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PhoneId")
                        .HasColumnName("phone_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("PhoneId")
                        .IsUnique();

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Lavanderia.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnName("customer_id")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnName("status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Lavanderia.Domain.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnName("color")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnName("type")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnName("value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Lavanderia.Domain.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnName("ddd")
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnName("number")
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.ToTable("phone");
                });

            modelBuilder.Entity("Lavanderia.Domain.Models.Customer", b =>
                {
                    b.HasOne("Lavanderia.Domain.Models.Address", "Address")
                        .WithOne("Customer")
                        .HasForeignKey("Lavanderia.Domain.Models.Customer", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lavanderia.Domain.Models.Phone", "Phone")
                        .WithOne("Customer")
                        .HasForeignKey("Lavanderia.Domain.Models.Customer", "PhoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lavanderia.Domain.Models.Order", b =>
                {
                    b.HasOne("Lavanderia.Domain.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Lavanderia.Domain.Models.OrderItem", b =>
                {
                    b.HasOne("Lavanderia.Domain.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
