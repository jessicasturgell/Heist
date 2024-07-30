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
