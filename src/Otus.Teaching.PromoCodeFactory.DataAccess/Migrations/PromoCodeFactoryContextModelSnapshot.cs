﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Otus.Teaching.PromoCodeFactory.DataAccess;

#nullable disable

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Migrations
{
    [DbContext(typeof(PromoCodeFactoryContext))]
    partial class PromoCodeFactoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.Administration.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AppliedPromocodesCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"),
                            AppliedPromocodesCount = 5,
                            Email = "owner@somemail.ru",
                            FirstName = "Иван",
                            LastName = "Сергеев",
                            RoleId = new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02")
                        },
                        new
                        {
                            Id = new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"),
                            AppliedPromocodesCount = 10,
                            Email = "andreev@somemail.ru",
                            FirstName = "Петр",
                            LastName = "Андреев",
                            RoleId = new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665")
                        });
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.Administration.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                            Description = "Администратор",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                            Description = "Партнерский менеджер",
                            Name = "PartnerManager"
                        });
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.CustomerPreference", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PreferenceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId", "PreferenceId");

                    b.HasIndex("PreferenceId");

                    b.ToTable("CustomerPreferences", (string)null);

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"),
                            PreferenceId = new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c"),
                            Id = new Guid("a04c4d39-f1ce-4bbf-9e25-4ecb66a3c02f")
                        },
                        new
                        {
                            CustomerId = new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"),
                            PreferenceId = new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd"),
                            Id = new Guid("efb73aa9-f551-4205-8bba-d02e43da9ecc")
                        });
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"),
                            Email = "ivan_sergeev@mail.ru",
                            FirstName = "Иван",
                            LastName = "Петров"
                        });
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.Preference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Preferences", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c"),
                            Name = "Театр"
                        },
                        new
                        {
                            Id = new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd"),
                            Name = "Семья"
                        },
                        new
                        {
                            Id = new Guid("76324c47-68d2-472d-abb8-33cfa8cc0c84"),
                            Name = "Дети"
                        });
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.PromoCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PartnerManagerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PreferenceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServiceInfo")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PartnerManagerId");

                    b.HasIndex("PreferenceId");

                    b.ToTable("PromoCodes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ad50fcaf-ef3b-484c-ba56-425e674ed368"),
                            BeginDate = new DateTime(2024, 3, 27, 12, 28, 23, 691, DateTimeKind.Local).AddTicks(403),
                            Code = "THEATER-123",
                            CustomerId = new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"),
                            EndDate = new DateTime(2024, 5, 6, 12, 28, 23, 691, DateTimeKind.Local).AddTicks(417),
                            PartnerManagerId = new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"),
                            PreferenceId = new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c"),
                            ServiceInfo = "Скидка 10% на театральные услуги"
                        },
                        new
                        {
                            Id = new Guid("03b30649-53f3-4151-a99d-08c182d91502"),
                            BeginDate = new DateTime(2024, 3, 27, 12, 28, 23, 691, DateTimeKind.Local).AddTicks(476),
                            Code = "FAMILY-456",
                            CustomerId = new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"),
                            EndDate = new DateTime(2024, 6, 5, 12, 28, 23, 691, DateTimeKind.Local).AddTicks(476),
                            PartnerManagerId = new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"),
                            PreferenceId = new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd"),
                            ServiceInfo = "Скидка 20% на все семейные услуги"
                        });
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.Administration.Employee", b =>
                {
                    b.HasOne("Otus.Teaching.PromoCodeFactory.Core.Domain.Administration.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.CustomerPreference", b =>
                {
                    b.HasOne("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.Customer", "Customer")
                        .WithMany("CustomerPreferences")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.Preference", "Preference")
                        .WithMany("CustomerPreferences")
                        .HasForeignKey("PreferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Preference");
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.PromoCode", b =>
                {
                    b.HasOne("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.Customer", "Customer")
                        .WithMany("PromoCodes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Otus.Teaching.PromoCodeFactory.Core.Domain.Administration.Employee", "PartnerManager")
                        .WithMany("PromoCodes")
                        .HasForeignKey("PartnerManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.Preference", "Preference")
                        .WithMany("PromoCodes")
                        .HasForeignKey("PreferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("PartnerManager");

                    b.Navigation("Preference");
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.Administration.Employee", b =>
                {
                    b.Navigation("PromoCodes");
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.Administration.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.Customer", b =>
                {
                    b.Navigation("CustomerPreferences");

                    b.Navigation("PromoCodes");
                });

            modelBuilder.Entity("Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement.Preference", b =>
                {
                    b.Navigation("CustomerPreferences");

                    b.Navigation("PromoCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
