﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.API.Promotion.Infrastructure;

namespace Service.API.Promotion.Migrations
{
    [DbContext(typeof(PromotionDbContext))]
    partial class PromotionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ApplyOnId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CodePrefix")
                        .HasColumnType("TEXT");

                    b.Property<int>("DiscountCampaignApplyOn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscountCampaignType")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("DiscountUnitId")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DiscountValue")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DiscountCampaigns");
                });

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DiscountCampaignId")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxRedeem")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NormalizedCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DiscountCampaignId");

                    b.ToTable("DiscountCodes");
                });

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DiscountCampaignId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Operator")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.Property<int>("ValueType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DiscountCampaignId");

                    b.ToTable("DiscountValidation");
                });

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.Redemptions.Redemption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DiscountCampaignId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DiscountCodeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("RedeemTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiscountCampaignId");

                    b.HasIndex("DiscountCodeId");

                    b.ToTable("Redemptions");
                });

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode", b =>
                {
                    b.HasOne("App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign", null)
                        .WithMany("DiscountCodes")
                        .HasForeignKey("DiscountCampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.DiscountValidations.DiscountValidation", b =>
                {
                    b.HasOne("App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign", null)
                        .WithMany("DiscountValidations")
                        .HasForeignKey("DiscountCampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.Redemptions.Redemption", b =>
                {
                    b.HasOne("App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign", "DiscountCampaign")
                        .WithMany("Redemptions")
                        .HasForeignKey("DiscountCampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode", "DiscountCode")
                        .WithMany("Redemptions")
                        .HasForeignKey("DiscountCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscountCampaign");

                    b.Navigation("DiscountCode");
                });

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.DiscountCampaigns.DiscountCampaign", b =>
                {
                    b.Navigation("DiscountCodes");

                    b.Navigation("DiscountValidations");

                    b.Navigation("Redemptions");
                });

            modelBuilder.Entity("App.Support.Common.Models.PromotionService.DiscountCodes.DiscountCode", b =>
                {
                    b.Navigation("Redemptions");
                });
#pragma warning restore 612, 618
        }
    }
}
