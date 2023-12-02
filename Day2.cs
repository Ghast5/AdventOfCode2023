public class Day2
{
    public string ReadInputsTest() => File.ReadAllText(@"...\testInput.txt");
    public string ReadInput() => File.ReadAllText(@"...\inputDay2.txt");

    public int SumIDsOfPossibleGamesPart1(string data)
    {
        string[] games = data.Split("\r\n");
        int sumOfPossibleGames = 0;

        for(int i = 0; i < games.Length; i++)
        {
            string[] game = games[i].Split(": ");
            bool isPossibleGame = IsPossibleGame(game[1]);

            if (isPossibleGame)
                sumOfPossibleGames += i + 1;
        }

        return sumOfPossibleGames;
    }

    public int SumPowerOfSetsPart2(string data)
    {
        int sum = 0;

        string[] inputs = data.Split("\r\n");

        for(int i = 0; i < inputs.Length; i++)
        {
            string[] inputGame = inputs[i].Split(": ");
            sum += CountPower(inputGame[1]);
        }

        return sum;
    }

    private int CountPower(string game)
    {
        string[] sets = game.Split("; ");

        int power = 1;
        Dictionary<string, int> colors = new()
        {
            { "red", 1 },
            { "green", 1 },
            { "blue", 1 }
        };

        for(int i = 0; i < sets.Length; i++)
        {
            string[] balls = sets[i].Split(", ");

            for(int j = 0; j < balls.Length; j++)
            {
                string[] d = balls[j].Split(" ");
                int number = int.Parse(d[0]);

                if (colors[d[1]] < number)
                    colors[d[1]] = number;
            }
        }

        foreach (var color in colors)
            power *= color.Value;

        return power;
    }

    private bool IsPossibleGame(string game)
    {
        string[] sets = game.Split("; ");

        for(int i = 0; i < sets.Length; i++)
        {
            Dictionary<string, int> colors = new()
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            string[] set = sets[i].Split(", ");

            for(int j = 0; j < set.Length; j ++)
            {
                string[] s = set[j].Split(" ");
                if (colors[s[1]] < int.Parse(s[0]))
                    return false;
            }
        }

        return true;
    }
}
