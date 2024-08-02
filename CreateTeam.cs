using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace Heist
{
    public class CreateTeam
    {
        public static List<IRobber> CreateTeamMembers(List<IRobber> rolodex)
        {
            List<IRobber> teamMembers = new List<IRobber>();
            int percentCutTaken = 0;
            int percentCutRemaining = 100 - percentCutTaken;
            void PrintRolodex()
            {
                bool operativesRemaining = false;
                foreach (IRobber operative in rolodex)
                {
                    string specialSkill = "None";
                    if (operative.TeamMemberSpecialty == 1)
                    {
                        specialSkill = "Hacker";
                    }
                    if (operative.TeamMemberSpecialty == 2)
                    {
                        specialSkill = "Muscle";
                    }
                    if (operative.TeamMemberSpecialty == 3)
                    {
                        specialSkill = "Lock Specialist";
                    }
                    if (percentCutTaken + operative.PercentageCut <= 100)
                    {
                        operativesRemaining = true;
                        int index = rolodex.FindIndex(a => a.Name == operative.Name) + 1;
                        Console.WriteLine($"\n   Name: {operative.Name}");
                        Console.WriteLine($"   Class: {specialSkill}");
                        Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                        Console.WriteLine($"   Percentage Cut: {operative.PercentageCut}%");
                        Console.WriteLine($"   Index: {index}");
                    }

                    if (!operativesRemaining)
                    {
                        Console.WriteLine("\nNo potential operatives remaining!\n");
                    }
                }
            }

            while (true)
            {
                PrintRolodex();
                Console.WriteLine(
                    "Add operative to team (Input Index # of an operative to add them to your team, or press enter to start heist): "
                );
                Console.Write("Index: ");
                string teamMemberIndexInput = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(teamMemberIndexInput))
                {
                    break;
                }
                int teamMemberIndex = Int32.Parse(teamMemberIndexInput);
                IRobber selectedOperative = rolodex[teamMemberIndex - 1];
                if (percentCutTaken + selectedOperative.PercentageCut > 100)
                {
                    Console.WriteLine("Adding this operative to your team would exceed the cut!");
                    continue;
                }

                if (selectedOperative.TeamMemberSpecialty == 1)
                {
                    Hacker teamMember = new Hacker(
                        selectedOperative.Name,
                        selectedOperative.SkillLevel,
                        selectedOperative.PercentageCut,
                        selectedOperative.TeamMemberSpecialty
                    );
                    teamMembers.Add(teamMember);
                    rolodex.RemoveAt(teamMemberIndex - 1);
                    percentCutTaken += selectedOperative.PercentageCut;
                    percentCutRemaining = 100 - percentCutTaken;
                    Console.WriteLine(
                        $"\nYou just added Hacker {teamMember.Name} to your team. Their Skill Level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}%. Cut remaining is {percentCutRemaining}%."
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
                    rolodex.RemoveAt(teamMemberIndex - 1);
                    percentCutTaken += selectedOperative.PercentageCut;
                    percentCutRemaining = 100 - percentCutTaken;
                    Console.WriteLine(
                        $"\nYou just added Muscle {teamMember.Name} to your team. Their Skill Level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}%. Cut remaining is {percentCutRemaining}%."
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
                    rolodex.RemoveAt(teamMemberIndex - 1);
                    percentCutTaken += selectedOperative.PercentageCut;
                    percentCutRemaining = 100 - percentCutTaken;
                    Console.WriteLine(
                        $"\nYou just added Lock Specialist {teamMember.Name} to your team. Their skill level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}%. Cut remaining is {percentCutRemaining}%."
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
            return teamMembers;
        }
    }
}
