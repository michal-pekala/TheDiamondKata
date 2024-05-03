namespace TheDiamondKata;

public class DiamondKata
{
	private readonly int _size;

	public DiamondKata(int size = 1)
	{
		if (size is <= 0 or > 26)
			throw new ArgumentException($"SIZE {size} IS NOT ALLOWED");

		_size = size;
	}

	public string? Line(int nr)
	{
		if (nr >= 2 * _size)
			return null;

		var spacePrefix = Space(Math.Max(_size - nr, 0));

		var spaceSuffix = string.Empty;

		if (nr > 1)
			spaceSuffix = Space(2 * nr - 3);

		return spacePrefix + Letter(nr) + (nr > 1 ? spaceSuffix + Letter(nr) : string.Empty);
	}

	private string Space(int length)
		=> string.Join(null, Enumerable.Repeat(' ', length));

	private char Letter(int nr) => (char)('A' + nr - 1);
}