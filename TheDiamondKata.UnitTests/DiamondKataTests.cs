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

	[Fact]
	public void DiamondKata_of_size_1_line_2_is_null()
	{
		var sut = new DiamondKata();

		var result = sut.Line(2);

		result.Should().BeNull();
	}

	[Fact]
	public void DiamondKata_of_size_27_throws_ArgumentException()
	{
		var act = () => new DiamondKata(size: 27);

		act.Should().Throw<ArgumentException>();
	}
}