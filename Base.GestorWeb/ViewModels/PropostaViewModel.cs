using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Kurtlewin.Dominio.Entidades;

namespace Base.GestorWeb.ViewModels
{

    public class PropostaViewModel
    {


        [Key]
        public int PropostaId { get; set; }
        [StringLength(20)]
        [Display(Name = "Proposta nº: ")]
        public string NumeroProposta { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome da Mãe: ")]
        public string NomeMae { get; set; }


        [Display(Name = "Titular:")]
        public Titular Proponente { get; set; }

        [Display(Name = "Corretor:")]
        public Colaborador Vendedor { get; set; }








        [Column(TypeName = "date")]
        [Display(Name = "Data da Proposta:")]
        public DateTime DataProposta { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Início da Vigência:")]
        public DateTime VigenciaInicio { get; set; }

        public Empresa Empresa { get; set; }

        public List<Dependente> Dependentes { get; set; }
    }
}