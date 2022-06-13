using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrugstoreManagement.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    taxCode = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    idCard = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    birthDate = table.Column<DateTime>(type: "date", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(90)", maxLength: 90, nullable: false),
                    address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseInformations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taxCode = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    metaTitle = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    enterpriseName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bankAccount = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    bankName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseInformations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceInfo = table.Column<string>(type: "xml", nullable: false),
                    reasonDelete = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    dateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    physician = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    medicalFacility = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    patientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategorys",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    metaTitle = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategorys", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierRoleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    note = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UnitNames",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitNames", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    createInvoice = table.Column<bool>(type: "bit", nullable: true),
                    invoiceManagement = table.Column<bool>(type: "bit", nullable: true),
                    warehouseManagement = table.Column<bool>(type: "bit", nullable: true),
                    category = table.Column<bool>(type: "bit", nullable: true),
                    enterpriseInfor = table.Column<bool>(type: "bit", nullable: true),
                    userManagement = table.Column<bool>(type: "bit", nullable: true),
                    report = table.Column<bool>(type: "bit", nullable: true),
                    setting = table.Column<bool>(type: "bit", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    idCategory = table.Column<int>(type: "int", nullable: true),
                    metaTitle = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    registrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    batchNo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    component = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dosage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    origin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    packagingSpecifications = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    exchangeValue = table.Column<int>(type: "int", nullable: true),
                    baseUnits = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    manDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    expDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    inventoryNumber = table.Column<int>(type: "int", nullable: true),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moreImage = table.Column<string>(type: "xml", nullable: false),
                    qrCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<int>(type: "int", nullable: true),
                    statusDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategorys_idCategory",
                        column: x => x.idCategory,
                        principalTable: "ProductCategorys",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    taxcode = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SupplierRoleId = table.Column<int>(type: "int", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.taxcode);
                    table.ForeignKey(
                        name: "FK_Suppliers_SupplierRoles_SupplierRoleId",
                        column: x => x.SupplierRoleId,
                        principalTable: "SupplierRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: true),
                    dateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    userRoleid = table.Column<int>(type: "int", nullable: true),
                    veriCode = table.Column<int>(type: "int", nullable: true),
                    numberOfLogin = table.Column<int>(type: "int", nullable: true),
                    currentLoginDevice = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    historyLogin = table.Column<string>(type: "xml", nullable: false),
                    note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.username);
                    table.ForeignKey(
                        name: "FK_Accounts_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Accounts_UserRoles_userRoleid",
                        column: x => x.userRoleid,
                        principalTable: "UserRoles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDetails",
                columns: table => new
                {
                    prescriptionId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    unitNameId = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDetails", x => new { x.prescriptionId, x.productId });
                    table.ForeignKey(
                        name: "FK_PrescriptionDetails_Prescriptions_prescriptionId",
                        column: x => x.prescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetails_UnitNames_unitNameId",
                        column: x => x.unitNameId,
                        principalTable: "UnitNames",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UnitPrices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: true),
                    unitNameId = table.Column<int>(type: "int", nullable: true),
                    exchangeValue = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitPrices", x => x.id);
                    table.ForeignKey(
                        name: "FK_UnitPrices_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UnitPrices_UnitNames_unitNameId",
                        column: x => x.unitNameId,
                        principalTable: "UnitNames",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ImportBills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    creator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    supplierId = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    VAT = table.Column<int>(type: "int", nullable: true),
                    totalAmount = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportBills", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImportBills_Accounts_creator",
                        column: x => x.creator,
                        principalTable: "Accounts",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportBills_Suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "Suppliers",
                        principalColumn: "taxcode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportInventoryBills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateCreated = table.Column<DateTime>(type: "date", nullable: true),
                    creator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    totalAmountWithVat = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    note = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportInventoryBills", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImportInventoryBills_Accounts_creator",
                        column: x => x.creator,
                        principalTable: "Accounts",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportBillDetails",
                columns: table => new
                {
                    importBillId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    unitInput = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    exchangeValue = table.Column<int>(type: "int", nullable: false),
                    quantityInput = table.Column<int>(type: "int", nullable: false),
                    priceInput = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportBillDetails", x => new { x.importBillId, x.productId });
                    table.ForeignKey(
                        name: "FK_ImportBillDetails_ImportBills_importBillId",
                        column: x => x.importBillId,
                        principalTable: "ImportBills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportBillDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportInventoryBillDetails",
                columns: table => new
                {
                    ImportInventoryBillId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    unitInput = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    exchangeValue = table.Column<int>(type: "int", nullable: false),
                    quantityInput = table.Column<int>(type: "int", nullable: false),
                    priceInput = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportInventoryBillDetails", x => new { x.ImportInventoryBillId, x.productId });
                    table.ForeignKey(
                        name: "FK_ImportInventoryBillDetails_ImportInventoryBills_ImportInventoryBillId",
                        column: x => x.ImportInventoryBillId,
                        principalTable: "ImportInventoryBills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportInventoryBillDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_employeeId",
                table: "Accounts",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_userRoleid",
                table: "Accounts",
                column: "userRoleid");

            migrationBuilder.CreateIndex(
                name: "IX_ImportBillDetails_productId",
                table: "ImportBillDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportBills_creator",
                table: "ImportBills",
                column: "creator");

            migrationBuilder.CreateIndex(
                name: "IX_ImportBills_supplierId",
                table: "ImportBills",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportInventoryBillDetails_productId",
                table: "ImportInventoryBillDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportInventoryBills_creator",
                table: "ImportInventoryBills",
                column: "creator");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetails_productId",
                table: "PrescriptionDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetails_unitNameId",
                table: "PrescriptionDetails",
                column: "unitNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_idCategory",
                table: "Products",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierRoleId",
                table: "Suppliers",
                column: "SupplierRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitPrices_productId",
                table: "UnitPrices",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitPrices_unitNameId",
                table: "UnitPrices",
                column: "unitNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EnterpriseInformations");

            migrationBuilder.DropTable(
                name: "ImportBillDetails");

            migrationBuilder.DropTable(
                name: "ImportInventoryBillDetails");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "PrescriptionDetails");

            migrationBuilder.DropTable(
                name: "UnitPrices");

            migrationBuilder.DropTable(
                name: "ImportBills");

            migrationBuilder.DropTable(
                name: "ImportInventoryBills");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UnitNames");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ProductCategorys");

            migrationBuilder.DropTable(
                name: "SupplierRoles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
