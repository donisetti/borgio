using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBorgio.Dominio.Entidades
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public string Fornecedor1 { get; set; }
        public Nullable<decimal> Custo1 { get; set; }
        public string Fornecedor2 { get; set; }
        public Nullable<decimal> Custo2 { get; set; }
        public string Fornecedor3 { get; set; }
        public Nullable<decimal> Custo3 { get; set; }
        public string Fornecedor4 { get; set; }
        public Nullable<decimal> Custo4 { get; set; }
        public string Fornecedor5 { get; set; }
        public Nullable<decimal> Custo5 { get; set; }
        
    }
}
