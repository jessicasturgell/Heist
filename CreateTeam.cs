using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace Heist
{
    public class CreateTeam
    {
        public static int CreateTeamMembers(List<IRobber> rolodex)
        {
            List<IRobber> teamMembers = new List<IRobber>();
            while (true)
            {
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
                    Console.WriteLine(
                        $"You just added Hacker {teamMember.Name} to your team. Their Skill Level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}."
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
                    Console.WriteLine(
                        $"You just added Muscle {teamMember.Name} to your team. Their Skill Level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}."
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
                    Console.WriteLine(
                        $"You just added Lock Specialist {teamMember.Name} to your team. Their skill level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}."
                    );
                }
            }

            Console.WriteLine($"Your team has {teamMembers.Count} member(s).");
            Console.WriteLine("Team Members:");
            foreach (IRobber teamMember in teamMembers)
            {
                string specialSkill;
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
                else
                {
                    specialSkill = "None";
                }
                Console.WriteLine($"\n   Name: {teamMember.Name}");
                Console.WriteLine($"   Class: {specialSkill}");
                Console.WriteLine($"   Skill Level: {teamMember.SkillLevel}");
                Console.WriteLine($"   Percentage Cut: {teamMember.PercentageCut}");
            }

            int totalSkill = teamMembers.Sum(tMObj => tMObj.SkillLevel);
            Console.WriteLine($"\nYour team's total skill level is {totalSkill}.");

            return totalSkill;
        }
    }
}
