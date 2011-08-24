Hardware screen driver uses Blocks that are two column by three rows to control pixels


Hardware drive for pushing screen blocks has two methods:
1. int GetBlock(int n, int m); which returns the state value of the block
2. void SetBlock(int n, int m, int state); which set the value of the block at the cooridinate (n,m) to "state"


UI program has a method:
void SetPixel(int n, int m)

You need to drive the screen from the UI using the hardware driver. GO!