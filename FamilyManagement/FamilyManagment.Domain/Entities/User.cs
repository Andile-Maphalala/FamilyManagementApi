using Microsoft.AspNetCore.Identity;


namespace FamilyManagement.Domain.Entities
{
    public class User : IdentityUser
    {
        public byte[] ProfilePicture {  get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserAvailability> UserAvailability { get; set; }
        public virtual ICollection<Schedule> DropoffSchedules { get; set; }
        public virtual ICollection<Schedule> PickupSchedules { get; set; }
    }
}
