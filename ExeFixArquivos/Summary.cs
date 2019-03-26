using System;


namespace ExeFixArquivos
{
    public class Summary
    {
        public string Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Summary(string product, double price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public double Total()
        {
            return Price*Quantity;
        }
    }
}
