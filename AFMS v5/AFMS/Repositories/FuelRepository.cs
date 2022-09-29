using AFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFMS.Repositories
{
    public class FuelRepository
    {
        public afmsDataBaseContext _dbContext;

        //INIT
        public FuelRepository(afmsDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Query to get client by email
        public IEnumerable<FuelList> GetFuels()
        {
            return _dbContext.FuelList;
        }

        public IEnumerable<FuelList> GetFuelbyId(int fuelId)
        {
            return _dbContext.FuelList.Where(i => i.FuelId== fuelId);
        }
        //Query to add new client
        public FuelList AddFuel(FuelList fuel)
        {
            _dbContext.FuelList.Add(fuel);
            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                return null;
            }
            return fuel;
        }

        public FuelList UpdateFuel(int fuelId, float price)
        {
            FuelList existingFuel = _dbContext.FuelList.Find(fuelId);

            if (existingFuel != null)
            {
                var dt = DateTime.Now;
                existingFuel.FuelPrevCost = existingFuel.FuelCurrentPrice;
                existingFuel.FuelCurrentPrice = price;
                existingFuel.LastUpdated = dt.ToString("G");
            }

            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                return null;
            }

            return existingFuel;
        }
    }
}
