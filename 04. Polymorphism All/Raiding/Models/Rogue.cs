﻿namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;

        public Rogue(string name) 
            : base(name)
        {
        }

        public override int Power { get { return RoguePower; } }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
