using FamilyManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FamilyManagement.Services.Repositories
{
    public interface IFamilyManagementRepository : IGenericRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<UserAvailability> UserAvailability { get; }
        IQueryable<Schedule> Schedules { get; }
        IQueryable<ExtraActivity> ExtraActivities { get; }
    }
}
