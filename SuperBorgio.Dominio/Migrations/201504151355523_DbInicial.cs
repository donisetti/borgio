namespace SuperBorgio.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TabelasAuxiliares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150, unicode: false),
                        Tipo = c.String(maxLength: 150, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        DataInativacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 50, unicode: false),
                        Descricao = c.String(maxLength: 300, unicode: false),
                        Custo1 = c.Decimal(precision: 18, scale: 2),
                        Custo2 = c.Decimal(precision: 18, scale: 2),
                        Custo3 = c.Decimal(precision: 18, scale: 2),
                        Custo4 = c.Decimal(precision: 18, scale: 2),
                        Custo5 = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtos");
            DropTable("dbo.TabelasAuxiliares");
        }
    }
}
