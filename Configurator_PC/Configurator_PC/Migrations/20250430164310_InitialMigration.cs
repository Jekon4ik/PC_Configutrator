using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Configurator_PC.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    Password = table.Column<string>(type: "text", nullable: true)
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
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
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
                name: "compatibility_rules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComponentType1Id = table.Column<int>(type: "integer", nullable: false),
                    ComponentType2Id = table.Column<int>(type: "integer", nullable: false),
                    ParameterNameId = table.Column<int>(type: "integer", nullable: false),
                    Operator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compatibility_rules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_compatibility_rules_component_types_ComponentType1Id",
                        column: x => x.ComponentType1Id,
                        principalTable: "component_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compatibility_rules_component_types_ComponentType2Id",
                        column: x => x.ComponentType2Id,
                        principalTable: "component_types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compatibility_rules_parameter_names_ParameterNameId",
                        column: x => x.ParameterNameId,
                        principalTable: "parameter_names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_configurations_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
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

            migrationBuilder.CreateIndex(
                name: "IX_compatibility_rules_ComponentType1Id",
                table: "compatibility_rules",
                column: "ComponentType1Id");

            migrationBuilder.CreateIndex(
                name: "IX_compatibility_rules_ComponentType2Id",
                table: "compatibility_rules",
                column: "ComponentType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_compatibility_rules_ParameterNameId",
                table: "compatibility_rules",
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
                name: "IX_configurations_UserId",
                table: "configurations",
                column: "UserId");

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
                name: "compatibility_rules");

            migrationBuilder.DropTable(
                name: "component_type_parameter_names");

            migrationBuilder.DropTable(
                name: "configuration_components");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.DropTable(
                name: "configurations");

            migrationBuilder.DropTable(
                name: "components");

            migrationBuilder.DropTable(
                name: "parameter_names");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "component_types");
        }
    }
}
