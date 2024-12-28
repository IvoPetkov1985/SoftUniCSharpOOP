using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeightModifier = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferedFoods
        {
            get { return new List<Type>() { typeof(Meat) }; }
        }

        protected override double WeightMofidier { get { return TigerWeightModifier; } }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
