namespace Heist
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Plan Your Heist!");

            //constructs team and returns total skill level
            int totalSkill = CreateTeam.CreateTeamMembers();

            // new bank
            Bank bank = new Bank("First National Bank");

            // generate a random number between -10 and 10 for heist's luck value
            Random random = new Random();
            int luckValue = random.Next(-10, 11);

            // compare team member skill to bank difficulty
            if ((totalSkill + luckValue) < bank.DifficultyLevel)
            {
                Console.WriteLine("You failed your heist. Still poor.");
            }
            else
            {
                Console.WriteLine("Success! You're not poor anymore.");
            }
        }
    }
}
