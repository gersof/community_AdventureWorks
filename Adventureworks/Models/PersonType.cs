using GraphQL.Types;
using Infrastructure;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventureworks.Models
{
    public class PersonType:ObjectGraphType<Person>
    {
        public PersonType(IPersonRepository personRepository)
        {
            Field(x => x.BusinessEntityId);
            Field(x => x.PersonType);
            Field(x => x.NameStyle);
            Field(x => x.Title);
            Field(x => x.FirstName);
            Field(x => x.MiddleName);
            Field(x => x.LastName);
            Field(x => x.Suffix);
            Field(x => x.EmailPromotion);
            Field(x => x.AdditionalContactInfo);
            Field(x => x.Demographics);
        }
    }
}
