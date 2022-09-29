using AFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Repositories
{
    public class FlightRepository
    {
        public afmsDataBaseContext _dbContext;

        //INIT
        public FlightRepository(afmsDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Query to get flight by number
        public IEnumerable<FlightDetails> GetFlightsbyNo(string FlightNo)
        {
            return _dbContext.FlightDetails.Where(i => i.FlightNo == FlightNo);
        }

        public IEnumerable<FlightDetails> GetFlightsbyClientId(int clientId)
        {
            return _dbContext.FlightDetails.Where(i => i.ClientId == clientId);
        }
        //Query to add new flight
        public FlightDetails AddFlight(FlightDetails flights)
        {
            _dbContext.FlightDetails.Add(flights);
            try
            {
                _dbContext.SaveChanges();
            }
                
            catch
            {
                return null;
            }
            return flights;
        }
    }
}
