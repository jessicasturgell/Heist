using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace Heist
{
    public class CreateTeam
    {
        public static int CreateTeamMembers(List<IRobber> rolodex)
        {
            List<TeamMember> teamMembers = new List<TeamMember>() { };
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
                TeamMember teamMember = new TeamMember(
                    selectedOperative.Name,
                    selectedOperative.SkillLevel,
                    selectedOperative.PercentageCut
                );
                teamMembers.Add(teamMember);
                Console.WriteLine(
                    $"You just added {teamMember.Name} to your team. Their Skill Level is {teamMember.SkillLevel}. Their percentage cut is {teamMember.PercentageCut}."
                );
            }

            Console.WriteLine($"Your team has {teamMembers.Count} member(s).");
            Console.WriteLine("Team Members:");
            foreach (TeamMember teamMember in teamMembers)
            {
                Console.WriteLine($"\n   Name: {teamMember.Name}");
                Console.WriteLine($"   Skill Level: {teamMember.SkillLevel}");
                Console.WriteLine($"   Percentage Cut: {teamMember.PercentageCut}");
            }

            int totalSkill = teamMembers.Sum(tMObj => tMObj.SkillLevel);
            Console.WriteLine($"\nYour team's total skill level is {totalSkill}.");

            return totalSkill;
        }
    }
}
