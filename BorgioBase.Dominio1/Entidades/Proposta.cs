using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorgioBase.Dominio1.Entidades;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("Propostas")]
    public class Proposta : Entidade
    {
        public Proposta()
        {
            this.Dependentes = new List<Dependente>();
        }

        [Key]
        public int PropostaId { get; set; }
        [StringLength(20)]
        public string NumeroProposta { get; set; }

        [ForeignKey("ProponenteId")]
        [Required(ErrorMessage = "Proponente Titular é obrigátorio")]
        public Titular Proponente { get; set; }

        public int ProponenteId { get; set; }

        [ForeignKey("VendedorId")]
        [Required(ErrorMessage = "Corretor é obrigátorio")]
        public Colaborador Vendedor { get; set; }

        public int VendedorId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataProposta { get; set; }

        [Column(TypeName = "date")]
        public DateTime VigenciaInicio { get; set; }

        [ForeignKey("EmpresaId")]
        [Required(ErrorMessage = "Empresa é obrigátorio")]
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }

        public List<Dependente> Dependentes { get; set; }


    }
}
