namespace BorgioBase.Dominio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Tipo = c.String(maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                        Site = c.String(maxLength: 150, unicode: false),
                        TelResidencial = c.String(maxLength: 150, unicode: false),
                        TelCelular = c.String(maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        DataInativacao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId);

            CreateTable(
                "dbo.Operadoras",
                c => new
                    {
                        OperadoraId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        DataInativacao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OperadoraId);

            CreateTable(
                "dbo.PlanoSaudes",
                c => new
                    {
                        PlanoSaudeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150, unicode: false),
                        Comissao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantidadeParcelas = c.Int(nullable: false),
                        DataCadastro = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        DataInativacao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        Operadora_OperadoraId = c.Int(),
                    })
                .PrimaryKey(t => t.PlanoSaudeId)
                .ForeignKey("dbo.Operadoras", t => t.Operadora_OperadoraId)
                .Index(t => t.Operadora_OperadoraId);

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
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 150, unicode: false),
                        Senha = c.String(maxLength: 150, unicode: false),
                        Papel = c.String(maxLength: 150, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(),
                        DataAlteracao = c.DateTime(),
                        DataInativacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PessoasFisicas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                        IdEstadoCivil = c.Int(nullable: false),
                        Cpf = c.String(maxLength: 11, unicode: false),
                        Rg = c.String(maxLength: 20, unicode: false),
                        OrgaoRg = c.String(maxLength: 20, unicode: false),
                        DataEmissaoRg = c.DateTime(storeType: "date"),
                        DataNascimento = c.DateTime(storeType: "date"),
                        Sexo = c.String(maxLength: 10, unicode: false),
                        Naturalidade = c.String(maxLength: 100, unicode: false),
                        Nacionalidade = c.String(maxLength: 100, unicode: false),
                        Raca = c.String(maxLength: 1, unicode: false),
                        TipoSangue = c.String(maxLength: 3, unicode: false),
                        CnhNumero = c.String(maxLength: 20, unicode: false),
                        CnhCategoria = c.String(maxLength: 2, unicode: false),
                        CnhVencimento = c.DateTime(storeType: "date"),
                        TituloEleitoralNumero = c.String(maxLength: 20, unicode: false),
                        TituloEleitoralZona = c.Int(),
                        TituloEleitoralSecao = c.Int(),
                        ReservistaNumero = c.String(maxLength: 20, unicode: false),
                        ReservistaCategoria = c.Int(),
                        NomeMae = c.String(maxLength: 200, unicode: false),
                        NomePai = c.String(maxLength: 200, unicode: false),
                        CarteiraNacionalSaude = c.String(maxLength: 20, unicode: false),
                        DeclaracaoNascidoVivo = c.String(maxLength: 20, unicode: false),
                        PisPasep = c.String(maxLength: 100, unicode: false),
                        Profissao = c.String(maxLength: 100, unicode: false),
                        PaisOrigem = c.String(maxLength: 100, unicode: false),
                        Altura = c.String(maxLength: 20, unicode: false),
                        Peso = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .Index(t => t.PessoaId);

            CreateTable(
                "dbo.Colaboradores",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                        Cargo = c.String(maxLength: 150, unicode: false),
                        DataAdmissao = c.DateTime(storeType: "date"),
                        DataDemissao = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.PessoasFisicas", t => t.PessoaId)
                .Index(t => t.PessoaId);

            CreateTable(
                "dbo.Dependentes",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                        TitularId = c.Int(nullable: false),
                        Parentesco = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.PessoasFisicas", t => t.PessoaId)
                .Index(t => t.PessoaId);

            CreateTable(
                "dbo.PessoasJuridicas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                        Cnpj = c.String(maxLength: 16, unicode: false),
                        Fantasia = c.String(maxLength: 150, unicode: false),
                        InscricaoMunicipal = c.String(maxLength: 30, unicode: false),
                        InscricaoEstadual = c.String(maxLength: 30, unicode: false),
                        DataConstituicao = c.DateTime(storeType: "date"),
                        TipoRegime = c.String(maxLength: 1, unicode: false),
                        Crt = c.String(maxLength: 1, unicode: false),
                        Suframa = c.String(maxLength: 9, unicode: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Pessoas", t => t.PessoaId)
                .Index(t => t.PessoaId);

            CreateTable(
                "dbo.Titulares",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.PessoasFisicas", t => t.PessoaId)
                .Index(t => t.PessoaId);

            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.PessoasJuridicas", t => t.PessoaId)
                .Index(t => t.PessoaId);

            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.PessoasJuridicas", t => t.PessoaId)
                .Index(t => t.PessoaId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Empresas", "PessoaId", "dbo.PessoasJuridicas");
            DropForeignKey("dbo.Clientes", "PessoaId", "dbo.PessoasJuridicas");
            DropForeignKey("dbo.Titulares", "PessoaId", "dbo.PessoasFisicas");
            DropForeignKey("dbo.PessoasJuridicas", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.Dependentes", "PessoaId", "dbo.PessoasFisicas");
            DropForeignKey("dbo.Colaboradores", "PessoaId", "dbo.PessoasFisicas");
            DropForeignKey("dbo.PessoasFisicas", "PessoaId", "dbo.Pessoas");
            DropForeignKey("dbo.PlanoSaudes", "Operadora_OperadoraId", "dbo.Operadoras");
            DropIndex("dbo.Empresas", new[] { "PessoaId" });
            DropIndex("dbo.Clientes", new[] { "PessoaId" });
            DropIndex("dbo.Titulares", new[] { "PessoaId" });
            DropIndex("dbo.PessoasJuridicas", new[] { "PessoaId" });
            DropIndex("dbo.Dependentes", new[] { "PessoaId" });
            DropIndex("dbo.Colaboradores", new[] { "PessoaId" });
            DropIndex("dbo.PessoasFisicas", new[] { "PessoaId" });
            DropIndex("dbo.PlanoSaudes", new[] { "Operadora_OperadoraId" });
            DropTable("dbo.Empresas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Titulares");
            DropTable("dbo.PessoasJuridicas");
            DropTable("dbo.Dependentes");
            DropTable("dbo.Colaboradores");
            DropTable("dbo.PessoasFisicas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.TabelasAuxiliares");
            DropTable("dbo.PlanoSaudes");
            DropTable("dbo.Operadoras");
            DropTable("dbo.Pessoas");
        }
    }
}
