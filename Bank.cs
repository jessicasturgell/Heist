namespace Heist
{
    public class Bank
    {
        // Public Properties
        public string Name { get; }

        public int DifficultyLevel { get; set; }

        public Bank(string name, int difficultyLevel)
        {
            Name = name;
            DifficultyLevel = difficultyLevel;
        }
    }
}
