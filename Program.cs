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
            int playerCut = 100 - teamMembers.Sum(tMObj => tMObj.PercentageCut);

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
                foreach (var teamMember in teamMembers)
                {
                    Console.WriteLine(
                        $"   {teamMember.Name} received ${bank.CashOnHand / teamMember.PercentageCut}."
                    );
                }
                Console.Write($"   You received ${bank.CashOnHand / playerCut}.");
            }
        }
    }
}
