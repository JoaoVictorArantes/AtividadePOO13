using AtividadePOO13.Entities;
using AtividadePOO13.Entities.Enum;
using System.Net.NetworkInformation;

namespace AtividadePOO13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre  com os dados do cliente: ");
            Console.Write("Nome: ");
            String Nome = Console.ReadLine();

            Console.Write("E-mail: ");
            String Email = Console.ReadLine();

            Console.Write("Data de nascimento (DD/MM/YYYY): ");
            DateTime DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Entre com os dados do pedido:");
            Console.Write("Status (Pending Payment/Processing/Shipped/Delivered): ");

            String StatusAux = "";
            bool StatusCorreto = true;

            while (StatusCorreto)
            {
                StatusAux = Console.ReadLine();
                StatusAux.ToLower();

                if (StatusAux == "pending payment" || StatusAux == "Pending Payment")
                {
                    StatusAux = "Pending_Payment";
                    StatusCorreto = false;
                }
                else if (StatusAux == "processing" || StatusAux == "Processing")
                {
                    StatusAux = "Processing";
                    StatusCorreto = false;
                }
                else if (StatusAux == "shipped" || StatusAux == "Shipped")
                {
                    StatusAux = "Shipped";
                    StatusCorreto = false;
                }
                else if (StatusAux == "delivered" || StatusAux == "Delivered")
                {
                    StatusAux = "Delivered";
                    StatusCorreto = false;
                }
                else
                {                    
                    Console.WriteLine($"VocÊ digitou: {StatusAux}\n \rDigite uma opção válida.");
                    Console.Write("Status (Pending Payment/Processing/Shipped/Delivered): ");
                    StatusCorreto = true;
                }
            }
            
            OrderStatus Status = Enum.Parse<OrderStatus>(StatusAux);
           
            Client client = new Client(Nome, Email, DataNascimento);
            Order order = new Order(DateTime.Now, Status, client);

            Console.Write("Quantos items para este pedido: ");
            int aux = int.Parse(Console.ReadLine());

            for (int  i = 0;  i < aux;  i++)
            {
                Console.WriteLine($"Digite os dados do item #{i+1}:");
                Console.Write("Nome do produto:");
                String NomeProduto = Console.ReadLine();

                Console.Write("Preço do produto: ");
                double PrecoProduto = double.Parse(Console.ReadLine());

                Product product = new Product(NomeProduto, PrecoProduto);

                Console.Write("Quantidade: ");
                int QuantidadeProduto = int.Parse(Console.ReadLine());

                OrderItem OrderItem = new OrderItem(QuantidadeProduto, PrecoProduto, product);

                order.AddItem(OrderItem);
            }
            Console.WriteLine();
            Console.WriteLine("Resumo do pedido:");
            Console.WriteLine(order);

            Console.ReadKey();
        }
    }
}
