﻿// In the Main method, create a List<IRobber> and store it in a variable named rolodex. This list will contain all possible operatives that we could employ for future heists. We want to give the user the opportunity to add new operatives to this list, but for now let's pre-populate the list with 5 or 6 robbers (give it a mix of Hackers, Lock Specialists, and Muscle).

namespace Heist
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            Console.WriteLine("Plan Your Heist!");

            int alarmScore = random.Next(0, 101);
            int vaultScore = random.Next(0, 101);
            int securityGuardScore = random.Next(0, 101);
            int cashOnHand = random.Next(50000, 1000001);

            Bank bank = new Bank("Bank", cashOnHand, alarmScore, vaultScore, securityGuardScore);

            if (alarmScore > vaultScore && alarmScore > securityGuardScore)
            {
                Console.WriteLine($"Most Secure: Alarms");
            }
            if (vaultScore > alarmScore && vaultScore > securityGuardScore)
            {
                Console.WriteLine($"Most Secure: Vaults");
            }
            if (securityGuardScore > alarmScore && securityGuardScore > vaultScore)
            {
                Console.WriteLine($"Most Secure: Guards");
            }

            if (alarmScore < vaultScore && alarmScore < securityGuardScore)
            {
                Console.WriteLine($"Least Secure: Alarms");
            }
            if (vaultScore < alarmScore && vaultScore < securityGuardScore)
            {
                Console.WriteLine($"Least Secure: Vaults");
            }
            if (securityGuardScore < alarmScore && securityGuardScore < vaultScore)
            {
                Console.WriteLine($"Least Secure: Guards");
            }

            // gets rolodex and returns list of operatives
            List<IRobber> rolodex = Rolodex.CreateRolodex();
            // constructs team and returns total skill level
            List<IRobber> teamMembers = CreateTeam.CreateTeamMembers(rolodex);

            foreach (var teamMember in teamMembers)
            {
                teamMember.PerformSkill(bank);
            }

            if (bank.IsSecure)
            {
                Console.WriteLine($"Failed to take out bank security. Crew is returning to base.");
            }
            else
            {
                Console.WriteLine($"Heist successful! Your crew has uncovered ${bank.CashOnHand}.");
            }

            // int trialRuns = 0;
            // int trialRunsNeeded = 0;
            // int successfulRuns = 0;
            // int failedRuns = 0;
            // bool isValidTrialRuns = false;
            // while (!isValidTrialRuns)
            // {
            //     Console.WriteLine("How many trial runs would you like to simulate with this team?");
            //     Console.Write("Trial Runs: ");
            //     string trialRunInput = Console.ReadLine() ?? "";
            //     try
            //     {
            //         trialRunsNeeded = Int32.Parse(trialRunInput);
            //         isValidTrialRuns = true;
            //     }
            //     catch (FormatException)
            //     {
            //         Console.WriteLine("Please enter a valid number.");
            //     }

            //     while (trialRuns < trialRunsNeeded)
            //     {
            //         // generate a random number between -10 and 10 for heist's luck value
            //         int luckValue = random.Next(-10, 11);

            //         // compare team member skill to bank difficulty
            //         if ((totalSkill + luckValue) < bank.DifficultyLevel)
            //         {
            //             Console.WriteLine(
            //                 $"Trial Run #{trialRuns + 1}: You failed your heist. Still poor."
            //             );
            //             successfulRuns++;
            //         }
            //         else
            //         {
            //             Console.WriteLine(
            //                 $"Trial Run #{trialRuns + 1}: Success! You're not poor anymore."
            //             );
            //             failedRuns++;
            //         }

            //         trialRuns++;
            //     }
            //     Console.WriteLine(
            //         $"Out of {trialRuns} trial runs, {successfulRuns} succeeded and {failedRuns} failed."
            //     );
            // }
        }
    }
}
