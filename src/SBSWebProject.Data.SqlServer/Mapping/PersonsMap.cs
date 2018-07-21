using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class PersonsMap : VersionedClassMap<Persons> {
        
        public PersonsMap() {
			Table("Persons");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.PersonType).Column("PERSON_TYPE");
			HasMany(x => x.InsuranceOrdersS).KeyColumn("PERSONS_ID");
        }
    }
}
