namespace moviewatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6593dfae-b8d3-40bd-9d80-9a335d9b9270', N'guest@moviewatch.com', 0, N'AOCerMtG0cjS1cv4apOJjbse31Y4DTTfJqO2DK8J/7II9HQ/G05EcPO1Q47p74FFsA==', N'32b235e0-8de1-4e09-ac39-2aafedef5e8e', NULL, 0, 0, NULL, 1, 0, N'guest@moviewatch.com')
            INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f34ae495-abdc-4e68-aa13-db4ec55f0ab4', N'admin@moviewatch.com', 0, N'ABXriu/E076qvf4cYItvgMIhE5s2Fe+/pMU3TDS5vgJ9UIkT94/7kLYDIrOMAMhs7w==', N'f2fe3991-e942-42c6-9452-2a6f2c897742', NULL, 0, 0, NULL, 1, 0, N'admin@moviewatch.com')
            ");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'63e3014f-ae04-462f-8069-a70bfe74d495', N'ManageMovies')
            ");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f34ae495-abdc-4e68-aa13-db4ec55f0ab4', N'63e3014f-ae04-462f-8069-a70bfe74d495')
");
        }
        
        public override void Down()
        {
        }
    }
}
