using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Task1.DoNotChange;

namespace Task1
{
   public static class LinqTask
   {
      public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
      {
         return customers.Where(c => c.Orders.Sum(o => o.Total) > limit).ToList();

      }


      public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
          IEnumerable<Customer> customers,
          IEnumerable<Supplier> suppliers
      )
      {
         if (customers == null || suppliers == null)
            throw new ArgumentNullException("Customer or Supplier list is empty!");

         return customers.Select(c => (
                                          c,
                                          suppliers.Where(s => s.City == c.City && s.Country == c.Country)
                                       ));
      }

      public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
          IEnumerable<Customer> customers,
          IEnumerable<Supplier> suppliers
      )
      {
         if (customers == null || suppliers == null)
            throw new ArgumentNullException("Customer or Supplier list is empty!");

         var query = from c in customers
                     join s in suppliers
                     on new { c.City, c.Country } equals new { s.City, s.Country } into supplierList
                     select (c, supplierList);


         return query;
      }

      public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
      {
         return customers.Where(c => c.Orders.Any(o => o.Total > limit)).ToList();
      }

      public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
          IEnumerable<Customer> customers
      )
      {

         return customers
                    .Where(customer => customer.Orders.Length > 0)
                    .Select(c => (
                                    c,
                                    c.Orders.Min(o => o.OrderDate)
                                  ));
      }

      public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
          IEnumerable<Customer> customers
      )
      {
         return customers
           .Where(customer => customer.Orders.Length > 0)
           .Select(c => (
                           customer: c,
                           dateOfEntry: c.Orders.Min(o => o.OrderDate)
                         ))
           .OrderBy(x => x.dateOfEntry.Year)
           .ThenBy(x => x.dateOfEntry.Month)
           .ThenByDescending(x => x.customer.Orders.Sum(o => o.Total))
           .ThenBy(x => x.customer.CompanyName);
      }

      public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
      {
         return customers
                  .Where(c => c.Region == null
                           || !(c.Phone.Contains("(") && c.Phone.Contains(")"))
                           || !c.PostalCode.All(char.IsDigit)
                           );
      }

      public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
      {
         /* example of Linq7result

          category - Beverages
            UnitsInStock - 39
               price - 18.0000
               price - 19.0000
            UnitsInStock - 17
               price - 18.0000
               price - 19.0000
          */

         var groupByCategory = products.GroupBy(p => p.Category);
         var groupByCategoryThenByUnitsInStock = groupByCategory.Select(groupByCategory => new Linq7CategoryGroup
         {
            Category = groupByCategory.Key,
            UnitsInStockGroup = groupByCategory.GroupBy(x => x.UnitsInStock).Select(groupByUnitsInStock => new Linq7UnitsInStockGroup
            {
               UnitsInStock = groupByUnitsInStock.Key,
               Prices = groupByUnitsInStock.Select(x => x.UnitPrice).OrderBy(price => price)
            })
         });



         return groupByCategoryThenByUnitsInStock;

      }

      public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
          IEnumerable<Product> products,
          decimal cheap,
          decimal middle,
          decimal expensive
      )
      {
         var cheapProducts = products.Where(p => p.UnitPrice <= cheap);
         var middleProducts = products.Where(p => p.UnitPrice > cheap && p.UnitPrice <= middle);
         var expensiveProducts = products.Where(p => p.UnitPrice > middle && p.UnitPrice <= expensive);

         return new List<(decimal, IEnumerable<Product>)> { (cheap, cheapProducts), (middle, middleProducts), (expensive, expensiveProducts) };
      }

      public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
          IEnumerable<Customer> customers
      )
      {
         return customers
                    .GroupBy(c => c.City)
                    .Select(g => (
                                    g.Key,
                                    (int)Math.Round(g.Average(c => c.Orders.Sum(o => o.Total))),
                                    (int)Math.Round(g.Average(c => c.Orders.Length))
                                 ));
      }

      public static string Linq10(IEnumerable<Supplier> suppliers)
      {
         if (suppliers == null)
            throw new ArgumentNullException("Supplier list is empty!");

         return suppliers
                  .GroupBy(s => s.Country)
                  .OrderBy(g => g.Key.Length)
                  .ThenBy(g => g.Key)
                  .Aggregate(new StringBuilder(), (result, entry) => result.Append(entry.Key))
                  .ToString();
      }
   }
}