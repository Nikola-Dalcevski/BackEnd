using AutoMapper;
using BusinessLayer.Contracts;
using DataAccess.Contracts;
using DomainModels.Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class BicycleServices : IBicycleServices
    {
        private readonly IBicycleRepository _bicycleRepository;
        private readonly IMapper _mapper;

        public BicycleServices(IBicycleRepository bicycleRepository, IMapper mapper)
        {
           _bicycleRepository = bicycleRepository;
            _mapper = mapper;
        }

        public void AddBicycle(Bicycle bicycle)
        {
            if (BikeExistsbyName(bicycle.Model))
            {
                throw new ArgumentException($"Bike with fullname: {bicycle.Model} alredy exists");
            }
            _bicycleRepository.Insert(bicycle);
        }

        public int EditBicycle(Bicycle bicycle)
        {
            BikeExistsById(bicycle.Id);
            _bicycleRepository.Update(bicycle);
            return bicycle.Id;
        }

        public IEnumerable<BicycleViewModel> GetAllBicycles()
        {
            var dtoBicycles = _bicycleRepository.GetAll();
            if (dtoBicycles.Count == 0)
            {
               throw new ArgumentException("No Bicycles in dataBase");
            }
            return _mapper.Map<List<BicycleViewModel>>(dtoBicycles);
        }


        //TODO: Add exception middleware to catch the exepton;
        public BicycleViewModel GetBicycle(int bicycleId)
        {
            var dtoBicycle = BikeExistsById(bicycleId);
            return _mapper.Map<BicycleViewModel>(dtoBicycle);
            
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
