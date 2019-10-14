using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UmpiringApi.Models;

namespace UmpiringApi.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly SQL2008_739130_dallascrickContext _context;

        public RentalRepository(SQL2008_739130_dallascrickContext context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAssignments()
        {
            var assignments =  _context.Assignments
                .FromSql("EXECUTE dbo.GetAssignments")
                .ToList();
            return assignments;
        }
    }

}
