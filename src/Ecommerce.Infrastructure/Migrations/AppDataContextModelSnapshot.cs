﻿// <auto-generated />
using System;
using Ecommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ecommerce.Api.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Eccomerce.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registerdate");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_category_id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<decimal>("Discount")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("discount");

                    b.Property<decimal>("Extra")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("extra");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("ordercode");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("orderdate");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer")
                        .HasColumnName("orderstatus");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("subtotal");

                    b.Property<decimal>("Total")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("total");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_order_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_orders_userid");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.OrderPaymentMethods", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int?>("Installments")
                        .HasColumnType("INT")
                        .HasColumnName("installments");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("orderid");

                    b.Property<decimal>("PaidValue")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("paidvalue");

                    b.Property<Guid>("PaymentMethodId")
                        .HasColumnType("uuid")
                        .HasColumnName("paymentmethodid");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registerdate");

                    b.HasKey("Id")
                        .HasName("pk_orderpaymentmethods");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_orderpaymentmethods_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_orderpaymentmethods_orderid");

                    b.HasIndex("PaymentMethodId")
                        .HasDatabaseName("ix_orderpaymentmethods_paymentmethodid");

                    b.ToTable("orderpaymentmethods");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.OrderProducts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<decimal>("Discount")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("discount");

                    b.Property<decimal>("Extra")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("extra");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("orderid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("productid");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registerdate");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("subtotal");

                    b.Property<decimal>("Total")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("total");

                    b.Property<decimal>("UnitaryValue")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("unitaryvalue");

                    b.HasKey("Id")
                        .HasName("pk_orderproducts");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_orderproducts_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_orderproducts_orderid");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_orderproducts_productid");

                    b.ToTable("orderproducts");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("code");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("description");

                    b.Property<int>("PaymentMethodType")
                        .HasColumnType("integer")
                        .HasColumnName("paymentmethodtype");

                    b.Property<int?>("PermitedInstallments")
                        .HasColumnType("integer")
                        .HasColumnName("permitedinstallments");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registerdate");

                    b.HasKey("Id")
                        .HasName("pk_paymentmethods");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_paymentmethod_id");

                    b.ToTable("paymentmethods");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("barcode");

                    b.Property<string>("CategoryId")
                        .HasColumnType("text")
                        .HasColumnName("categoryid");

                    b.Property<Guid?>("CategoryId1")
                        .HasColumnType("uuid")
                        .HasColumnName("categoryid1");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasColumnType("NUMERIC")
                        .HasColumnName("price");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registerdate");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.HasIndex("CategoryId1")
                        .HasDatabaseName("ix_products_categoryid1");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_product_id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("accessfailedcount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrencystamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("emailconfirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockoutenabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockoutend");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalizedemail");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalizedusername");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("passwordhash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phonenumber");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phonenumberconfirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("securitystamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("twofactorenabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_user_id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrencystamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalizedname");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claimtype");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claimvalue");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("roleid");

                    b.HasKey("Id")
                        .HasName("pk_roleclaims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_roleclaims_roleid");

                    b.ToTable("roleclaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claimtype");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claimvalue");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_userclaims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_userclaims_userid");

                    b.ToTable("userclaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("loginprovider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("providerkey");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("providerdisplayname");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_userlogins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_userlogins_userid");

                    b.ToTable("userlogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("roleid");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_userroles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_userroles_roleid");

                    b.ToTable("userroles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("loginprovider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_usertokens");

                    b.ToTable("usertokens");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.Order", b =>
                {
                    b.HasOne("Eccomerce.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_orders_users_userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.OrderPaymentMethods", b =>
                {
                    b.HasOne("Eccomerce.Domain.Entities.Order", "Order")
                        .WithMany("OrderPaymentMethods")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_orderpaymentmethods_orders_orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eccomerce.Domain.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("OrderPaymentMethods")
                        .HasForeignKey("PaymentMethodId")
                        .HasConstraintName("fk_orderpaymentmethods_paymentmethods_paymentmethodid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.OrderProducts", b =>
                {
                    b.HasOne("Eccomerce.Domain.Entities.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_orderproducts_orders_orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eccomerce.Domain.Entities.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_orderproducts_products_productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.Product", b =>
                {
                    b.HasOne("Eccomerce.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId1")
                        .HasConstraintName("FK_Product_Category");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_roleclaims_roles_roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Eccomerce.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_userclaims_users_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Eccomerce.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_userlogins_users_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_userroles_roles_roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eccomerce.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_userroles_users_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Eccomerce.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_usertokens_users_userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderPaymentMethods");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.PaymentMethod", b =>
                {
                    b.Navigation("OrderPaymentMethods");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.Product", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Eccomerce.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
