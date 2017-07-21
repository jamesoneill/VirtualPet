using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class AnimalStats
    {
        public int AnimalStatsId { get; set; }
        public float HungerIncreaseRate { get; set; }
        public float HungerDecreaseRate { get; set; }
        public float HappinessIncreaseRate { get; set; }
        public float HappinessDecreaseRate { get; set; }
        public float MaxHunger { get; set; }
        public float MinHunger { get; set; }
        public float MaxHappiness { get; set; }
        public float MinHappiness { get; set; }
    }
}
