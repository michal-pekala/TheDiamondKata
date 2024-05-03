using FluentAssertions;

namespace TheDiamondKata.UnitTests;

public class UnitTest1
{
	[Fact]
	public void DiamondKata_line_1_is_single_letter()
	{
		var sut = new DiamondKata();

		var result = sut.Line(1);

		result.Should().Be("A");
	}

	class DiamondKata
	{
		public string Line(int nr) => "A";
	}
}