using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeManager_BlazorServerUI.Services
{
    public interface IPropertyService
    {
        Task<List<Car>> GetCars();
    }

    public class PropertyService : IPropertyService
    {
        public PropertyService()
        {
        }

        public async Task<List<Car>> GetCars()
        {
            //Trick the compiler to "wait 0 seconds";
            //Reason: Made method async before hooking up
            //to actual internet service
            await Task.Delay(0);
            return new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Type = CarType.SUV,
                    Make = "Chevrolet",
                    Model = "Tahoe",
                    Year = 2018
                },
                new Car()
                {
                    Id = 2,
                    Type = CarType.SUV,
                    Make = "Kia",
                    Model = "Sorento",
                    Year = 2016

                }
            };
        }
    }
}
