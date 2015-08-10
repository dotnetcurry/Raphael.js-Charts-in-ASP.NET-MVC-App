using System.Collections.Generic;
using System.Linq;

namespace Rephael_Chart.Models
{
    //The CustomerOrders class for 
    //reading the Total orders by Customers
    public class CustomerOrders
    {
        public string ContactName { get; set; }
        public int TotalOrders { get; set; }
    }

    //The DataAccess class for reading Orders by Customers
    public class DataAccess
    {

        NorthwindEntities ctx;
        public DataAccess()
        {
            ctx = new NorthwindEntities(); 
        }
        //Function for Retrieving Customers and Orders
        public List<CustomerOrders> GetInformation()
        {

            List<CustomerOrders> custorders = new List<CustomerOrders>();
            custorders = (from c in ctx.Customers.ToList()
                       from o in ctx.Orders.ToList()
                       where c.CustomerID == o.CustomerID
                       group o by o.Customer.ContactName into grpContact
                       select new CustomerOrders()
                       {
                           ContactName = grpContact.Key,
                           TotalOrders = grpContact.Count(t => t.OrderID == t.OrderID)
                       }).ToList();

            
            return custorders;
        }
    }

}