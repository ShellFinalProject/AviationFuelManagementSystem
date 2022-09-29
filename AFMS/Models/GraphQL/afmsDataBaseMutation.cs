using AFMS.Models.GraphQL.Types;
using AFMS.Repositories;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL
{
    public class afmsDataBaseMutation : ObjectGraphType
    {
        public afmsDataBaseMutation(ClientRepository clientRepo, OrderRepository orderRepo, FuelRepository fuelRepo, FlightRepository flightRepo)
        {
            Field<ClientType>(
                "createClient",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ClientInputType>> { Name = "client" }),
                resolve: context =>
                {
                    var client = context.GetArgument<ClientTable>("client");
                    return clientRepo.AddClient(client);
                });

            Field<OrderType>(
                "createOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OrderInputType>> { Name = "order" }),
                resolve: context =>
                {
                    var order = context.GetArgument<OrderDetails>("order");
                    order.Status = "Pending";
                    return orderRepo.AddOrder(order);
                });

            Field<OrderType>(
                "updateStatus",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "orderId" }, new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "status" }),
                resolve: context =>
                {
                    var orderId = context.GetArgument<int>("id");
                    var status = context.GetArgument<string>("status");

                    return orderRepo.UpdateOrder(orderId, status);

                });

            Field<FuelType>(
                "createFuel",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<FuelInputType>> { Name = "fuel" }),
                resolve: context =>
                {
                    var fuel = context.GetArgument<FuelList>("fuel");
                    return fuelRepo.AddFuel(fuel);
                });

            Field<FuelType>(
                "updateFuel",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "fuelId" }, new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "price" }),
                resolve: context =>
                {
                    var fuelId = context.GetArgument<int>("fuelId");
                    var price = context.GetArgument<float>("price");

                    return fuelRepo.UpdateFuel(fuelId, price);

                });

            Field<FlightType>(
                "createFlight",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<FlightInputType>> { Name = "flight" }),
                resolve: context =>
                {
                    var flight = context.GetArgument<FlightDetails>("flight");
                    return flightRepo.AddFlight(flight);
                });


        }

        
    }
}
