using System;

namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

      public override bool Equals(Object obj)
      {
         //Check for null and compare run-time types.
         if ((obj == null) || !this.GetType().Equals(obj.GetType()))
         {
            return false;
         }
         else
         {
            Product product = (Product)obj;
            return (this.Name == product.Name) && (this.Price == product.Price);
         }
      }
   }
}
