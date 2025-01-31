﻿namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckAdditionalConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AdditionalConsumption => TruckAdditionalConsumption;

        public override void Refuel(double amount)
        {
            base.Refuel(amount * 0.95);
        }
    }
}
