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

		var spacePrefix = string.Join(null, Enumerable.Repeat(' ', Math.Max(_size - nr, 0)));

		var spaceSuffix = string.Empty;

		if (nr > 1)
			spaceSuffix = string.Join(null, Enumerable.Repeat(' ', 2 * nr - 3));

		return spacePrefix + (char)('A' + nr - 1) + spaceSuffix;
	}
}