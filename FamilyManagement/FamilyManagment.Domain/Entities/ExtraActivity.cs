using FamilyManagment.Domain.Common;

namespace FamilyManagement.Domain.Entities
{
    public class ExtraActivity : BaseDomainEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
