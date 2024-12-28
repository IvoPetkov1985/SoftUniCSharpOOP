namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;

        public Warrior(string name) 
            : base(name)
        {
        }

        public override int Power { get { return WarriorPower; } }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
