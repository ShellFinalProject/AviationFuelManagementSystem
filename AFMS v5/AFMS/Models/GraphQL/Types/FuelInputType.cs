using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class FuelInputType : InputObjectGraphType
    {
        public FuelInputType()
        {
            Field<NonNullGraphType<IntGraphType>>("clientid");
            Field<NonNullGraphType<StringGraphType>>("fuelname");
            Field<NonNullGraphType<FloatGraphType>>("fuelcurrentcost");
            Field<NonNullGraphType<StringGraphType>>("place");
        }
    }
}
