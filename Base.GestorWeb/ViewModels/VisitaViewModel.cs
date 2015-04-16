using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Kurtlewin.Dominio.Entidades;

namespace Base.GestorWeb.ViewModels
{
    public class VisitaViewModel
    {

        [Key]
        public int VisitaId { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Data da Visita:")]
        public DateTime Data { get; set; }

        public Colaborador Corretor { get; set; }

        public Cliente Prospecto { get; set; }

        public string Atividade { get; set; }

        public string Assunto { get; set; }

        public string Contato { get; set; }

        public string Solucao { get; set; }

        public string Anotacao { get; set; }

        public DateTime? Agenda { get; set; }


    }
}