namespace moviewatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalize : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ProofId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProofId", c => c.Int(nullable: false));
        }
    }
}
