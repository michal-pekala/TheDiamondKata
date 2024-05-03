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
		var space = string.Join(null, Enumerable.Repeat(' ', Math.Max(_size - nr, 0)));

		return nr < 2 * _size ? space + "A" : null;
	}
}