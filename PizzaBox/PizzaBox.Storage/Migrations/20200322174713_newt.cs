using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storage.Migrations
{
    public partial class newt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BigInt", nullable: false),
                    Name = table.Column<string>(type: "Text", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CrustId = table.Column<long>(nullable: false),
                    SizeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizza_Crust_CrustId",
                        column: x => x.CrustId,
                        principalTable: "Crust",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false),
                    ToppingId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => new { x.PizzaId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Topping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637204780329703626L, "Traditional (Fluffy)", 2.00m },
                    { 637204780329703656L, "Thin Crust", 1.00m },
                    { 637204780329703660L, "New York Style", 1.50m },
                    { 637204780329703662L, "Deep Dish", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637204780329677900L, "X-Large", 4.00m },
                    { 637204780329695818L, "Large", 3.00m },
                    { 637204780329695858L, "Medium", 2.25m },
                    { 637204780329695863L, "Small", 1.50m }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 637204780329704206L, "Marinara Sauce", 0.75m },
                    { 637204780329704228L, "Cheese", 1.00m },
                    { 637204780329704231L, "Pepperoni", 1.25m },
                    { 637204780329704234L, "Sausage", 1.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CrustId",
                table: "Pizza",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingId",
                table: "PizzaToppings",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
