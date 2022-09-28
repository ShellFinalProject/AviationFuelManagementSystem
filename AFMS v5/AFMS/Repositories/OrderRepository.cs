using AFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Repositories
{
    public class OrderRepository
    {
        public afmsDataBaseContext _dbContext;

        //INIT
        public OrderRepository(afmsDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Query to get flight by number
        public IEnumerable<OrderDetails> GetOrderbyId(int orderId)
        {
            return _dbContext.OrderDetails.Where(i => i.OrderId == orderId);
        }
        //Query to add new flight
        public OrderDetails AddOrder(OrderDetails order)
        {
            _dbContext.OrderDetails.Add(order);
            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                return null;
            }
            return order;
        }

        public OrderDetails UpdateOrder(int orderId, string status)
        {
            OrderDetails existingOrder = _dbContext.OrderDetails.Find(orderId);

            if (existingOrder != null)
            {
                existingOrder.Status = status;
            }

            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                return null;
            }

            return existingOrder;
        }
    }
}
