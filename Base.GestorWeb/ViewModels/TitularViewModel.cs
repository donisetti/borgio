using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Base.GestorWeb.ViewModels
{
    public class TitularViewModel
    {
        [Key]
        public int PessoaId { get; set; }
        [Required(ErrorMessage = "O campo NOME deve ser preenchido.")]
        [MaxLength(200), MinLength(2, ErrorMessage = "Nome deverá ter no mínimo 2 e no máximo 200 carateres")]
        public String Nome { get; set; }
        //public string Cargo { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Site { get; set; }

        public int IdEstadoCivil { get; set; }

        [StringLength(11)]
        public string Cpf { get; set; }

        [StringLength(20)]
        public string Rg { get; set; }

        [StringLength(20)]
        public string OrgaoRg { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataEmissaoRg { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DataNascimento { get; set; }

        [StringLength(10)]
        public string Sexo { get; set; }

        [StringLength(100)]
        public string Naturalidade { get; set; }

        [StringLength(100)]
        public string Nacionalidade { get; set; }

        [StringLength(1)]
        public string Raca { get; set; }

        [StringLength(3)]
        public string TipoSangue { get; set; }

        [StringLength(20)]
        public string CnhNumero { get; set; }

        [StringLength(2)]
        public string CnhCategoria { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CnhVencimento { get; set; }

        [StringLength(20)]
        public string TituloEleitoralNumero { get; set; }

        public int? TituloEleitoralZona { get; set; }

        public int? TituloEleitoralSecao { get; set; }

        [StringLength(20)]
        public string ReservistaNumero { get; set; }

        public int? ReservistaCategoria { get; set; }

        [StringLength(200)]
        [Display(Name = "Nome da Mãe:")]
        public string NomeMae { get; set; }

        [StringLength(200)]
        [Display(Name = "Nome do Pai:")]
        public string NomePai { get; set; }

        [StringLength(200)]
        public string Apolice { get; set; }
    }
}