using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API_Rest.Domain
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column(TypeName = "nvarchar(95)")]        
        public string pro_nome { get; set; }

        [Display(Name = "Descrição")]
        [Column(TypeName = "nvarchar(200)")]        
        public string pro_descricao { get; set; }

        [Display(Name = "Valor pago")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal pro_valorpago { get; set; }

        [Display(Name = "Valor de venda")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal pro_valorvenda { get; set; }

        [Display(Name = "Quantidade")]
        public int pro_qtde { get; set; }

    }
}
