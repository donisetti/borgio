using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.GestorWeb.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "O campo NOME deve ser preenchido.")]
        [MaxLength(200), MinLength(2, ErrorMessage = "Nome deverá ter no mínimo 2 e no máximo 200 carateres")]
        [Display(Name = "Razão Social")]
        [StringLength(10)]
        public String Nome { get; set; }

        public string Tipo { get; set; }

        [StringLength(300)]
        public string Email { get; set; }


        public string Site { get; set; }


        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }


        [Display(Name = "Nome Fantasia")]
        public string Fantasia { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }


        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }


        [Display(Name = "Data da Constituição")]
        public DateTime? DataConstituicao { get; set; }
    }
}