using System;
using System.Collections.Generic;

namespace SuperBorgio.Models
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public Nullable<decimal> Custo1 { get; set; }
        public Nullable<decimal> Custo2 { get; set; }
        public Nullable<decimal> Custo3 { get; set; }
        public Nullable<decimal> Custo4 { get; set; }
        public Nullable<decimal> Custo5 { get; set; }
    }
}
