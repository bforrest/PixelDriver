using System;
using NUnit.Framework;

namespace PixelDriverProblem
{
    [TestFixture]
    public class TestDriver
    {
        private HardwareDriver screenDriver;
        private UI_Adapter adapter;

        [TestFixtureSetUp]
        public void Setup()
        {
            screenDriver = new HardwareDriver(5);
            adapter = new UI_Adapter(screenDriver);
        }

        [Test]
        public void initial_block_value_should_be_zero()
        {
            int intialState = screenDriver.GetBlock(5, 5);
            Assert.AreEqual(0, intialState);
        }

        [Test]
        public void block_row_value_for_pixel_row_5_should_be_1()
        {
            Assert.AreEqual(1, adapter.GetBlockRow(5));
        }

        [Test]
        public void block_row_for_pixel_row_2_should_be_0()
        {
            Assert.AreEqual(0, adapter.GetBlockRow(2));
        }

        [Test]
        public void block_column_for_pixel_column_5_should_be_2()
        {
            Assert.AreEqual(2, adapter.GetBlockColumn(5));
        }

        [Test]
        public void block_column_for_pixel_column_2_should_be_1()
        {
            Assert.AreEqual(1, adapter.GetBlockColumn(2));
        }

        [Test]
        public void pixel_column_within_block_for_pixel_5_should_be_1()
        {
            Assert.AreEqual(1, adapter.GetPixelColumn(5));
        }

        [Test]
        public void pixel_column_for_pixel_2_should_be_0()
        {
            Assert.AreEqual(0, adapter.GetPixelColumn(2));
        }

        [Test]
        public void turn_pixel_5_5_on()
        {
            const int pixelX = 5;
            const int pixelY = 5;

            adapter.SetPixel(pixelX, pixelY);

            var blockX = adapter.GetBlockColumn(5);
            var blockY = adapter.GetBlockRow(5);

            int blockStateAfterSet = screenDriver.GetBlock(blockX, blockY);

            var pixelOn = (int)Math.Pow(2, 5);

            Assert.AreEqual(pixelOn, blockStateAfterSet);
        }
    }
}