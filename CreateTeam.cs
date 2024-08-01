using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace Heist
{
    public class CreateTeam
    {
        public static List<IRobber> CreateTeamMembers(List<IRobber> rolodex)
        {
            List<IRobber> teamMembers = new List<IRobber>();
            List<IRobber> addedOperatives = new List<IRobber>();
            int percentCutTaken = 0;
            int percentCutRemaining = 100 - percentCutTaken;
            void PrintRolodex()
            {
                Console.WriteLine($"Potential Operatives Remaining:");
                Console.WriteLine("\nHackers:");
                foreach (IRobber operative in rolodex.OfType<Hacker>())
                {
                    if (
                        !addedOperatives.Contains(operative)
                        && percentCutTaken + operative.PercentageCut <= 100
                    )
                    {
                        int index = rolodex.FindIndex(a => a.Name == operative.Name) + 1;
                        Console.WriteLine($"\n   Name: {operative.Name}");
                        Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                        Console.WriteLine($"   Percentage Cut: {operative.PercentageCut}%");
                        Console.WriteLine($"   Index: {index}");
                    }
                }
                Console.WriteLine("\nMuscle:");
                foreach (IRobber operative in rolodex.OfType<Muscle>())
                {
                    if (
                        !addedOperatives.Contains(operative)
                        && percentCutTaken + operative.PercentageCut <= 100
                    )
                    {
                        int index = rolodex.FindIndex(a => a.Name == operative.Name) + 1;
                        Console.WriteLine($"\n   Name: {operative.Name}");
                        Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                        Console.WriteLine($"   Percentage Cut: {operative.PercentageCut}%");
                        Console.WriteLine($"   Index: {index}");
                    }
                }
                Console.WriteLine("\nLock Specialists:");
                foreach (IRobber operative in rolodex.OfType<LockSpecialist>())
                {
                    if (
                        !addedOperatives.Contains(operative)
                        && percentCutTaken + operative.PercentageCut <= 100
                    )
                    {
                        int index = rolodex.FindIndex(a => a.Name == operative.Name) + 1;
                        Console.WriteLine($"\n   Name: {operative.Name}");
                        Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                        Console.WriteLine($"   Percentage Cut: {operative.PercentageCut}%");
                        Console.WriteLine($"   Index: {index}");
                    }
                }
            }

            while (true)
            {
                PrintRolodex();
                Console.WriteLine(
                    "Add operative to team (Input Index # of an operative to add them to your team, or press enter to stop): "
                );
                Console.Write("Index: ");
                string teamMemberIndexInput = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(teamMemberIndexInput))
                {
                    break;
                }
                int teamMemberIndex = Int32.Parse(teamMemberIndexInput);
                IRobber selectedOperative = rolodex[teamMemberIndex - 1];
                if (selectedOperative.TeamMemberSpecialty == 1)
                {
                    Hacker teamMember = new Hacker(
                        selectedOperative.Name,
                        selectedOperative.SkillLevel,
                        selectedOperative.PercentageCut,
                        selectedOperative.TeamMemberSpecialty
                    );
                    teamMembers.Add(teamMember);
                    addedOperatives.Add(selectedOperative);
                    percentCutTaken += selectedOperative.PercentageCut;
                    percentCutRemaining = 100 - percentCutTaken;
                    Console.WriteLine(
                        $"You just added Hacker {teamMember.Name} to your team. Their Skill Level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}%. Cut remaining is {percentCutRemaining}%."
                    );
                }
                if (selectedOperative.TeamMemberSpecialty == 2)
                {
                    Muscle teamMember = new Muscle(
                        selectedOperative.Name,
                        selectedOperative.SkillLevel,
                        selectedOperative.PercentageCut,
                        selectedOperative.TeamMemberSpecialty
                    );
                    teamMembers.Add(teamMember);
                    addedOperatives.Add(selectedOperative);
                    percentCutTaken += selectedOperative.PercentageCut;
                    percentCutRemaining = 100 - percentCutTaken;
                    Console.WriteLine(
                        $"You just added Muscle {teamMember.Name} to your team. Their Skill Level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}%. Cut remaining is {percentCutRemaining}%."
                    );
                }
                if (selectedOperative.TeamMemberSpecialty == 3)
                {
                    LockSpecialist teamMember = new LockSpecialist(
                        selectedOperative.Name,
                        selectedOperative.SkillLevel,
                        selectedOperative.PercentageCut,
                        selectedOperative.TeamMemberSpecialty
                    );
                    teamMembers.Add(teamMember);
                    addedOperatives.Add(selectedOperative);
                    percentCutTaken += selectedOperative.PercentageCut;
                    percentCutRemaining = 100 - percentCutTaken;
                    Console.WriteLine(
                        $"You just added Lock Specialist {teamMember.Name} to your team. Their skill level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}%. Cut remaining is {percentCutRemaining}%."
                    );
                }
            }

            Console.WriteLine($"Your team has {teamMembers.Count} member(s).");
            Console.WriteLine("Team Members:");
            foreach (IRobber teamMember in teamMembers)
            {
                string specialSkill = "None";
                if (teamMember.TeamMemberSpecialty == 1)
                {
                    specialSkill = "Hacker";
                }
                if (teamMember.TeamMemberSpecialty == 2)
                {
                    specialSkill = "Muscle";
                }
                if (teamMember.TeamMemberSpecialty == 3)
                {
                    specialSkill = "Lock Specialist";
                }
                Console.WriteLine($"\n   Name: {teamMember.Name}");
                Console.WriteLine($"   Class: {specialSkill}");
                Console.WriteLine($"   Skill Level: {teamMember.SkillLevel}");
                Console.WriteLine($"   Percentage Cut: {teamMember.PercentageCut}");
            }

            int totalSkill = teamMembers.Sum(tMObj => tMObj.SkillLevel);
            Console.WriteLine($"\nYour team's total skill level is {totalSkill}.");
            Console.WriteLine($"\nCut Remaining: {percentCutRemaining}%");

            return teamMembers;
        }
    }
}
