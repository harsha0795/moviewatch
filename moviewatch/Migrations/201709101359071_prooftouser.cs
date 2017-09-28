namespace moviewatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prooftouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProofId", c => c.Int(nullable: false, defaultValue:1));
            AddColumn("dbo.AspNetUsers", "TypeProof", c => c.String(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ProofId");
            AddForeignKey("dbo.AspNetUsers", "ProofId", "dbo.Proofs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ProofId", "dbo.Proofs");
            DropIndex("dbo.AspNetUsers", new[] { "ProofId" });
            DropColumn("dbo.AspNetUsers", "TypeProof");
            DropColumn("dbo.AspNetUsers", "ProofId");
        }
    }
}
