using FamilyManagement.Domain.Entities;
using FamilyManagement.Persistence.Data;
using FamilyManagement.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Persistence.Repositories
{
    public class FamilyManagementRepository : GenericRepository, IFamilyManagementRepository
    {
        public FamilyManagementRepository(FamilyManagementDbContext context) : base(context)
        {

        }
        public IQueryable<User> Users => Set<User>();
        public IQueryable<UserAvailability> UserAvailability => Set<UserAvailability>();
        public IQueryable<Schedule> Schedules => Set<Schedule>();
        public IQueryable<ExtraActivity> ExtraActivities => Set<ExtraActivity>();
    }
}
