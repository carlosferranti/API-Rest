using System;
using System.Collections.Generic;
using System.Text;

namespace API_Rest.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string pro_nome { get; set; }
        public string pro_descricao { get; set; }
        public double pro_valorpago { get; set; }
        public float pro_valorvenda { get; set; }
        public int pro_qtde { get; set; }

    }
}
