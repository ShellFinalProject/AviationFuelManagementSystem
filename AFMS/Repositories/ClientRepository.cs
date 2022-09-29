using AFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Repositories
{
    public class ClientRepository
    {
        public afmsDataBaseContext _dbContext;

        //INIT
        public ClientRepository(afmsDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Query to get client by email
        public IEnumerable<ClientTable> GetClientsbyEmail(string email, string password)
        {
            return _dbContext.ClientTable.Where(i => i.Email == email && i.Password == password) ;
        }
        //Query to add new client
        public ClientTable AddClient(ClientTable client)
        {
            _dbContext.ClientTable.Add(client);
            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                return null;
            }
            return client;
        }


    }
}
