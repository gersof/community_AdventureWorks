using GraphQL.Types;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventureworks.Models
{
    public class AdventureWorksQuery : ObjectGraphType
    {
        public AdventureWorksQuery(IPersonRepository personRepository)
        {
            Field<ListGraphType<PersonType>>(
                "persons",
                resolve: context => personRepository.GetAllPersons()
                );
            Field<PersonType>(
                "person",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => personRepository.GetByPersonId(context.GetArgument<int>("id"))
                );
        }
    }
}
