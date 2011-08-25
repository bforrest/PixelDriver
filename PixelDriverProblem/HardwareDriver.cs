using System;
using System.Threading.Tasks;

namespace PixelDriverProblem
{
    public class HardwareDriver : IScreenDriver
    {
        private readonly Block[,] screenBlocks;

        public HardwareDriver(int maximumXCoordinateValue)
        {
            int gridSize = maximumXCoordinateValue + 1;

            screenBlocks = new Block[gridSize, gridSize];

            Parallel.For(0, 
                gridSize, 
                i =>
            {
                for (int j = 0; j < gridSize; j++)
                {
                    screenBlocks[i, j] = new Block(i, j, 0);
                }
            });
        }

        public int GetBlock(int n, int m)
        {
            if (doesBlockExist(n, m))
                return TheBlockGrid[n, m].Status;
            ThrowIndexOutOfRange(n, m);
            return int.MinValue;
        }

        public Block VerifyBlock(int n, int m)
        {
            return doesBlockExist(n, m) ? TheBlockGrid[m, m] : null;
        }

        public void SetBlock(int n, int m, int state)
        {
            if (doesBlockExist(n, m))
            {
                TheBlockGrid[n, m].Status = state;
                Console.WriteLine(string.Format("The state of the block at [{0},{1}] has been set to {2}", n, m, state));
                return;
            }
            ThrowIndexOutOfRange(n, m);
        }

        public int RowsPerBlock
        {
            get { return 3; }
        }

        public int ColumnsPerBlock
        {
            get { return 2; }
        }

        private bool doesBlockExist(int n, int m)
        {
            return (n <= TheBlockGrid.GetUpperBound(dimension:0) && m <= TheBlockGrid.GetUpperBound(dimension:1));
        }

        private void ThrowIndexOutOfRange(int n, int m)
        {
            throw new IndexOutOfRangeException(string.Format("No block axitsts at [{0},{1}]", n, m));
        }

        public Block[,] TheBlockGrid
        {
            get
            {
                return screenBlocks;
            }
        }
    }
}