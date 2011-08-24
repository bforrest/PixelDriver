using System;

namespace PixelDriverProblem
{
    public class UI_Adapter
    {
        private readonly IScreenDriver drivenScreen;

        public UI_Adapter(IScreenDriver screen)
        {
            drivenScreen = screen;            
        }

        public int GetPixelState(int x, int y)
        {
            return drivenScreen.GetBlock(x, y);
        }

        public void SetPixel(int x, int y)
        {
            var blockColumn = GetBlockColumn(x);
            var blockRow = GetBlockRow(y);

            int pixelColumn = GetPixelColumn(x);
            int pixelRow= GetPixelRow(y);

            int pixelOnValue = GetPixelValue(pixelRow, pixelColumn);

            var targetBlock = drivenScreen.GetBlock(blockColumn, blockRow);

            drivenScreen.SetBlock(blockColumn, blockRow, (targetBlock + pixelOnValue));

        }

        public int GetBlockColumn(int xValue)
        {
            return xValue / drivenScreen.ColumnsPerBlock;
        }

        public int GetBlockRow(int yValue)
        {
            return yValue / drivenScreen.RowsPerBlock;
        }

        public int GetPixelColumn(int xValue)
        {
            return xValue % drivenScreen.ColumnsPerBlock;
        }

        public int GetPixelRow(int yValue)
        {
            return yValue % drivenScreen.RowsPerBlock;
        }

        public int GetPixelValue(int row, int column)
        {
            var result = ((2*row) + column);

           return (int)Math.Pow(2, result);
        }
    }
}