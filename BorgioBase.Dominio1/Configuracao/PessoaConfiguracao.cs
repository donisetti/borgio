using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorgioBase.Dominio1.Entidades;

namespace BorgioBase.Dominio1.Configuracao
{
    public class PessoaConfiguracao : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguracao()
        {
            ToTable("Pessoas");
            HasKey(p => p.PessoaId);

            Property(p => p.PessoaId)
            .HasColumnName("PessoaId")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(250);


        }

    }

    public class PessoaFisicaConfiguracao : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfiguracao()
        {

        }
    }

    public class PessoaJuridicaConfiguracao : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaConfiguracao()
        {

        }
    }
}
