using FluentAssertions;

namespace TheDiamondKata.UnitTests;

public class DiamondKataTests
{
	private readonly Random _random = new();

	private readonly TextFixture _txt = new();

	[Fact]
	public void DiamondKata_of_size_27_throws_ArgumentException()
	{
		var act = () => new DiamondKata(size: 27);

		act.Should().Throw<ArgumentException>();
	}

	[Fact]
	public void DiamondKata_of_size_0_throws_ArgumentException()
	{
		var act = () => new DiamondKata(size: 0);

		act.Should().Throw<ArgumentException>();
	}

	[Fact]
	public void DiamondKata_of_size_less_than_0_throws_ArgumentException()
	{
		var size = _random.Next(1000);

		var act = () => new DiamondKata(size: -size);

		act.Should().Throw<ArgumentException>();
	}

	[Fact]
	public void DiamondKata_of_size_n_line_1_contains_n_minus_1_spaces()
	{
		var size = _random.Next(26) + 1;

		var sut = new DiamondKata(size);

		var result = sut.Line(1);

		var expectedSpace = _txt.Space(size - 1);

		result.Should().Be(expectedSpace + "A");
	}

	[Fact]
	public void DiamondKata_of_size_n_line_2n_is_null()
	{
		var size = _random.Next(26) + 1;

		var sut = new DiamondKata(size);

		var result = sut.Line(2 * size);

		result.Should().BeNull();
	}

	[Fact]
	public void DiamondKata_of_size_n_line_m_contains_n_minus_m_spaces_prefix()
	{
		// ARRANGE
		var size = _random.Next(26) + 1;

		var lineNr = _random.Next(size) - 1;

		var sut = new DiamondKata(size);

		// ACT
		var result = sut.Line(lineNr);

		//ASSERT
		var expectedSpace = _txt.Space(size - lineNr);

		result.Should().NotBeNull();
		result.Prefix(size - lineNr).Should().Be(expectedSpace);
	}
}