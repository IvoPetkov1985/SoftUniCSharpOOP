﻿using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlWeightModifier = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PreferedFoods
        {
            get { return new List<Type>() { typeof(Meat) }; }
        }

        protected override double WeightMofidier { get { return OwlWeightModifier; } }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
