using BusinessLayer.Contracts;
using DataAccess.Contracts;
using DomainModels.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class BicycleServices : IBiclycleServices
    {
        private readonly IBicycleRepository _bicycleRepository;

        public BicycleServices(IBicycleRepository bicycleRepository)
        {
           _bicycleRepository = bicycleRepository;
        }

        public IEnumerable<Bicycle> GetAllBicycles()
        {

            return _bicycleRepository.GetAll();
        }


        //TODO: Add exception middleware to catch the exepton;
        public Bicycle GetBicycle(int bicycleId)
        {
            Bicycle bicycle = _bicycleRepository.GetById(bicycleId);
            if (bicycle == null)
            {
                throw new Exception($"There is no user with {bicycleId} id");
            }
            return bicycle;
        }
    }
}
