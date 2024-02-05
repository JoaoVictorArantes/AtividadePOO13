using AtividadePOO13.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem Item)
        {
            Items.Add(Item);
        }
        public void RemoveItem(OrderItem Item)
        {
            Items.Remove(Item);
        }
        public double Total()
        {
            double Soma = 0;

            foreach (OrderItem item in Items)
            {
                Soma += item.SubTotal();
            }
            return Soma;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Momento do pedido: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Status do pedido: " + Status);
            sb.AppendLine("Cliente: " + Client);
            sb.AppendLine("Itens no pedido:");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Valor total: $" + Total().ToString("F2"));
            return sb.ToString();
        }
    }
}
