using FluentNHibernate.Mapping;
using LoginApp.Models;

namespace LoginApp.Persistence.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Username).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
        }
    }
}
