// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
bool[][] jaggedArray2 = new bool[][]
{
new bool[] { true, false },
new bool[] { true, true },
new bool[] { false, true }
};

Robot r = new Robot();

List<Point> ok = r.getPath1(jaggedArray2);

foreach (Point item in ok)
{
    Console.WriteLine(item.row + item.col);
}

