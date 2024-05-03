using TheDiamondKata;

if (args.Length != 1 || args[0].Length != 1)
		Console.WriteLine("1 arg expected: letter A-Z");

var size = char.Parse(args[0]) - 'A' + 1;

var printer = new DiamondKata(size);

for (int i = 1; i < 2 * size; i++ )
	Console.WriteLine(printer.Line(i));