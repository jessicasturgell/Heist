namespace Heist
{
    public class TeamMember
    {
        // Public Properties
        public string Name { get; }

        public int SkillLevel { get; }
        public int PercentageCut { get; }

        // public double CourageFactor { get; }

        public TeamMember(string name, int skillLevel, int percentageCut)
        {
            Name = name;
            SkillLevel = skillLevel;
            PercentageCut = percentageCut;
            // CourageFactor = courageFactor;
        }
    }
}
