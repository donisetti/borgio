using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Ocorrencias")]
    public class Ocorrencia
    {
        [Key]
        public int OcorrenciaId { get; set; }
        public Contrato Contrato { get; set; }

        public DateTime Data { get; set; }

        public Colaborador Atendente { get; set; }


        public string Contato { get; set; }

        public string Atividade { get; set; }

        public string Assunto { get; set; }

        public string Acao { get; set; }

        public string Situacao { get; set; }



        public string Solucao { get; set; }

        public string Anotacao { get; set; }
    }
}
