﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbMigrator.Migrations
{
    [DbContext(typeof(StripeDbContext))]
    [Migration("20210729051357_user-paymentmethodId")]
    partial class userpaymentmethodId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(350)
                        .HasColumnType("character varying(350)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(350)
                        .HasColumnType("character varying(350)");

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("CountryId")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<int>("CreatedById")
                        .HasColumnType("integer");

                    b.Property<string>("CreatedByName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("DateLastUpdated")
                        .HasColumnType("timestamp");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<bool>("HasValidPayment")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasValidatedEmail")
                        .HasColumnType("boolean");

                    b.Property<string>("Image")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastUpdateByName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("LastUpdatedById")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("PasswordResetToken")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Phone")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Postal")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("State")
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<string>("StripeCustomerId")
                        .HasColumnType("text");

                    b.Property<string>("StripePaymentMethodId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User", "account");
                });
#pragma warning restore 612, 618
        }
    }
}
