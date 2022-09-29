using AFMS.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Models.GraphQL.Types
{
    public class AdminType : ObjectGraphType<AdminTable>
    {
        public AdminType(AdminRepository repository) { 
        Field(x => x.AdminId);
        Field(x => x.AdminName);
        Field(x => x.Password);
        Field(x => x.Role);
        Field(x => x.Remarks);

        Field<ListGraphType<AdminType>>(
              "admins",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }, new QueryArgument<StringGraphType> { Name = "password" }),
              resolve: context => repository.GetAdminsbyId(context.Source.AdminId, context.Source.Password)
           );

        }}
}
