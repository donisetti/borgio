namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TabelaOcorrencias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ocorrencias", "Data", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ocorrencias", "Contato", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Ocorrencias", "Atividade", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Ocorrencias", "Assunto", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Ocorrencias", "Acao", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Ocorrencias", "Situacao", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Ocorrencias", "Solucao", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Ocorrencias", "Anotacao", c => c.String(maxLength: 150, unicode: false));
            AddColumn("dbo.Ocorrencias", "Atendente_PessoaId", c => c.Int());
            AddColumn("dbo.Ocorrencias", "Contrato_PropostaId", c => c.Int());
            CreateIndex("dbo.Ocorrencias", "Atendente_PessoaId");
            CreateIndex("dbo.Ocorrencias", "Contrato_PropostaId");
            AddForeignKey("dbo.Ocorrencias", "Atendente_PessoaId", "dbo.Colaboradores", "PessoaId");
            AddForeignKey("dbo.Ocorrencias", "Contrato_PropostaId", "dbo.Contratos", "PropostaId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Ocorrencias", "Contrato_PropostaId", "dbo.Contratos");
            DropForeignKey("dbo.Ocorrencias", "Atendente_PessoaId", "dbo.Colaboradores");
            DropIndex("dbo.Ocorrencias", new[] { "Contrato_PropostaId" });
            DropIndex("dbo.Ocorrencias", new[] { "Atendente_PessoaId" });
            DropColumn("dbo.Ocorrencias", "Contrato_PropostaId");
            DropColumn("dbo.Ocorrencias", "Atendente_PessoaId");
            DropColumn("dbo.Ocorrencias", "Anotacao");
            DropColumn("dbo.Ocorrencias", "Solucao");
            DropColumn("dbo.Ocorrencias", "Situacao");
            DropColumn("dbo.Ocorrencias", "Acao");
            DropColumn("dbo.Ocorrencias", "Assunto");
            DropColumn("dbo.Ocorrencias", "Atividade");
            DropColumn("dbo.Ocorrencias", "Contato");
            DropColumn("dbo.Ocorrencias", "Data");
        }
    }
}
