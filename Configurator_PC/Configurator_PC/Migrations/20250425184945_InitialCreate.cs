using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Configurator_PC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "component_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_component_types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parameter_names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameter_names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_components_component_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "component_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "component_type_parameter_names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    ParameterNameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_component_type_parameter_names", x => x.Id);
                    table.ForeignKey(
                        name: "FK_component_type_parameter_names_component_types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "component_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_component_type_parameter_names_parameter_names_ParameterNam~",
                        column: x => x.ParameterNameId,
                        principalTable: "parameter_names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compatibility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Component1Id = table.Column<int>(type: "integer", nullable: false),
                    Component2Id = table.Column<int>(type: "integer", nullable: false),
                    ParameterNameId = table.Column<int>(type: "integer", nullable: false),
                    Value1 = table.Column<string>(type: "text", nullable: true),
                    Value2 = table.Column<string>(type: "text", nullable: true),
                    IsCompatible = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compatibility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compatibility_components_Component1Id",
                        column: x => x.Component1Id,
                        principalTable: "components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compatibility_components_Component2Id",
                        column: x => x.Component2Id,
                        principalTable: "components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compatibility_parameter_names_ParameterNameId",
                        column: x => x.ParameterNameId,
                        principalTable: "parameter_names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "configuration_components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConfigurationId = table.Column<int>(type: "integer", nullable: false),
                    ComponentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuration_components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_configuration_components_components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_configuration_components_configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentId = table.Column<int>(type: "integer", nullable: false),
                    ParameterNameId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parameters_components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_parameters_parameter_names_ParameterNameId",
                        column: x => x.ParameterNameId,
                        principalTable: "parameter_names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compatibility_Component1Id",
                table: "compatibility",
                column: "Component1Id");

            migrationBuilder.CreateIndex(
                name: "IX_compatibility_Component2Id",
                table: "compatibility",
                column: "Component2Id");

            migrationBuilder.CreateIndex(
                name: "IX_compatibility_ParameterNameId",
                table: "compatibility",
                column: "ParameterNameId");

            migrationBuilder.CreateIndex(
                name: "IX_component_type_parameter_names_ParameterNameId",
                table: "component_type_parameter_names",
                column: "ParameterNameId");

            migrationBuilder.CreateIndex(
                name: "IX_component_type_parameter_names_TypeId",
                table: "component_type_parameter_names",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_components_TypeId",
                table: "components",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_configuration_components_ComponentId",
                table: "configuration_components",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_configuration_components_ConfigurationId",
                table: "configuration_components",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_parameters_ComponentId",
                table: "parameters",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_parameters_ParameterNameId",
                table: "parameters",
                column: "ParameterNameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compatibility");

            migrationBuilder.DropTable(
                name: "component_type_parameter_names");

            migrationBuilder.DropTable(
                name: "configuration_components");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "configurations");

            migrationBuilder.DropTable(
                name: "components");

            migrationBuilder.DropTable(
                name: "parameter_names");

            migrationBuilder.DropTable(
                name: "component_types");
        }
    }
}
