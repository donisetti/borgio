namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class TabelaOcorrencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ocorrencias",
                c => new
                    {
                        OcorrenciaId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.OcorrenciaId);

        }

        public override void Down()
        {
            DropTable("dbo.Ocorrencias");
        }
    }
}
