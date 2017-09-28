namespace moviewatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sql_membership_genre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres(genre) values('Comedy')");
            Sql("Insert into Genres(genre) values('Drama')");
            Sql("Insert into Genres(genre) values('Thriller')");
            Sql("Insert into Genres(genre) values('Romantic')");
            Sql("Insert into Genres(genre) values('Horror')");
            Sql("Insert into Genres(genre) values('Action')");
            Sql("Insert into Genres(genre) values('Strategy')");

            Sql("insert into MemberShips(DurationMonths,DiscountPercentage,signupFee) values(0,0,0)");
            Sql("insert into MemberShips(DurationMonths,DiscountPercentage,signupFee) values(3,5,20)");
            Sql("insert into MemberShips(DurationMonths,DiscountPercentage,signupFee) values(6,10,35)");
            Sql("insert into MemberShips(DurationMonths,DiscountPercentage,signupFee) values(12,20,60)");
        }
        
        public override void Down()
        {
        }
    }
}
