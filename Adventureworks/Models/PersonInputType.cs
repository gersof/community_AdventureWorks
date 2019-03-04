using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventureworks.Models
{
    public class PersonInputType: InputObjectGraphType
    {
        public PersonInputType()
        {
            Name = "Person";
            Field<StringGraphType>("BusinessEntityId");
            Field<StringGraphType>("PersonType");
            Field<StringGraphType>("NameStyle");
            Field<StringGraphType>("Title");
            Field<StringGraphType>("FirstName");
            Field<StringGraphType>("MiddleName");
            Field<StringGraphType>("LastName");
            Field<StringGraphType>("Suffix");
            Field<StringGraphType>("EmailPromotion");
            Field<StringGraphType>("AdditionalContactInfo");
            Field<StringGraphType>("Demographics");
            Field<StringGraphType>("Rowguid");
            Field<StringGraphType>("ModifiedDate");
        }
    }
}
