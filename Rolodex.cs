using System.Reflection;
using System.Runtime.InteropServices.Marshalling;

namespace Heist
{
    public class Rolodex
    {
        public static List<IRobber> CreateRolodex()
        {
            string? teamMemberName;
            // This list will contain all possible operatives that we could employ for future heists.
            Hacker nolon = new("Nolon", 50, 10, 1);
            Hacker oleta = new("Oleta", 50, 10, 1);
            Muscle larry = new("Larry", 50, 10, 2);
            Muscle laisha = new("Laisha", 50, 10, 2);
            LockSpecialist faustino = new("Faustino", 50, 10, 3);
            LockSpecialist claire = new("Claire", 50, 10, 3);
            List<IRobber> rolodex = new List<IRobber>()
            {
                nolon,
                oleta,
                larry,
                laisha,
                faustino,
                claire
            };

            void PrintRolodex()
            {
                Console.WriteLine($"Your rolodex has {rolodex.Count} operative(s).");
                Console.WriteLine("\nHackers:");
                foreach (IRobber operative in rolodex.OfType<Hacker>())
                {
                    int index = rolodex.FindIndex(a => a.Name == operative.Name) + 1;
                    Console.WriteLine($"\n   Name: {operative.Name}");
                    Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                    Console.WriteLine($"   Percentage Cut: {operative.PercentageCut}%");
                    Console.WriteLine($"   Index: {index}");
                }
                Console.WriteLine("\nMuscle:");
                foreach (IRobber operative in rolodex.OfType<Muscle>())
                {
                    int index = rolodex.FindIndex(a => a.Name == operative.Name) + 1;
                    Console.WriteLine($"\n   Name: {operative.Name}");
                    Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                    Console.WriteLine($"   Percentage Cut: {operative.PercentageCut}%");
                    Console.WriteLine($"   Index: {index}");
                }
                Console.WriteLine("\nLock Specialists:");
                foreach (IRobber operative in rolodex.OfType<LockSpecialist>())
                {
                    int index = rolodex.FindIndex(a => a.Name == operative.Name) + 1;
                    Console.WriteLine($"\n   Name: {operative.Name}");
                    Console.WriteLine($"   Skill Level: {operative.SkillLevel}");
                    Console.WriteLine($"   Percentage Cut: {operative.PercentageCut}%");
                    Console.WriteLine($"   Index: {index}");
                }
            }

            PrintRolodex();

            while (true)
            {
                Console.Write(
                    "Enter new operative's name to add to rolodex (or press enter to finish): "
                );
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

                string teamMemberSpecialty = Console.ReadLine() ?? "";

                string skillInput = "";
                int teamMemberSkillLevel = 0;
                bool isValidSkillLevel = false;
                while (!isValidSkillLevel)
                {
                    Console.Write("Enter Operative's Skill Level: ");
                    skillInput = Console.ReadLine() ?? "";
                    try
                    {
                        teamMemberSkillLevel = int.Parse(skillInput);
                        isValidSkillLevel = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid numeric skill level.");
                    }
                }

                Console.Write("Enter Operative's Percentage Cut: ");

                int teamMemberPercentageCut = int.Parse(Console.ReadLine() ?? "");

                if (teamMemberSpecialty == "1")
                {
                    Hacker operative =
                        new(teamMemberName, teamMemberSkillLevel, teamMemberPercentageCut, 1);
                    rolodex.Add(operative);
                    Console.WriteLine(
                        $"You just added Hacker {operative.Name} to your rolodex. Their skill level is {operative.SkillLevel}. Their percentage cut is {operative.PercentageCut}%."
                    );
                }
                if (teamMemberSpecialty == "2")
                {
                    Muscle operative =
                        new(teamMemberName, teamMemberSkillLevel, teamMemberPercentageCut, 2);
                    rolodex.Add(operative);
                    Console.WriteLine(
                        $"You just added Muscle {operative.Name} to your rolodex. Their skill level is {operative.SkillLevel}. Their percentage cut is {operative.PercentageCut}%."
                    );
                }
                if (teamMemberSpecialty == "3")
                {
                    LockSpecialist operative =
                        new(teamMemberName, teamMemberSkillLevel, teamMemberPercentageCut, 3);
                    rolodex.Add(operative);
                    Console.WriteLine(
                        $"You just added Lock Specialist {operative.Name} to your rolodex. Their skill level is {operative.SkillLevel}. Their percentage cut is {operative.PercentageCut}%."
                    );
                }
            }
            PrintRolodex();
            return rolodex;
        }
    }
}
