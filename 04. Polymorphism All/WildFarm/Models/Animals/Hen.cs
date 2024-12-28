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

        protected override IReadOnlyCollection<Type> PreferedFoods
        {
            get { return new List<Type>() { typeof(Meat), typeof(Seeds), typeof(Fruit), typeof(Vegetable) }; }
        }

        protected override double WeightMofidier { get { return HenWeightModifier; } }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
