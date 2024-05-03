using FluentAssertions;

namespace TheDiamondKata.UnitTests;

public class DiamondKataTests
{
	[Fact]
	public void DiamondKata_line_1_is_single_letter()
	{
		var sut = new DiamondKata();

		var result = sut.Line(1);

		result.Should().Be("A");
	}
}