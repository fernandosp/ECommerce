using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public PedidoItens PedidoItens { get; set; }
        public TipoPagamento tipoPagamento { get; set; }
        public bool PedidoEstaAprovado { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
