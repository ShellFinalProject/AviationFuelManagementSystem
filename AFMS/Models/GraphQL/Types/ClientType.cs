using AFMS.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class ClientType : ObjectGraphType<ClientTable>
    {
        public ClientType(ClientRepository repository)
        {
            Field(x => x.ClientId);
            Field(x => x.ClientName);
            Field(x => x.Gstin);
            Field(x => x.Email);
            Field(x => x.Password);

            Field<ListGraphType<ClientType>>(
              "clients",
              arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "email" }, new QueryArgument<StringGraphType> { Name = "password" }),
              resolve: context => repository.GetClientsbyEmail(context.Source.Email,context.Source.Password)
           );

            
        }
    }
}
