namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RevisaoContrato : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contratos",
                c => new
                    {
                        PropostaId = c.Int(nullable: false),
                        NumeroContrato = c.String(maxLength: 150, unicode: false),
                        DataContrato = c.DateTime(nullable: false, storeType: "date"),
                        ComissaoVendedor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComissaoCorretora = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PropostaId)
                .ForeignKey("dbo.Propostas", t => t.PropostaId)
                .Index(t => t.PropostaId);

            AddColumn("dbo.Mensalidades", "Contrato_PropostaId", c => c.Int());
            CreateIndex("dbo.Mensalidades", "Contrato_PropostaId");
            AddForeignKey("dbo.Mensalidades", "Contrato_PropostaId", "dbo.Contratos", "PropostaId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Contratos", "PropostaId", "dbo.Propostas");
            DropForeignKey("dbo.Mensalidades", "Contrato_PropostaId", "dbo.Contratos");
            DropIndex("dbo.Contratos", new[] { "PropostaId" });
            DropIndex("dbo.Mensalidades", new[] { "Contrato_PropostaId" });
            DropColumn("dbo.Mensalidades", "Contrato_PropostaId");
            DropTable("dbo.Contratos");
        }
    }
}
