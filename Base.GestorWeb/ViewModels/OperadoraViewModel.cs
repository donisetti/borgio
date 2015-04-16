using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.GestorWeb.ViewModels
{
    public class OperadoraViewModel
    {
        [Key]
        [Display(Name = "Código")]
        public int OperadoraId { get; set; }

        [Display(Name = "Operadora")]
        public String Nome { get; set; }
    }
}