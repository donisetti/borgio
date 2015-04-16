using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorgioBase.Dominio1.Entidades
{
    [Table("TabelasAuxiliares")]
    public class TabelaAuxiliar : Entidade
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }

        //public String EstaAtivo
        //{
        //    get { return  Ativo ? "Sim" : "Não"; }            
        //}        

    }
}
