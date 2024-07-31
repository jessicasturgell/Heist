﻿// In the Main method, create a List<IRobber> and store it in a variable named rolodex. This list will contain all possible operatives that we could employ for future heists. We want to give the user the opportunity to add new operatives to this list, but for now let's pre-populate the list with 5 or 6 robbers (give it a mix of Hackers, Lock Specialists, and Muscle).

namespace Heist
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Plan Your Heist!");

            // construct bank
            int bankDifficulty = 0;
            bool isValidDifficulty = false;
            while (!isValidDifficulty)
            {
                Console.WriteLine("What is the difficulty level of the bank you plan to rob?");
                Console.Write("Difficulty Level: ");
                string difficultyInput = Console.ReadLine() ?? "";
                try
                {
                    bankDifficulty = Int32.Parse(difficultyInput);
                    isValidDifficulty = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid numeric difficulty level.");
                }
            }

            Bank bank = new Bank("Bank", bankDifficulty);

            // This list will contain all possible operatives that we could employ for future heists.
            Hacker nolon = new("Nolon", 50, 25);
            Hacker oleta = new("Oleta", 50, 25);
            LockSpecialist faustino = new("Faustino", 50, 25);
            LockSpecialist claire = new("Claire", 50, 25);
            Muscle larry = new("Larry", 50, 25);
            Muscle laisha = new("Laisha", 50, 25);
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

            //constructs team and returns total skill level
            int totalSkill = CreateTeam.CreateTeamMembers();

            int trialRuns = 0;
            int trialRunsNeeded = 0;
            int successfulRuns = 0;
            int failedRuns = 0;
            bool isValidTrialRuns = false;
            while (!isValidTrialRuns)
            {
                Console.WriteLine("How many trial runs would you like to simulate with this team?");
                Console.Write("Trial Runs: ");
                string trialRunInput = Console.ReadLine() ?? "";
                try
                {
                    trialRunsNeeded = Int32.Parse(trialRunInput);
                    isValidTrialRuns = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }

                while (trialRuns < trialRunsNeeded)
                {
                    // generate a random number between -10 and 10 for heist's luck value
                    Random random = new Random();
                    int luckValue = random.Next(-10, 11);

                    // compare team member skill to bank difficulty
                    if ((totalSkill + luckValue) < bank.DifficultyLevel)
                    {
                        Console.WriteLine(
                            $"Trial Run #{trialRuns + 1}: You failed your heist. Still poor."
                        );
                        successfulRuns++;
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Trial Run #{trialRuns + 1}: Success! You're not poor anymore."
                        );
                        failedRuns++;
                    }

                    trialRuns++;
                }
                Console.WriteLine(
                    $"Out of {trialRuns} trial runs, {successfulRuns} succeeded and {failedRuns} failed."
                );
            }
        }
    }
}
