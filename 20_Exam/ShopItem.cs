using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Exam
{
    public class ShopItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CostResource { get; set; }
        public int Cost { get; set; }
        public Action<Hero> Effect { get; set; }

        public ShopItem(string name, string description, string costResource, int cost, Action<Hero> effect)
        {
            Name = name;
            Description = description;
            CostResource = costResource;
            Cost = cost;
            Effect = effect;
        }

        public void ApplyEffect(Hero hero)
        {
            Effect(hero);
        }
    }
}
