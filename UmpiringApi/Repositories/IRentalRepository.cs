using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmpiringApi.Models;

namespace UmpiringApi.Repositories
{
   public interface IRentalRepository
    {
        Task<List<Assignment>> GetAssignments();
    }
}
