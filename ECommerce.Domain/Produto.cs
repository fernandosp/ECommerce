using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public class Produto
    {
        public TipoProduto TipoProduto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}

