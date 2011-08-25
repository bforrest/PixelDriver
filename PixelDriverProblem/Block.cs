using System;

namespace PixelDriverProblem
{
    public class Block
    {
        public Block(int N, int M, int Status)
        {
            this.Status = Status;
            this.M = M;
            this.N = N;
        }

        public int N { get; private set; }
        public int M { get; private set; }
        public int Status { get; set; }
    }
}