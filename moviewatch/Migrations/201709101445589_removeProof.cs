namespace moviewatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeProof : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ProofId", "dbo.Proofs");
            DropIndex("dbo.AspNetUsers", new[] { "ProofId" });
            DropTable("dbo.Proofs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Proofs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProofType = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AspNetUsers", "ProofId");
            AddForeignKey("dbo.AspNetUsers", "ProofId", "dbo.Proofs", "Id", cascadeDelete: true);
        }
    }
}
