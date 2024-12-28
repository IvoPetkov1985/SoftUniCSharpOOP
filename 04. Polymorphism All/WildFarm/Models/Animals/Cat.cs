using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightModifier = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferedFoods
        {
            get { return new List<Type>() { typeof(Vegetable), typeof(Meat) }; }
        }

        protected override double WeightMofidier { get { return CatWeightModifier; } }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
