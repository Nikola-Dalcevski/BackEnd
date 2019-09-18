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
            if (BikeExistsbyName(bicycle.FullName))
            {
                throw new ArgumentException($"Bike with fullname: {bicycle.FullName} alredy exists");
            }
            _bicycleRepository.Insert(bicycle);
        }

        public int EditBicycle(Bicycle bicycle)
        {
            BikeExistsById(bicycle.Id);
            _bicycleRepository.Update(bicycle);
            return bicycle.Id;
        }

        public IEnumerable<Bicycle> GetAllBicycles()
        {
            return _bicycleRepository.GetAll();
        }


        //TODO: Add exception middleware to catch the exepton;
        public Bicycle GetBicycle(int bicycleId)
        {
           return BikeExistsById(bicycleId);
            
        }

        public int RemoveBicycle(int bicycleId)
        {
            BikeExistsById(bicycleId);
            _bicycleRepository.Delete(bicycleId);
            return bicycleId;
        }


        private bool BikeExistsbyName(string fullname)
        {
            var bike = _bicycleRepository.GetByName(fullname);
            return bike != null;
        }

        private Bicycle BikeExistsById(int id)
        {
            var bike = _bicycleRepository.GetById(id);
            if (bike == null)
            {
                throw new ArgumentException($"Bike with id {id} does not exists");
            }
            return bike;
        }


    }
}
