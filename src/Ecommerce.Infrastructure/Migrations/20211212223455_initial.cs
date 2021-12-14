﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ecommerce.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymentmethods",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    code = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    permitedinstallments = table.Column<int>(type: "integer", nullable: true),
                    paymentmethodtype = table.Column<int>(type: "integer", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paymentmethods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "text", nullable: true),
                    securitystamp = table.Column<string>(type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    barcode = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    description = table.Column<string>(type: "VARCHAR", maxLength: 500, nullable: false),
                    price = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    categoryid = table.Column<string>(type: "text", nullable: true),
                    categoryid1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.categoryid1,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "roleclaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roleclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_roleclaims_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ordercode = table.Column<string>(type: "VARCHAR", maxLength: 255, nullable: false),
                    orderdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    total = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    subtotal = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    discount = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    extra = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    orderstatus = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userclaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_userclaims_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userlogins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    providerkey = table.Column<string>(type: "text", nullable: false),
                    providerdisplayname = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userlogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "fk_userlogins_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userroles",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "fk_userroles_roles_roleid",
                        column: x => x.roleid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_userroles_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usertokens",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usertokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "fk_usertokens_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderpaymentmethods",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    paidvalue = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    installments = table.Column<int>(type: "INT", nullable: true),
                    paymentmethodid = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderpaymentmethods", x => x.id);
                    table.ForeignKey(
                        name: "fk_orderpaymentmethods_orders_orderid",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orderpaymentmethods_paymentmethods_paymentmethodid",
                        column: x => x.paymentmethodid,
                        principalTable: "paymentmethods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderproducts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    total = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    subtotal = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    extra = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    discount = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    unitaryvalue = table.Column<decimal>(type: "NUMERIC", nullable: false),
                    registerdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderproducts", x => x.id);
                    table.ForeignKey(
                        name: "fk_orderproducts_orders_orderid",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orderproducts_products_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_category_id",
                table: "categories",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orderpaymentmethods_id",
                table: "orderpaymentmethods",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orderpaymentmethods_orderid",
                table: "orderpaymentmethods",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_orderpaymentmethods_paymentmethodid",
                table: "orderpaymentmethods",
                column: "paymentmethodid");

            migrationBuilder.CreateIndex(
                name: "ix_orderproducts_id",
                table: "orderproducts",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orderproducts_orderid",
                table: "orderproducts",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_orderproducts_productid",
                table: "orderproducts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_order_id",
                table: "orders",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orders_userid",
                table: "orders",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_paymentmethod_id",
                table: "paymentmethods",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_product_id",
                table: "products",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_products_categoryid1",
                table: "products",
                column: "categoryid1");

            migrationBuilder.CreateIndex(
                name: "ix_roleclaims_roleid",
                table: "roleclaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "roles",
                column: "normalizedname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_userclaims_userid",
                table: "userclaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_userlogins_userid",
                table: "userlogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_userroles_roleid",
                table: "userroles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "users",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "ix_user_id",
                table: "users",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "users",
                column: "normalizedusername",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderpaymentmethods");

            migrationBuilder.DropTable(
                name: "orderproducts");

            migrationBuilder.DropTable(
                name: "roleclaims");

            migrationBuilder.DropTable(
                name: "userclaims");

            migrationBuilder.DropTable(
                name: "userlogins");

            migrationBuilder.DropTable(
                name: "userroles");

            migrationBuilder.DropTable(
                name: "usertokens");

            migrationBuilder.DropTable(
                name: "paymentmethods");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
