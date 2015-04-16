using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperBorgio.Dominio.Entidades;
using SuperBorgio.Dominio.Utilitarios;


namespace SuperBorgio.Dominio.Contexto
{
    class PreparaDbcontexto : DropCreateDatabaseAlways<DbContexto>
    {
        protected override void Seed(DbContexto contexto)
        {
           // contexto.Database.Log = Console.Write;

            //PopularBaseDados(contexto);

            base.Seed(contexto);
        }

        private static void PopularBaseDados(DbContexto contexto)
        {
            try
            {

                PopularTabelasAuxiliares(contexto);
                contexto.Commit();

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message + Environment.NewLine + erro.StackTrace);
            }

        }

        private static void PopularTabelasAuxiliares(DbContexto contexto)
        {

            var tabelasAuxliares = new List<TabelaAuxiliar>
            {
                new TabelaAuxiliar {Id = 1, Nome = "Indefinido", Tipo = "", Ativo = false},
                new TabelaAuxiliar {Id = 2, Nome = "Indústria - Confecção", Tipo = "Ramo de Atividade", Ativo = true},
                new TabelaAuxiliar {Id = 3, Nome = "Industria - Metalurgica", Tipo = "Ramo de Atividade", Ativo = true},
                new TabelaAuxiliar {Id = 4, Nome = "Educação - Escola de Idiomas", Tipo = "Ramo de Atividade", Ativo = true},
                new TabelaAuxiliar {Id = 5, Nome = "Educação - Ensino Básico", Tipo = "Ramo de Atividade", Ativo = true},
                new TabelaAuxiliar {Id = 6, Nome = "Serviços - Contabilidade", Tipo = "Ramo de Atividade", Ativo = true},
                new TabelaAuxiliar {Id = 7, Nome = "Saúde - Odontologia", Tipo = "Ramo de Atividade", Ativo = true},
                new TabelaAuxiliar {Id = 8, Nome = "Serviços - Advogado", Tipo = "Ramo de Atividade", Ativo = true},
                new TabelaAuxiliar {Id = 9, Nome = "Governo - Prefeitura", Tipo = "Ramo de Atividade", Ativo = true},

                new TabelaAuxiliar {Id = 11, Nome = "Brasileira",   Tipo = "Nacionalidade", Ativo = true},
                new TabelaAuxiliar {Id = 12, Nome = "Americana",    Tipo = "Nacionalidade", Ativo = true},
                new TabelaAuxiliar {Id = 13, Nome = "Argentina",    Tipo = "Nacionalidade", Ativo = true},
                new TabelaAuxiliar {Id = 14, Nome = "Espanhola",    Tipo = "Nacionalidade", Ativo = true},
                new TabelaAuxiliar {Id = 15, Nome = "Inglesa",      Tipo = "Nacionalidade", Ativo = true},
                new TabelaAuxiliar {Id = 16, Nome = "Russa",        Tipo = "Nacionalidade", Ativo = true},

                new TabelaAuxiliar {Id = 17, Nome = "Analista de Sistema",   Tipo = "Cargo", Ativo = true},
                new TabelaAuxiliar {Id = 18, Nome = "Gerente",   Tipo = "Cargo", Ativo = true},
                new TabelaAuxiliar {Id = 19, Nome = "Vendedor",   Tipo = "Cargo", Ativo = true},
                new TabelaAuxiliar {Id = 20, Nome = "Supervisor",   Tipo = "Cargo", Ativo = true},
                new TabelaAuxiliar {Id = 21, Nome = "Contador",   Tipo = "Cargo", Ativo = true},
                new TabelaAuxiliar {Id = 22, Nome = "Diretor",   Tipo = "Cargo", Ativo = true},
                new TabelaAuxiliar {Id = 23, Nome = "Médico",   Tipo = "Cargo", Ativo = true},
                new TabelaAuxiliar {Id = 24, Nome = "Motorista",   Tipo = "Cargo", Ativo = true},

                 new TabelaAuxiliar {Id = 25, Nome = "Quarto",   Tipo = "Acomodações", Ativo = true},
                 new TabelaAuxiliar {Id = 26, Nome = "Enfermaria",   Tipo = "Acomodações", Ativo = true},
                 new TabelaAuxiliar {Id = 27, Nome = "Quarto Coletivo",   Tipo = "Acomodações", Ativo = true},
                 new TabelaAuxiliar {Id = 28, Nome = "Quarto Individual",   Tipo = "Acomodações", Ativo = true},
                 new TabelaAuxiliar {Id = 29, Nome = "Quarto Especial",   Tipo = "Acomodações", Ativo = true},
                 new TabelaAuxiliar {Id = 30, Nome = "Com participação",   Tipo = "Tipo de Plano", Ativo = true},
                 new TabelaAuxiliar {Id = 31, Nome = "Sem participação",   Tipo = "Tipo de Plano", Ativo = true},
                 new TabelaAuxiliar {Id = 32, Nome = "Associação 01",   Tipo = "Tipo de Associação", Ativo = true},
                 new TabelaAuxiliar {Id = 33, Nome = "Associação 02",   Tipo = "Tipo de Associação", Ativo = true},
                 new TabelaAuxiliar {Id = 34, Nome = "Associação 03",   Tipo = "Tipo de Associação", Ativo = true}



            };

            tabelasAuxliares.ForEach(tabela => contexto.TabelasAuxiliares.Add(tabela));
        }



    }


}
