﻿using PieShopHRM.Contracts.Repositories;
using PieShopHRM.Data;
using PieShopHRM.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace PieShopHRM.Repositories
{
    public class TimeRegistrationRepository : ITimeRegistrationRepository, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public TimeRegistrationRepository(IDbContextFactory<AppDbContext> DbFactory)
        {
            _appDbContext = DbFactory.CreateDbContext();
        }

        public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
        {
            return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).OrderBy(t => t.StartTime).ToListAsync();
        }

        public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
        {
            return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).OrderBy(t => t.StartTime).Skip(start).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId)
        {
            return await _appDbContext.TimeRegistrations.Where(t => t.EmployeeId == employeeId).CountAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
