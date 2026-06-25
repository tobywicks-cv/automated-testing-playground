using BowlingGameDemo;

RunScenario("Gutter Game", game =>
{
    for (int i = 0; i < 20; i++) game.Roll(0);
});

RunScenario("All Ones", game =>
{
    for (int i = 0; i < 20; i++) game.Roll(1);
});

RunScenario("One Spare (5,5,3,...)", game =>
{
    game.Roll(5); game.Roll(5); game.Roll(3);
    for (int i = 0; i < 17; i++) game.Roll(0);
});

RunScenario("One Strike (10,3,4,...)", game =>
{
    game.Roll(10); game.Roll(3); game.Roll(4);
    for (int i = 0; i < 16; i++) game.Roll(0);
});

RunScenario("Perfect Game (12 strikes)", game =>
{
    for (int i = 0; i < 12; i++) game.Roll(10);
});

static void RunScenario(string name, Action<BowlingGame> play)
{
    var game = new BowlingGame();
    play(game);

    Console.WriteLine($"=== {name} ===");
    PrintScorecard(game);
    Console.WriteLine($"Total Score: {game.Score()}");
    Console.WriteLine();
}

static void PrintScorecard(BowlingGame game)
{
    int[] rolls = game.Rolls;
    int rollIndex = 0;
    int runningScore = 0;

    var frameLabels = new List<string>();
    var frameScores = new List<string>();

    for (int frame = 0; frame < 10; frame++)
    {
        bool isLastFrame = frame == 9;

        if (!isLastFrame && rolls[rollIndex] == 10) // strike
        {
            int bonus = rolls[rollIndex + 1] + rolls[rollIndex + 2];
            runningScore += 10 + bonus;
            frameLabels.Add("[ X ]");
            frameScores.Add(runningScore.ToString().PadLeft(5));
            rollIndex += 1;
        }
        else if (!isLastFrame && rolls[rollIndex] + rolls[rollIndex + 1] == 10) // spare
        {
            int bonus = rolls[rollIndex + 2];
            runningScore += 10 + bonus;
            frameLabels.Add($"[{rolls[rollIndex]} /]");
            frameScores.Add(runningScore.ToString().PadLeft(5));
            rollIndex += 2;
        }
        else if (isLastFrame)
        {
            string label = FormatLastFrame(rolls, rollIndex);
            int f10score = rolls[rollIndex] + rolls[rollIndex + 1];
            if (rolls[rollIndex] == 10 || f10score == 10)
                f10score += rolls[rollIndex + 2];
            runningScore += f10score;
            frameLabels.Add(label);
            frameScores.Add(runningScore.ToString().PadLeft(5));
        }
        else
        {
            runningScore += rolls[rollIndex] + rolls[rollIndex + 1];
            frameLabels.Add($"[{rolls[rollIndex]} {rolls[rollIndex + 1]}]");
            frameScores.Add(runningScore.ToString().PadLeft(5));
            rollIndex += 2;
        }
    }

    Console.WriteLine(string.Join(" ", frameLabels));
    Console.WriteLine(string.Join(" ", frameScores));
}

static string FormatLastFrame(int[] rolls, int i)
{
    string r1 = rolls[i] == 10 ? "X" : rolls[i].ToString();
    string r2 = rolls[i + 1] == 10 ? "X"
              : rolls[i] != 10 && rolls[i] + rolls[i + 1] == 10 ? "/"
              : rolls[i + 1].ToString();
    string r3 = rolls[i + 2] == 10 ? "X" : rolls[i + 2].ToString();

    bool hasThird = rolls[i] == 10 || rolls[i] + rolls[i + 1] == 10;
    return hasThird ? $"[{r1} {r2} {r3}]" : $"[{r1} {r2}]";
}
