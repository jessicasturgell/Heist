using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace Heist
{
    public class Bank
    {
        // Public Properties
        public string Name { get; }

        public int DifficultyLevel { get; set; }

        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }

        // If all the scores are less than or equal to 0, this should be false. If any of the scores are above 0, this should be true
        public bool IsSecure
        {
            get
            {
                return CashOnHand > 0 || AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0;
            }
        }

        public Bank(string name, int difficultyLevel)
        {
            Name = name;
            DifficultyLevel = difficultyLevel;
        }
    }
}
