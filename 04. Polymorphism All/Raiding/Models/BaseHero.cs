using Raiding.Models.Interfaces;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public virtual int Power { get; }

        public abstract string CastAbility();
    }
}
