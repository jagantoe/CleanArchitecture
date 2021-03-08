using FluentMigrator;
using CleanArchitecture.Database.Seed;

namespace CleanArchitecture.Database.Migrations
{
    [Migration(1)]
    public class M001_Initial: Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Email").AsString(50).NotNullable();

            this.SeedInitial();
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
