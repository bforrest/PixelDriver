namespace PixelDriverProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var hardware = new HardwareDriver(5);
            var ui = new UI_Adapter(hardware);
            ui.SetPixel(5,5);
        }
    }
}