using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace API_Rest.Domain
{
    public class Produto
    {
        private DateTime DefaultValue = DateTime.Now;

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

        [Display(Name = "Data")]
        [Column("Criado", TypeName = "Data/Hora")]
        public DateTime? pro_data_criacao { get; set; } = DateTime.Now;

        [Display(Name = "Data")]
        [Column("Atualizado", TypeName = "Data/Hora")]
        public DateTime? pro_data_atualizacao { get; set; } = DateTime.Parse(DateTime.Now.ToString(), new CultureInfo("pt-BR"));//DateTime.Now;

        //{
        //    get
        //    {
        //        DateTime dt = DateTime.Now;
        //        String.Format("{0:dd/MM/yyyy}", dt);

        //        return this.dataCriacao.HasValue
        //           ? this.dataCriacao.Value                  
        //           : dt;  //: DateTime.Now.ToString("dd/MM/yyyy");
        //    }

        //    set { this.dataCriacao = value; }
        //}
               

    }
}
