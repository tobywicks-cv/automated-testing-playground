namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new CellsMatrix();

            matrix[0, 1] = true;
            matrix[1, 1] = true;
            matrix[2, 1] = true;

            Console.WriteLine("Generation 0:");
            PrintMatrix(matrix);

            matrix.Step();

            Console.WriteLine();
            Console.WriteLine("Generation 1:");
            PrintMatrix(matrix);

            matrix.Step();

            Console.WriteLine();
            Console.WriteLine("Generation 2:");
            PrintMatrix(matrix);

            Console.ReadLine();
        }

        private static void PrintMatrix(CellsMatrix matrix)
        {
            for (var row = 0; row < CellsMatrix.Size; row++)
            {
                for (var col = 0; col < CellsMatrix.Size; col++)
                {
                    Console.Write(matrix[row, col] ? " O " : " X ");
                }

                Console.WriteLine();
            }
        }
    }
}
