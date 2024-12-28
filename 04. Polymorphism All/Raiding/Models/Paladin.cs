﻿namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power { get { return PaladinPower; } }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}