namespace Heist
{
    public class CreateTeam
    {
        public static int CreateTeamMembers()
        {
            string? teamMemberName;

            List<TeamMember> teamMembers = new List<TeamMember>() { };

            while (true)
            {
                Console.Write("Enter New Team Member's Name (or press Enter to finish): ");
                teamMemberName = Console.ReadLine();

                if (string.IsNullOrEmpty(teamMemberName))
                {
                    break;
                }

                Console.WriteLine("Choose a specialty for this operative.");
                Console.WriteLine("Possible Specialties:");
                Console.WriteLine("  1) Hacker (Disables alarms)");
                Console.WriteLine("  2) Muscle (Disarms guards)");
                Console.WriteLine("  3) Lock Specialist (cracks vault)");
                Console.Write("Selection (1-3): ");

                string teamMemberSpecialty = Console.ReadLine();

                string skillInput = "";
                int teamMemberSkillLevel = 0;
                bool isValidSkillLevel = false;
                while (!isValidSkillLevel)
                {
                    Console.Write("Enter Team Member's Skill Level: ");
                    skillInput = Console.ReadLine() ?? "";
                    try
                    {
                        teamMemberSkillLevel = Int32.Parse(skillInput);
                        isValidSkillLevel = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid numeric skill level.");
                    }
                }

                string courageInput = "";
                double teamMemberCourageFactor = 0.0;
                bool isValidCourageFactor = false;
                while (!isValidCourageFactor)
                {
                    Console.Write("Enter Team Member's Courage Factor: ");
                    courageInput = Console.ReadLine() ?? "";
                    try
                    {
                        teamMemberCourageFactor = Double.Parse(courageInput);
                        if (teamMemberCourageFactor >= 0.0 && teamMemberCourageFactor <= 2.0)
                        {
                            isValidCourageFactor = true;
                        }
                        else
                        {
                            Console.WriteLine("Courage factor must be a value between 0 and 2.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid numeric courage factor.");
                    }
                }
                TeamMember teamMember = new TeamMember(
                    teamMemberName,
                    teamMemberSkillLevel,
                    teamMemberCourageFactor
                );
                teamMembers.Add(teamMember);
                Console.WriteLine(
                    $"You just added {teamMember.Name} to your team. Their Skill Level is {teamMember.SkillLevel}. Their Courage Factor is {teamMember.CourageFactor}."
                );
            }

            Console.WriteLine($"Your team has {teamMembers.Count} member(s).");
            Console.WriteLine("Team Members:");
            foreach (TeamMember teamMember in teamMembers)
            {
                Console.WriteLine($"\n   Name: {teamMember.Name}");
                Console.WriteLine($"   Skill Level: {teamMember.SkillLevel}");
                Console.WriteLine($"   Courage Factor: {teamMember.CourageFactor}");
            }

            int totalSkill = teamMembers.Sum(tMObj => tMObj.SkillLevel);
            Console.WriteLine($"\nYour team's total skill level is {totalSkill}.");

            return totalSkill;
        }
    }
}
