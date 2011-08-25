using System;

namespace PixelDriverProblem
{
    public interface IScreenDriver
    {
        int GetBlock(int n, int m);
        void SetBlock(int n, int m, int state);
        int RowsPerBlock { get; }
        int ColumnsPerBlock { get; }
    }
}
