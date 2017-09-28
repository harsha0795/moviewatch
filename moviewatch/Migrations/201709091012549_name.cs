namespace moviewatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            Sql("update MemberShips set Name = 'Pay as You go' where Id=1");
            Sql("update MemberShips set Name = 'Quarterly' where Id=2");
            Sql("update MemberShips set Name = 'Half Yearly' where Id=3");
            Sql("update MemberShips set Name = 'Yearly' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
