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
    public class afmsDataBaseQuery : ObjectGraphType
    {
        public afmsDataBaseQuery(ClientRepository clientRepo, AdminRepository adminRepo, OrderRepository orderRepo, FlightRepository flightRepo, FuelRepository fuelRepo)
        {


            Field<ListGraphType<ClientType>>(
              "getClientsbyEmail",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "email" }, new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }),
              resolve: context =>
              {
                  var email = context.GetArgument<string>("email");
                  var password = context.GetArgument<string>("password");
                  return clientRepo.GetClientsbyEmail(email, password);
              });


            Field<ListGraphType<AdminType>>(
              "getAdminsbyId",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }, new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }),
              resolve: context =>
              {
                  var id = context.GetArgument<int>("id");
                  var password = context.GetArgument<string>("password");
                  return adminRepo.GetAdminsbyId(id, password);
              });

            Field<ListGraphType<OrderType>>(
            "getOrderbyId",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "orderId" }),
            resolve: context =>
            {
                var id = context.GetArgument<int>("id");
                return orderRepo.GetOrderbyId(id);
            });

            Field<ListGraphType<FlightType>>(
             "flightsbyNo",
             arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "flightNo" }),
             resolve: context =>
             {
                 var flightNo = context.GetArgument<string>("flightNo");
                 return flightRepo.GetFlightsbyNo(flightNo);
             }
          );

            Field<ListGraphType<FlightType>>(
              "flightsbyClientId",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "clientId" }),
              resolve: context =>
              {
                  var clientId = context.GetArgument<int>("clientId");
                  return flightRepo.GetFlightsbyClientId(clientId);
              }
           );

            Field<ListGraphType<FuelType>>(
              "fuels",
              resolve: context =>
              {
                  return fuelRepo.GetFuels();
              }
              );

            Field<ListGraphType<FuelType>>(
              "fuelsbyId",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "fuelId" }),
              resolve: context =>
              {
                  var fuelId = context.GetArgument<int>("fuelId");
                  return fuelRepo.GetFuelbyId(fuelId);
              }
              );

        }
    }
}
