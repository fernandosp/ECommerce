using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Data;
using ECommerce.Domain;
using System.Linq;

namespace ECommerce.Business
{
    public class OrderItensBusiness : IOrderItensBusiness
    {
        private readonly IOrderItensRepository _IOrderItensRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;


        public OrderItensBusiness(IOrderItensRepository iOrderItensRepository, 
            IOrderRepository orderRepository, 
            IProductRepository productRepository)
        {
            _IOrderItensRepository = iOrderItensRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public OrderItens Add(OrderItens orderItens, int id_order)
        {
            Order order = null;
            Product product = null;

            OrderItens orderItensDB;

            order = _orderRepository.GetOne(id_order);

            if(order == null) {
                throw new Exception("Pedido Inexistente");
            }

            if (order.OrderStatus != OrderStatus.ABERTA) {
                throw new Exception("Pedido Deve Estar Aberto");
            }

            product = _productRepository.GetById(orderItens.Products.Id);

            if(product == null) {
                throw new Exception("Produto Não Existe");
            }

            if(product.Quantity < orderItens.Quantity) {
                throw new Exception("Quantidade do Produto Indisponível");
            }

            orderItensDB = _IOrderItensRepository.GetByOrderIdAnProductId(id_order, id_order);

            if(orderItensDB == null)
            {
                _IOrderItensRepository.Add(orderItens, id_order);
            }
            else
            {
                _IOrderItensRepository.AlterQuantity(orderItens.Quantity + orderItensDB.Quantity, orderItensDB.Id); ;
            }

            decimal totalvalue = orderItens.Quantity * product.Value + order.Total;

            _orderRepository.AlterTotal(totalvalue, id_order);

            int quantity = product.Quantity - orderItens.Quantity;

            _productRepository.AlterQuantityAvailable(quantity, orderItens.Products.Id);

            return orderItens;
        }

        public List<OrderItens> GetAll()
        {
            return _IOrderItensRepository.GetAll();
        }

        
    }
}
