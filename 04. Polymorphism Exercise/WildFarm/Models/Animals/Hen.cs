using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightModifier = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightModifier
            => HenWeightModifier;

        protected override IReadOnlyCollection<Type> PreferedFoods
            => new List<Type> { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
