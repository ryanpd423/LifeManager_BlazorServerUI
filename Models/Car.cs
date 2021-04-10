using System;
using System.Collections.Generic;
using LifeManager_BlazorServerUI.Services;

namespace LifeManager_BlazorServerUI.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public CarType Type { get; set; }
        public int Mileage { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string VehicleIdentificationNumber { get; set; }
        public DateTime PurchaseTimeStamp { get; set; }
        public string Insurance { get; set; }
        public List<ServiceRecord> ServiceHistory { get; set; }
    }

    public enum CarType
    {
        SUV,
        Sedan,
        Truck,
        Crossover,
        Coupe
    }
}
