using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Rephael_Chart.Models;

namespace Rephael_Chart.Controllers
{
    public class TestController : Controller
    {
        NorthwindEntities ctx;

        public TestController()
        {
            ctx = new NorthwindEntities(); 
        }

        // GET: Test
        public ActionResult Index()
        {

            var Res = (from c in ctx.Customers.ToList()
                      from o in ctx.Orders.ToList()
                      where c.CustomerID==o.CustomerID
                      group o by o.Customer.ContactName into grpContact
                      select new CustomerOrders(){
                         ContactName = grpContact.Key,
                          TotalOrders = grpContact.Count(t=>t.OrderID==t.OrderID)
                      }).ToList();
            return View();
        }
    }
}