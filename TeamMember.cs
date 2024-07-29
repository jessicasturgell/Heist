namespace Heist
{
    public class TeamMember
    {
        // Public Properties
        public string Name { get; }

        public int SkillLevel { get; }

        public double CourageFactor { get; }

        public TeamMember(string name, int skillLevel, double courageFactor)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courageFactor;
        }
    }
}
