using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleQuotes.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuoteRules",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PriceModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteRules", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MakeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeID",
                        column: x => x.MakeID,
                        principalTable: "Makes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelStyles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    BodyTypeID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelStyles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModelStyles_BodyTypes_BodyTypeID",
                        column: x => x.BodyTypeID,
                        principalTable: "BodyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelStyles_Models_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Models",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelStyles_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelStyleYears",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelStyleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelStyleYears", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModelStyleYears_ModelStyles_ModelStyleID",
                        column: x => x.ModelStyleID,
                        principalTable: "ModelStyles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteOverides",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelStyleYearID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteOverides", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuoteOverides_ModelStyleYears_ModelStyleYearID",
                        column: x => x.ModelStyleYearID,
                        principalTable: "ModelStyleYears",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelStyleYearID = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyTypeID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    ItMoves = table.Column<bool>(type: "bit", nullable: false),
                    HasAllWheels = table.Column<bool>(type: "bit", nullable: false),
                    HasAlloyWheels = table.Column<bool>(type: "bit", nullable: false),
                    HasAllTires = table.Column<bool>(type: "bit", nullable: false),
                    HasKey = table.Column<bool>(type: "bit", nullable: false),
                    HasTitle = table.Column<bool>(type: "bit", nullable: false),
                    RequiresPickup = table.Column<bool>(type: "bit", nullable: false),
                    HasEngine = table.Column<bool>(type: "bit", nullable: false),
                    HasTransmission = table.Column<bool>(type: "bit", nullable: false),
                    HasCompleteInterior = table.Column<bool>(type: "bit", nullable: false),
                    OfferedQuote = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Quotes_BodyTypes_BodyTypeID",
                        column: x => x.BodyTypeID,
                        principalTable: "BodyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotes_ModelStyleYears_ModelStyleYearID",
                        column: x => x.ModelStyleYearID,
                        principalTable: "ModelStyleYears",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Quotes_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Coupe" },
                    { 2, "Sedan" },
                    { 3, "Hatchback" },
                    { 4, "Wagon" },
                    { 5, "Convertible" },
                    { 6, "SUV" },
                    { 7, "Truck" },
                    { 8, "Mini Van" },
                    { 9, "Roadster" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Subcompact" },
                    { 2, "Compact" },
                    { 3, "Mid Size" },
                    { 5, "Full Size" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyTypes_Name",
                table: "BodyTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Makes_Name",
                table: "Makes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeID",
                table: "Models",
                column: "MakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Name_MakeID",
                table: "Models",
                columns: new[] { "Name", "MakeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelStyles_BodyTypeID",
                table: "ModelStyles",
                column: "BodyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ModelStyles_ModelID_BodyTypeID_SizeID",
                table: "ModelStyles",
                columns: new[] { "ModelID", "BodyTypeID", "SizeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelStyles_SizeID",
                table: "ModelStyles",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_ModelStyleYears_ModelStyleID",
                table: "ModelStyleYears",
                column: "ModelStyleID");

            migrationBuilder.CreateIndex(
                name: "IX_ModelStyleYears_Year_ModelStyleID",
                table: "ModelStyleYears",
                columns: new[] { "Year", "ModelStyleID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuoteOverides_ModelStyleYearID",
                table: "QuoteOverides",
                column: "ModelStyleYearID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuoteRules_FeatureType_FeatureValue",
                table: "QuoteRules",
                columns: new[] { "FeatureType", "FeatureValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_BodyTypeID",
                table: "Quotes",
                column: "BodyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_ModelStyleYearID",
                table: "Quotes",
                column: "ModelStyleYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_SizeID",
                table: "Quotes",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Name",
                table: "Sizes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteOverides");

            migrationBuilder.DropTable(
                name: "QuoteRules");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "ModelStyleYears");

            migrationBuilder.DropTable(
                name: "ModelStyles");

            migrationBuilder.DropTable(
                name: "BodyTypes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
