using Heist;

public class LockSpecialist : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }

    public void PerformSkill(Bank bank)
    {
        // Take the Bank parameter and decrement its appropriate security score by the SkillLevel. i.e. A Hacker with a skill level of 50 should decrement the bank's AlarmScore by 50.
        bank.VaultScore -= SkillLevel;
        Console.WriteLine(
            $"{Name} is breaking into the vault. Decreased security by {SkillLevel} points."
        );
        // If the appropriate security score has be reduced to 0 or below, print a message to the console
        if (bank.VaultScore == 0)
        {
            Console.WriteLine($"{Name} has broken into the vault!");
        }
    }

    public LockSpecialist(string name, int skillLevel, int percentageCut)
    {
        Name = name;
        SkillLevel = skillLevel;
        PercentageCut = percentageCut;
    }
}
