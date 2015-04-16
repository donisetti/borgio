using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperBorgio.GestorWeb.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Código de Barra")]
        public string Codigo { get; set; }
        [Display(Name = "Descrição do Produto")]
        public string Descricao { get; set; }


        [Display(Name = "Preço Custo 1")]
        public Nullable<decimal> Custo1 { get; set; }

        [Display(Name = "Fornecedor 1")]
        public string Fornecedor1 { get; set; }

        [Display(Name = "Preço Custo 2")]
        public Nullable<decimal> Custo2 { get; set; }


        [Display(Name = "Fornecedor 2")]
        public string Fornecedor2 { get; set; }

        [Display(Name = "Preço Custo 3")]
        public Nullable<decimal> Custo3 { get; set; }
        [Display(Name = "Fornecedor 3")]
        public string Fornecedor3 { get; set; }
     
        [Display(Name = "Preço Custo 4")]
        public Nullable<decimal> Custo4 { get; set; }
        [Display(Name = "Fornecedor 4")]
        public string Fornecedor4 { get; set; }
        
         [Display(Name = "Preço Custo 5")]
        public Nullable<decimal> Custo5 { get; set; }

         [Display(Name = "Fornecedor 5")]
         public string Fornecedor5 { get; set; }


        [Display(Name = "Custo 1")]
         public string sCusto1 { get; set; }

        [Display(Name = "Custo 2")]
        public string sCusto2 { get; set; }
        
        [Display(Name = "Custo 3")]

        public string sCusto3 { get; set; }

        [Display(Name = "Custo 4")]
        public string sCusto4 { get; set; }

        [Display(Name = "Custo 5")]
        public string sCusto5 { get; set; }



      
    }
}