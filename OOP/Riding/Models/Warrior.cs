﻿
namespace Riding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
            : base(name, 100)
        {
        }
        
        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
