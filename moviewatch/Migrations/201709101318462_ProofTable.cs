namespace moviewatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProofTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proofs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProofType = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);

            Sql("Insert into proofs(ProofType) values('Election Commission ID')");
            Sql("Insert into proofs(ProofType) values('Aadhar Card')");
            Sql("Insert into proofs(ProofType) values('PAN Card')");
            Sql("Insert into proofs(ProofType) values('Passport')");

        }

        public override void Down()
        {
            DropTable("dbo.Proofs");
        }
    }
}
