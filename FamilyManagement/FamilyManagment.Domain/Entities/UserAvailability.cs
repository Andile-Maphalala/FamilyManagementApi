using FamilyManagment.Domain.Common;
using FamilyManagment.Domain.Enums;

namespace FamilyManagement.Domain.Entities
{
    public class UserAvailability : BaseDomainEntity
    {
        public DateTime Date { get; set; }
        public TimeSlotEnum TimeSlot { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
