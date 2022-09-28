using AFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Repositories
{
    public class AdminRepository
    {
        public afmsDataBaseContext _dbContext;

        //INIT
        public AdminRepository(afmsDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Query to get admin by email
        public IEnumerable<AdminTable> GetAdminsbyId(int adminId, string adminPassword)
        {
            return _dbContext.AdminTable.Where(i => i.AdminId == adminId && i.Password==adminPassword);
        }

    }
}
