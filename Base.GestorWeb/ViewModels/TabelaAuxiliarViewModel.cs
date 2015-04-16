using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.GestorWeb.ViewModels
{
    public class TabelaAuxiliarViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo NOME deve ser preenchido.")]
        [MaxLength(200), MinLength(2, ErrorMessage = "Nome deverá ter no mínimo 2 e no máximo 200 carateres")]
        public String Nome { get; set; }
        //public string Cargo { get; set; }

        public string Tipo { get; set; }
        public bool Ativo { get; set; }

        public String EstaAtivo
        {
            get { return Ativo ? "Sim" : "Não"; }
        }
    }
}