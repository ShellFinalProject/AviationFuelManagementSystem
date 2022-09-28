using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class FlightInputType : InputObjectGraphType
    {
        public FlightInputType()
        {
            Field<NonNullGraphType<IntGraphType>>("clientid");
            Field<NonNullGraphType<StringGraphType>>("flightno");
            Field<NonNullGraphType<StringGraphType>>("origin");
            Field<NonNullGraphType<StringGraphType>>("destination");
            Field<NonNullGraphType<StringGraphType>>("flighttype");
        }
    }
}
