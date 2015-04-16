namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RevisaoProposta : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Propostas", new[] { "Empresa_PessoaId" });
            RenameColumn(table: "dbo.Propostas", name: "Empresa_PessoaId", newName: "EmpresaId");
            AlterColumn("dbo.Propostas", "EmpresaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Propostas", "EmpresaId");
        }

        public override void Down()
        {
            DropIndex("dbo.Propostas", new[] { "EmpresaId" });
            AlterColumn("dbo.Propostas", "EmpresaId", c => c.Int());
            RenameColumn(table: "dbo.Propostas", name: "EmpresaId", newName: "Empresa_PessoaId");
            CreateIndex("dbo.Propostas", "Empresa_PessoaId");
        }
    }
}
