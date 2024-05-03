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

	[Fact]
	public void DiamondKata_of_size_0_throws_ArgumentException()
	{
		var act = () => new DiamondKata(size: 0);

		act.Should().Throw<ArgumentException>();
	}

	[Fact]
	public void DiamondKata_of_size_less_than_0_throws_ArgumentException()
	{
		var size = new Random().Next(1000);

		var act = () => new DiamondKata(size: -size);

		act.Should().Throw<ArgumentException>();
	}

	[Fact]
	public void DiamondKata_of_size_n_line_1_contains_n_minus_1_spaces()
	{
		var size = new Random().Next(26) + 1;

		var sut = new DiamondKata(size);

		var result = sut.Line(1);

		var expectedSpace = string.Join(null, Enumerable.Repeat(' ', size - 1));

		result.Should().Be(expectedSpace + "A");
	}

	[Fact]
	public void DiamondKata_of_size_n_line_2n_is_null()
	{
		var size = new Random().Next(26) + 1;

		var sut = new DiamondKata(size);

		var result = sut.Line(2 * size);

		result.Should().BeNull();
	}

	[Fact]
	public void DiamondKata_of_size_n_line_m_contains_n_minus_m_spaces_prefix()
	{
		// ARRANGE
		var size = new Random().Next(26) + 1;

		var lineNr = new Random().Next(size) - 1;

		var sut = new DiamondKata(size);

		// ACT
		var result = sut.Line(lineNr);

		//ASSERT
		var expectedSpace = string.Join(null, Enumerable.Repeat(' ', size - lineNr));

		result.Should().NotBeNull();
		result.Substring(0, size - lineNr).Should().Be(expectedSpace);
	}
}