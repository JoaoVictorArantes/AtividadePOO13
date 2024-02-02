using AtividadePOO13.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadePOO13.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order() { }

        public Order(DateTime moment, OrderStatus status)
        {
            Moment = moment;
            Status = status;
        }
        public void AddItem(OrderItem Item)
        {
            Items.Add(Item);
        }
        public void RemoveItem(OrderItem Item)
        {
            Items.Remove(Item);
        }
        public double Total(OrderItem Item)
        {
            double Soma = 0;

            foreach (OrderItem item in Items)
            {
                Soma += item.SubTotal();
            }
            return Soma;
        }
    }
}
