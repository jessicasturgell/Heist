using System.Runtime.InteropServices.Marshalling;

namespace Heist
{
    public class CreateTeam
    {
        public static int CreateTeamMembers()
        {
            string? teamMemberName;

            List<TeamMember> teamMembers = new List<TeamMember>() { };

            // This list will contain all possible operatives that we could employ for future heists.
            Hacker nolon = new("Nolon", 25, 10);
            Hacker oleta = new("Oleta", 25, 10);
            LockSpecialist faustino = new("Faustino", 25, 10);
            LockSpecialist claire = new("Claire", 25, 10);
            Muscle larry = new("Larry", 25, 10);
            Muscle laisha = new("Laisha", 25, 10);
            List<IRobber> rolodex = new List<IRobber>()
            {
                nolon,
                oleta,
                faustino,
                claire,
                larry,
                laisha
            };

            Console.WriteLine(
                $"There are currently {rolodex.Count} possible operatives in your rolodex."
            );

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

                Console.Write("Enter Team Member's Percentage Cut: ");

                int teamMemberPercentageCut = Int32.Parse(Console.ReadLine());

                // string courageInput = "";
                // double teamMemberCourageFactor = 0.0;
                // bool isValidCourageFactor = false;
                // while (!isValidCourageFactor)
                // {
                //     Console.Write("Enter Team Member's Courage Factor: ");
                //     courageInput = Console.ReadLine() ?? "";
                //     try
                //     {
                //         teamMemberCourageFactor = Double.Parse(courageInput);
                //         if (teamMemberCourageFactor >= 0.0 && teamMemberCourageFactor <= 2.0)
                //         {
                //             isValidCourageFactor = true;
                //         }
                //         else
                //         {
                //             Console.WriteLine("Courage factor must be a value between 0 and 2.");
                //         }
                //     }
                //     catch (FormatException)
                //     {
                //         Console.WriteLine("Please enter a valid numeric courage factor.");
                //     }
                // }

                if (teamMemberSpecialty == "1")
                {
                    Hacker operative =
                        new(teamMemberName, teamMemberSkillLevel, teamMemberPercentageCut);
                    rolodex.Add(operative);
                    Console.WriteLine(
                        $"You just added {operative.Name} to your team. Their Skill Level is {operative.SkillLevel}. Their Courage Factor is {operative.PercentageCut}."
                    );
                }
                if (teamMemberSpecialty == "2")
                {
                    Muscle operative =
                        new(teamMemberName, teamMemberSkillLevel, teamMemberPercentageCut);
                    rolodex.Add(operative);
                    Console.WriteLine(
                        $"You just added {operative.Name} to your team. Their Skill Level is {operative.SkillLevel}. Their Courage Factor is {operative.PercentageCut}."
                    );
                }
                if (teamMemberSpecialty == "3")
                {
                    LockSpecialist operative =
                        new(teamMemberName, teamMemberSkillLevel, teamMemberPercentageCut);
                    rolodex.Add(operative);
                    Console.WriteLine(
                        $"You just added {operative.Name} to your team. Their Skill Level is {operative.SkillLevel}. Their Courage Factor is {operative.PercentageCut}."
                    );
                }

                // TeamMember teamMember = new TeamMember(
                //     teamMemberName,
                //     teamMemberSkillLevel,
                //     teamMemberCourageFactor
                // );
                // teamMembers.Add(teamMember);
                // Console.WriteLine(
                //     $"You just added {operative.Name} to your team. Their Skill Level is {operative.SkillLevel}. Their Courage Factor is {operative.teamMemberPercentageCut}."
                // );
            }

            Console.WriteLine($"Your team has {rolodex.Count} member(s).");
            Console.WriteLine("Team Members:");
            Console.WriteLine("\nHackers:");
            foreach (IRobber operative in rolodex.OfType<Hacker>())
            {
                Console.WriteLine($"\n   Name: {operative.Name}");
                Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                Console.WriteLine($"   Courage Factor: {operative.PercentageCut}");
            }
            Console.WriteLine("\nMuscle:");
            foreach (IRobber operative in rolodex.OfType<Muscle>())
            {
                Console.WriteLine($"\n   Name: {operative.Name}");
                Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                Console.WriteLine($"   Courage Factor: {operative.PercentageCut}");
            }
            Console.WriteLine("\nLock Specialists:");
            foreach (IRobber operative in rolodex.OfType<LockSpecialist>())
            {
                Console.WriteLine($"\n   Name: {operative.Name}");
                Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                Console.WriteLine($"   Courage Factor: {operative.PercentageCut}");
            }

            int totalSkill = rolodex.Sum(tMObj => tMObj.SkillLevel);
            Console.WriteLine($"\nYour team's total skill level is {totalSkill}.");

            return totalSkill;
        }
    }
}
