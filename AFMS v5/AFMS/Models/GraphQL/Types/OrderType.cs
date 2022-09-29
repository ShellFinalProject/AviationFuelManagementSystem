using AFMS.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class OrderType : ObjectGraphType<OrderDetails>
    {
        public OrderType(OrderRepository orderRepository)
        {
            Field(x => x.OrderId);
            Field(x => x.ClientId);
            Field(x => x.FlightNo);
            Field(x => x.FuelAmt);
            Field(x => x.FuelId);
            Field(x => x.OrderPlaceDate);
            Field(x => x.Status);


            Field<ListGraphType<OrderType>>(
              "orders",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "orderId" }),
              resolve: context => orderRepository.GetOrderbyId(context.Source.OrderId)
           );
        }
    }
}
