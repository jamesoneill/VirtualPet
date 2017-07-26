using System;
using System.Collections.Generic;
using System.Text;

namespace JO.Data
{
    public class AnimalStats : BaseEntity
    {
        public int? AnimalStatsId { get; set; }
        public double HungerIncreaseRate { get; set; } = 15;
        public double HungerDecreaseRate { get; set; } = 10;
        public double HappinessIncreaseRate { get; set; } = 15;
        public double HappinessDecreaseRate { get; set; } = -10;
        public TimeSpan HungerTickRate { get; set; } = TimeSpan.FromMinutes(60);
        public TimeSpan HappinessTickRate { get; set; } = TimeSpan.FromMinutes(60);
        public double MaxHunger { get; set; } = 100;
        public double MinHunger { get; set; } = -100;
        public double MaxHappiness { get; set; } = 100;
        public double MinHappiness { get; set; } = -100;
    }
}
