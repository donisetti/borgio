namespace SuperBorgio.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteFornecedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtos", "Fornecedor1", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Produtos", "Fornecedor2", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Produtos", "Fornecedor3", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Produtos", "Fornecedor4", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Produtos", "Fornecedor5", c => c.String(maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtos", "Fornecedor5");
            DropColumn("dbo.Produtos", "Fornecedor4");
            DropColumn("dbo.Produtos", "Fornecedor3");
            DropColumn("dbo.Produtos", "Fornecedor2");
            DropColumn("dbo.Produtos", "Fornecedor1");
        }
    }
}
