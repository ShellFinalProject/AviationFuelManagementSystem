using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class OrderInputType : InputObjectGraphType
    {
        public OrderInputType()
        {
            Field<NonNullGraphType<IntGraphType>>("clientid");
            Field<NonNullGraphType<StringGraphType>>("flightno");
            Field<NonNullGraphType<FloatGraphType>>("fuelamt");
            Field<NonNullGraphType<IntGraphType>>("fuelid");
            Field<NonNullGraphType<StringGraphType>>("status");
        }
    }
}
