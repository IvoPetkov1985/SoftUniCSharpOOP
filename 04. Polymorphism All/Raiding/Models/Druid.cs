﻿namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;

        public Druid(string name) 
            : base(name)
        {
        }

        public override int Power { get { return DruidPower; } }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
