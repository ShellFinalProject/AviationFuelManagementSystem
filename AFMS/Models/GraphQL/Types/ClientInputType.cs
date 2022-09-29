using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class ClientInputType : InputObjectGraphType
    {
        public ClientInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("clientname");
            Field<NonNullGraphType<StringGraphType>>("gstin");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");
        }
    }
}
