using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL
{
    public class afmsDataBaseSchema : Schema
    {
        public afmsDataBaseSchema(IServiceProvider resolver) : base(resolver)
        {
            Query = (IObjectGraphType)resolver.GetService(typeof(afmsDataBaseQuery));
            Mutation = (IObjectGraphType)resolver.GetService(typeof(afmsDataBaseMutation));
        }
    }
}
