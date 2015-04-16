namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TabelaMensalidade : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Propostas", new[] { "Proponente_PessoaId" });
            DropIndex("dbo.Propostas", new[] { "Vendedor_PessoaId" });
            RenameColumn(table: "dbo.Propostas", name: "Proponente_PessoaId", newName: "ProponenteId");
            RenameColumn(table: "dbo.Propostas", name: "Vendedor_PessoaId", newName: "VendedorId");
            CreateTable(
                "dbo.Mensalidades",
                c => new
                    {
                        MensalidadeId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(),
                        Vencimento = c.DateTime(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComissaoCorretora = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComissaoCorretor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PagamentoCliente = c.DateTime(),
                        PagamentoCorretora = c.DateTime(),
                        PagamentoCorretor = c.DateTime(),
                        Cliente_PessoaId = c.Int(),
                        Corretor_PessoaId = c.Int(),
                        Operadora_OperadoraId = c.Int(),
                    })
                .PrimaryKey(t => t.MensalidadeId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_PessoaId)
                .ForeignKey("dbo.Colaboradores", t => t.Corretor_PessoaId)
                .ForeignKey("dbo.Operadoras", t => t.Operadora_OperadoraId)
                .Index(t => t.Cliente_PessoaId)
                .Index(t => t.Corretor_PessoaId)
                .Index(t => t.Operadora_OperadoraId);

            CreateTable(
                "dbo.Visitas",
                c => new
                    {
                        VisitaId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Atividade = c.String(maxLength: 150, unicode: false),
                        Assunto = c.String(maxLength: 150, unicode: false),
                        Contato = c.String(maxLength: 150, unicode: false),
                        Solucao = c.String(maxLength: 150, unicode: false),
                        Anotacao = c.String(maxLength: 150, unicode: false),
                        Agenda = c.DateTime(),
                        Corretor_PessoaId = c.Int(),
                        Prospecto_PessoaId = c.Int(),
                    })
                .PrimaryKey(t => t.VisitaId)
                .ForeignKey("dbo.Colaboradores", t => t.Corretor_PessoaId)
                .ForeignKey("dbo.Clientes", t => t.Prospecto_PessoaId)
                .Index(t => t.Corretor_PessoaId)
                .Index(t => t.Prospecto_PessoaId);

            AlterColumn("dbo.Propostas", "ProponenteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Propostas", "VendedorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Propostas", "ProponenteId");
            CreateIndex("dbo.Propostas", "VendedorId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Visitas", "Prospecto_PessoaId", "dbo.Clientes");
            DropForeignKey("dbo.Visitas", "Corretor_PessoaId", "dbo.Colaboradores");
            DropForeignKey("dbo.Mensalidades", "Operadora_OperadoraId", "dbo.Operadoras");
            DropForeignKey("dbo.Mensalidades", "Corretor_PessoaId", "dbo.Colaboradores");
            DropForeignKey("dbo.Mensalidades", "Cliente_PessoaId", "dbo.Clientes");
            DropIndex("dbo.Visitas", new[] { "Prospecto_PessoaId" });
            DropIndex("dbo.Visitas", new[] { "Corretor_PessoaId" });
            DropIndex("dbo.Propostas", new[] { "VendedorId" });
            DropIndex("dbo.Propostas", new[] { "ProponenteId" });
            DropIndex("dbo.Mensalidades", new[] { "Operadora_OperadoraId" });
            DropIndex("dbo.Mensalidades", new[] { "Corretor_PessoaId" });
            DropIndex("dbo.Mensalidades", new[] { "Cliente_PessoaId" });
            AlterColumn("dbo.Propostas", "VendedorId", c => c.Int());
            AlterColumn("dbo.Propostas", "ProponenteId", c => c.Int());
            DropTable("dbo.Visitas");
            DropTable("dbo.Mensalidades");
            RenameColumn(table: "dbo.Propostas", name: "VendedorId", newName: "Vendedor_PessoaId");
            RenameColumn(table: "dbo.Propostas", name: "ProponenteId", newName: "Proponente_PessoaId");
            CreateIndex("dbo.Propostas", "Vendedor_PessoaId");
            CreateIndex("dbo.Propostas", "Proponente_PessoaId");
        }
    }
}
