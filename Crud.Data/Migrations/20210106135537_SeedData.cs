using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Projects (Name) Values ('Marsa')");
            migrationBuilder
                .Sql("INSERT INTO Projects (Name) Values ('Besler')");
            migrationBuilder
               .Sql("INSERT INTO Projects (Name) Values ('Sugav')");
            migrationBuilder
               .Sql("INSERT INTO Projects (Name) Values ('Mkk')");

            migrationBuilder
                .Sql("INSERT INTO Plugins (Title,Size, ProjectId) Values ('Unigate.Plugins.Parameter',355, (SELECT Id FROM Projects WHERE Name = 'Marsa'))");

            migrationBuilder
            .Sql("INSERT INTO Plugins (Title,Size, ProjectId) Values ('Unigate.Plugins.Language', 440,(SELECT Id FROM Projects WHERE Name = 'Besler'))");
            migrationBuilder
            .Sql("INSERT INTO Plugins (Title,Size, ProjectId) Values ('Unigate.Plugins.Contact', 380,(SELECT Id FROM Projects WHERE Name = 'Sugav'))");
            migrationBuilder
            .Sql("INSERT INTO Plugins (Title,Size, ProjectId) Values ('Unigate.Plugins.Blog',420, (SELECT Id FROM Projects WHERE Name = 'Mkk'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("Delete FROM Projects");
            migrationBuilder
                .Sql("Delete FROM Plugins");
        }
    }
}
