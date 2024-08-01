using Heist;

public class Hacker : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public int TeamMemberSpecialty { get; set; }

    public void PerformSkill(Bank bank)
    {
        // Take the Bank parameter and decrement its appropriate security score by the SkillLevel. i.e. A Hacker with a skill level of 50 should decrement the bank's AlarmScore by 50.
        bank.AlarmScore -= SkillLevel;
        Console.WriteLine(
            $"{Name} is hacking the alarm system. Decreased security by {SkillLevel} points."
        );
        // If the appropriate security score has be reduced to 0 or below, print a message to the console
        if (bank.AlarmScore == 0)
        {
            Console.WriteLine($"{Name} has disabled the alarm system!");
        }
    }

    public Hacker(string name, int skillLevel, int percentageCut, int teamMemberSpecialty)
    {
        Name = name;
        SkillLevel = skillLevel;
        PercentageCut = percentageCut;
        TeamMemberSpecialty = teamMemberSpecialty;
    }
}
