using AFMS.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class FuelType : ObjectGraphType<FuelList>
    {
        public FuelType(FuelRepository fuelRepository)
        {
            Field(x => x.FuelId);
            Field(x => x.FuelName);
            Field(x => x.FuelCurrentPrice);
            Field(x => x.FuelPrevCost);
            Field(x => x.Place);

            Field<ListGraphType<FuelType>>(
              "fuels",
              resolve: context => fuelRepository.GetFuels()
              );

            Field<ListGraphType<FuelType>>(
              "fuelsbyId",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "fuelId" }),
              resolve: context => fuelRepository.GetFuelbyId(context.Source.FuelId)
              );
        }
    }
}
