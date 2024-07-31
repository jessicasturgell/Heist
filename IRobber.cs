using Heist;

public interface IRobber
{
    string Name { get; set; }
    int SkillLevel { get; set; }
    int PercentageCut { get; set; }

    // A method called PerformSkill that takes in a Bank parameter and doesn't return anything.
    public void PerformSkill(Bank bank);
}
