namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TabelaBaixaComissoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baixas",
                c => new
                    {
                        BaixaId = c.Int(nullable: false, identity: true),
                        MensalidadeId = c.Int(nullable: false),
                        OperadoraId = c.Int(nullable: false),
                        Data = c.DateTime(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observacao = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.BaixaId)
                .ForeignKey("dbo.Operadoras", t => t.OperadoraId)
                .Index(t => t.OperadoraId);

            CreateTable(
                "dbo.Comissoes",
                c => new
                    {
                        ComissaoId = c.Int(nullable: false, identity: true),
                        MensalidadeId = c.Int(nullable: false),
                        NumeroContrato = c.String(maxLength: 150, unicode: false),
                        ComissaoCorretora = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComissaoCorretor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Corretor_PessoaId = c.Int(),
                        Operadora_OperadoraId = c.Int(),
                    })
                .PrimaryKey(t => t.ComissaoId)
                .ForeignKey("dbo.Colaboradores", t => t.Corretor_PessoaId)
                .ForeignKey("dbo.Operadoras", t => t.Operadora_OperadoraId)
                .Index(t => t.Corretor_PessoaId)
                .Index(t => t.Operadora_OperadoraId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Comissoes", "Operadora_OperadoraId", "dbo.Operadoras");
            DropForeignKey("dbo.Comissoes", "Corretor_PessoaId", "dbo.Colaboradores");
            DropForeignKey("dbo.Baixas", "OperadoraId", "dbo.Operadoras");
            DropIndex("dbo.Comissoes", new[] { "Operadora_OperadoraId" });
            DropIndex("dbo.Comissoes", new[] { "Corretor_PessoaId" });
            DropIndex("dbo.Baixas", new[] { "OperadoraId" });
            DropTable("dbo.Comissoes");
            DropTable("dbo.Baixas");
        }
    }
}
