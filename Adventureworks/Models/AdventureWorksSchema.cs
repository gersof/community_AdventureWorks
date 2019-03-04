using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventureworks.Models
{
    public class AdventureWorksSchema:Schema
    {
        public AdventureWorksSchema(IDependencyResolver resolver):base(resolver) {
            Query = resolver.Resolve<AdventureWorksQuery>();
            //Mutation = resolver.Resolve<AdventureWorksMutation>();

        }
    }
}
