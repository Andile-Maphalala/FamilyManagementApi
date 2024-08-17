using FamilyManagment.Domain.Common;

namespace FamilyManagement.Domain.Entities
{
    public class Schedule : BaseDomainEntity
    {
        public DateTime PickupTime { get; set; }
        public string PickupPersonId { get; set; }
        public string DropoffPersonId { get; set; }
        public string PickupLocation { get; set; }
        public string Notes { get; set; }
        public int ExtraActivityId { get; set; }

        public virtual User PickupPerson { get; set; }
        public virtual User DropoffPerson { get; set; }
        public virtual ExtraActivity ExtraActivity { get; set; }
    }
}
