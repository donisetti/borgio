namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class revisaotitular : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Titulares", "Apolice", c => c.String(maxLength: 150, unicode: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Titulares", "Apolice");
        }
    }
}
