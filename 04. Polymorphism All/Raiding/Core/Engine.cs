using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;
        private readonly IList<IBaseHero> heroes;

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
            this.heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int heroesCount = int.Parse(reader.ReadLine());

            while (heroesCount > 0)
            {
                string heroName = reader.ReadLine();
                string heroType = reader.ReadLine();

                try
                {
                    heroes.Add(CreateHero(heroName, heroType));
                    heroesCount--;
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (IBaseHero hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(reader.ReadLine());

            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }

        private IBaseHero CreateHero(string name, string type)
        {
            return heroFactory.Create(name, type);
        }
    }
}
