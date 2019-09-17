using BusinessLayer.Contracts;
using DataAccess.Contracts;
using DomainModels.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class BicycleServices : IBicycleServices
    {
        private readonly IBicycleRepository _bicycleRepository;

        public BicycleServices(IBicycleRepository bicycleRepository)
        {
           _bicycleRepository = bicycleRepository;
        }

        public void AddBicycle(Bicycle bicycle)
        {
            
             
        }

        public int EditBicycle(Bicycle bicycle)
        {
            throw new NotImplementedException();
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

        public int RemoveBicycle(int bicycleId)
        {
            throw new NotImplementedException();
        }

        int IBicycleServices.AddBicycle(Bicycle bicycle)
        {
            throw new NotImplementedException();
        }
    }
}
