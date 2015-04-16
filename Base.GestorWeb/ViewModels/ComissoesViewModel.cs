using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Kurtlewin.Dominio.Entidades;

namespace Base.GestorWeb.ViewModels
{
    public class ComissoesViewModel
    {
        [Key]
        public int ComissaoId { get; set; }
        public int MensalidadeId { get; set; }

        public Colaborador Corretor { get; set; }

        public DateTime? Data { get; set; }

        public Decimal Valor { get; set; }

        public string Observacao { get; set; }
    }
}