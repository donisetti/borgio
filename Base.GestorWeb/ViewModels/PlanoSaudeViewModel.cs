using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.GestorWeb.ViewModels
{
    public class PlanoSaudeViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int PlanoSaudeId { get; set; }

        [Display(Name = "Plano de Saúde")]
        public String Nome { get; set; }
    }
}