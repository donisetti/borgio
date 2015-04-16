using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Base.GestorWeb.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public int PessoaId { get; set; }


        [Required(ErrorMessage = "O campo NOME deve ser preenchido.")]
        [MaxLength(200), MinLength(2, ErrorMessage = "Nome deverá ter no mínimo 2 e no máximo 200 carateres")]
        public String Nome { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }

        [Display(Name = "Telefone Comercial")]
        public string TelResidencial { get; set; }

        [Display(Name = "Telefone Celular")]
        public string TelCelular { get; set; }

        public string Site { get; set; }


        //public string TelResidencial { get; set; }
        //public string TelCelular { get; set; }








    }
}