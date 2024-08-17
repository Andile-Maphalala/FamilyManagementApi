using FamilyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagment.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string UserCreatedId { get; set; }
        public string UserModifiedId { get; set; }

        public virtual User UserCreated { get; set; }
        public virtual User UserModified { get; set; }
    }
}
