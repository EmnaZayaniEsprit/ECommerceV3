namespace ECommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("promotion", "Iduser", c => c.Int(nullable: false));
            CreateIndex("promotion", "Iduser");
            AddForeignKey("promotion", "Iduser", "user", "idUser", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("promotion", "Iduser", "user");
            DropIndex("promotion", new[] { "Iduser" });
            DropColumn("promotion", "Iduser");
        }
    }
}
