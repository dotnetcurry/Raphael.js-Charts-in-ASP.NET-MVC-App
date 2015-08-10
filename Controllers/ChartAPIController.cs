using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Rephael_Chart.Models;

namespace Rephael_Chart.Controllers
{
    public class ChartAPIController : ApiController
    {
        DataAccess ds;
        public ChartAPIController()
        {
            ds = new DataAccess(); 
        }
 
         [Queryable]
        public List<CustomerOrders> Get()
        {
            return ds.GetInformation();
        }
    }
}
