namespace AspMVCAdminLTE.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(),
                    Mobile = c.String(nullable: false, maxLength: 12),
                    UserName = c.String(nullable: false, maxLength: 20),
                    Password = c.String(nullable: false),
                    IsMobileVerified = c.Boolean(nullable: false),
                    DateOfBirth = c.DateTime(),
                    Email = c.String(maxLength: 100),
                    Gender = c.Int(nullable: false),
                    IsEmailVerified = c.Boolean(nullable: false),
                    ProfilePic = c.String(),
                    UserRole = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Mobile, unique: true, name: "IX_MobileNumber")
                .Index(t => t.UserName, unique: true, name: "IX_Username")
                .Index(t => t.Email, unique: true);
        }

        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", "IX_Username");
            DropIndex("dbo.Users", "IX_MobileNumber");
            DropTable("dbo.Users");
        }
    }
}