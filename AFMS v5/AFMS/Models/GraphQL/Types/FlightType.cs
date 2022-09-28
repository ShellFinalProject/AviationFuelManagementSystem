using AFMS.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class FlightType : ObjectGraphType<FlightDetails>
    {
        public FlightType(FlightRepository flightRepository)
        {
            Field(x => x.FlightNo);
            Field(x => x.Origin);
            Field(x => x.Destination);
            Field(x => x.AircraftType);
            Field(x => x.ClientId);

            Field<ListGraphType<FlightType>>(
              "flights",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "flightNo" }),
              resolve: context => flightRepository.GetFlightsbyNo(context.Source.FlightNo)
           );

            Field<ListGraphType<FlightType>>(
              "flightsbyClientId",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "flightNo" }),
              resolve: context => flightRepository.GetFlightsbyClientId(context.Source.ClientId)
           );
        }
    }
}
