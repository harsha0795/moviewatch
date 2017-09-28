namespace moviewatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alltables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        IsSubscribedNewsletter = c.Boolean(nullable: false),
                        MemberShipId = c.Int(nullable: false),
                        DOB = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberShips", t => t.MemberShipId, cascadeDelete: true)
                .Index(t => t.MemberShipId);
            
            CreateTable(
                "dbo.MemberShips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        signupFee = c.Int(nullable: false),
                        DurationMonths = c.Int(nullable: false),
                        DiscountPercentage = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        genre = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        genreid = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.genreid, cascadeDelete: true)
                .Index(t => t.genreid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genreid", "dbo.Genres");
            DropForeignKey("dbo.Customers", "MemberShipId", "dbo.MemberShips");
            DropIndex("dbo.Movies", new[] { "genreid" });
            DropIndex("dbo.Customers", new[] { "MemberShipId" });
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
            DropTable("dbo.MemberShips");
            DropTable("dbo.Customers");
        }
    }
}
