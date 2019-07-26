using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public class PedidoItens 
    {
        public int Id { get; set; }
        List<Produto> Produtos { get; set; }
        

    }

}
