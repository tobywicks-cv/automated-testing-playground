using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class CellsMatrix
    {
        public const int Size = 3;

        private bool[,] _cells;

        public CellsMatrix()
        {
            _cells = new bool[Size, Size];
        }

        public CellsMatrix(bool[,] initial)
        {
            if (initial is null)
                throw new ArgumentNullException(nameof(initial));

            if (initial.GetLength(0) != Size || initial.GetLength(1) != Size)
                throw new ArgumentException($"Initial matrix must be {Size}x{Size}.", nameof(initial));

            _cells = (bool[,])initial.Clone();
        }

        public bool this[int row, int col]
        {
            get
            {
                ValidateCoordinates(row, col);
                return _cells[row, col];
            }
            set
            {
                ValidateCoordinates(row, col);
                _cells[row, col] = value;
            }
        }

        public void SetCell(int row, int col, bool isAlive)
        {
            this[row, col] = isAlive;
        }

        public bool[,] ToArray()
        {
            return (bool[,])_cells.Clone();
        }

        public CellsMatrix NextGeneration()
        {
            var next = new bool[Size, Size];

            for (var row = 0; row < Size; row++)
            {
                for (var col = 0; col < Size; col++)
                {
                    var aliveNeighbours = CountAliveNeighbours(row, col);
                    var isAlive = _cells[row, col];

                    next[row, col] = isAlive
                        ? (aliveNeighbours == 2 || aliveNeighbours == 3)
                        : (aliveNeighbours == 3);
                }
            }

            return new CellsMatrix(next);
        }

        public void Step()
        {
            _cells = NextGeneration()._cells;
        }

        private int CountAliveNeighbours(int row, int col)
        {
            var count = 0;

            for (var dr = -1; dr <= 1; dr++)
            {
                for (var dc = -1; dc <= 1; dc++)
                {
                    if (dr == 0 && dc == 0)
                        continue;

                    var r = row + dr;
                    var c = col + dc;

                    if (r < 0 || r >= Size || c < 0 || c >= Size)
                        continue;

                    if (_cells[r, c])
                        count++;
                }
            }

            return count;
        }

        private static void ValidateCoordinates(int row, int col)
        {
            if (row < 0 || row >= Size)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (col < 0 || col >= Size)
                throw new ArgumentOutOfRangeException(nameof(col));
        }
    }
}