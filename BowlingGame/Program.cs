namespace BowlingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bowling Game Demo ===\n");

            DemoGutterGame();
            DemoAverageGame();
            DemoSpareGame();
            DemoStrikeGame();
            DemoPerfectGame();

            Console.Read();
        }

        static void DemoGutterGame()
        {
            var game = new Game();
            for (int i = 0; i < 20; i++)
                game.Roll(0);

            Console.WriteLine("Gutter game (all zeros):");
            Console.WriteLine($"  Score: {game.Score()}  (expected: 0)\n");
        }

        static void DemoAverageGame()
        {
            var game = new Game();
            for (int i = 0; i < 20; i++)
                game.Roll(3);

            Console.WriteLine("Average game (all 3s):");
            Console.WriteLine($"  Score: {game.Score()}  (expected: 60)\n");
        }

        static void DemoSpareGame()
        {
            var game = new Game();
            // Frame 1: spare (7+3), then 4 pins next roll
            game.Roll(7); game.Roll(3);
            game.Roll(4); game.Roll(2);
            // Remaining 8 frames with 3+3
            for (int i = 0; i < 16; i++)
                game.Roll(3);

            Console.WriteLine("Spare demo (7+3 spare, then 4+2, rest 3s):");
            Console.WriteLine($"  Frame 1 spare bonus: +4  =>  (10+4) + (4+2) + 8*(3+3)");
            Console.WriteLine($"  Score: {game.Score()}  (expected: {14 + 6 + 8 * 6})\n");
        }

        static void DemoStrikeGame()
        {
            var game = new Game();
            // Frame 1: strike, then 4+3 next frame
            game.Roll(10);
            game.Roll(4); game.Roll(3);
            // Remaining 8 frames with 2+2
            for (int i = 0; i < 16; i++)
                game.Roll(2);

            Console.WriteLine("Strike demo (strike, then 4+3, rest 2s):");
            Console.WriteLine($"  Frame 1 strike bonus: +4+3  =>  (10+4+3) + (4+3) + 8*(2+2)");
            Console.WriteLine($"  Score: {game.Score()}  (expected: {17 + 7 + 8 * 4})\n");
        }

        static void DemoPerfectGame()
        {
            var game = new Game();
            for (int i = 0; i < 12; i++)
                game.Roll(10);

            Console.WriteLine("Perfect game (12 strikes):");
            Console.WriteLine($"  Score: {game.Score()}  (expected: 300)\n");
        }
    }
}
