namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TabelaProposta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Propostas",
                c => new
                    {
                        PropostaId = c.Int(nullable: false, identity: true),
                        NumeroProposta = c.String(maxLength: 20, unicode: false),
                        DataProposta = c.DateTime(nullable: false, storeType: "date"),
                        VigenciaInicio = c.DateTime(nullable: false, storeType: "date"),
                        DataCadastro = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        DataInativacao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Empresa_PessoaId = c.Int(),
                        Proponente_PessoaId = c.Int(),
                        Vendedor_PessoaId = c.Int(),
                    })
                .PrimaryKey(t => t.PropostaId)
                .ForeignKey("dbo.Empresas", t => t.Empresa_PessoaId)
                .ForeignKey("dbo.Titulares", t => t.Proponente_PessoaId)
                .ForeignKey("dbo.Colaboradores", t => t.Vendedor_PessoaId)
                .Index(t => t.Empresa_PessoaId)
                .Index(t => t.Proponente_PessoaId)
                .Index(t => t.Vendedor_PessoaId);

            AddColumn("dbo.Dependentes", "Proposta_PropostaId", c => c.Int());
            CreateIndex("dbo.Dependentes", "Proposta_PropostaId");
            AddForeignKey("dbo.Dependentes", "Proposta_PropostaId", "dbo.Propostas", "PropostaId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Dependentes", "Proposta_PropostaId", "dbo.Propostas");
            DropForeignKey("dbo.Propostas", "Vendedor_PessoaId", "dbo.Colaboradores");
            DropForeignKey("dbo.Propostas", "Proponente_PessoaId", "dbo.Titulares");
            DropForeignKey("dbo.Propostas", "Empresa_PessoaId", "dbo.Empresas");
            DropIndex("dbo.Dependentes", new[] { "Proposta_PropostaId" });
            DropIndex("dbo.Propostas", new[] { "Vendedor_PessoaId" });
            DropIndex("dbo.Propostas", new[] { "Proponente_PessoaId" });
            DropIndex("dbo.Propostas", new[] { "Empresa_PessoaId" });
            DropColumn("dbo.Dependentes", "Proposta_PropostaId");
            DropTable("dbo.Propostas");
        }
    }
}
