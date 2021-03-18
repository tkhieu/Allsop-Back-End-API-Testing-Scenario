﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.API.Catalog.Infrastructure;

namespace Service.API.Catalog.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20210314151551_AddColumnOldPriceValueToProducts")]
    partial class AddColumnOldPriceValueToProducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("App.Support.Common.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = "5beff28e-bba2-4b1b-9f06-126d6365d4cf",
                            Code = "MP",
                            Name = "Meat & Poultry"
                        },
                        new
                        {
                            Id = "fd6055d7-08a3-4351-8195-7da47e50f028",
                            Code = "FV",
                            Name = "Fruit & Vegetables"
                        },
                        new
                        {
                            Id = "737c9710-e069-436a-a236-660e8277dedf",
                            Code = "DR",
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = "bae52764-af07-4043-8586-52816594ee86",
                            Code = "CD",
                            Name = "Confectionary & Desserts"
                        },
                        new
                        {
                            Id = "3786f39a-a229-4689-aed7-d851082cd87a",
                            Code = "CI",
                            Name = "Baking/Cooking Ingredients"
                        },
                        new
                        {
                            Id = "b5901197-4899-4a22-ad39-7f1f4cdcb84b",
                            Code = "MI",
                            Name = "Miscellaneous Items"
                        });
                });

            modelBuilder.Entity("App.Support.Common.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<int>("InventoryQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("OldPriceValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Packaging")
                        .HasColumnType("TEXT");

                    b.Property<string>("PriceUnit")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PriceValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sku")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("App.Support.Common.Models.Product", b =>
                {
                    b.HasOne("App.Support.Common.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
