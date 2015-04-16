using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Kurtlewin.Dominio.Entidades;

namespace Base.GestorWeb.ViewModels
{
    public class LigacaoViewModel
    {
        [Key]
        public int LigacaoId { get; set; }

        public DateTime Data { get; set; }

        public Colaborador Corretor { get; set; }


        public string Atividade { get; set; }

        public string Assunto { get; set; }

        public string Acao { get; set; }

        public string Contato { get; set; }

        public string Solucao { get; set; }

        public string Anotacao { get; set; }

        public DateTime? Agenda { get; set; }
    }
}