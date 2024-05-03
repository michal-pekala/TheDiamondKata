
namespace TheDiamondKata;

public class DiamondKata
{
	public DiamondKata(int size = 1)
	{
		if (size is 0 or > 26)
			throw new ArgumentException($"SIZE {size} IS NOT ALLOWED");
	}

	public string? Line(int nr) => nr == 1 ? "A" : null;
}