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

	[Fact]
	public void DiamondKata_line_m_contains_mth_letter()
	{
		// ARRANGE
		var size = _random.Next(26) + 1;

		var lineNr = _random.Next(size) - 1;

		var sut = new DiamondKata(size);

		// ACT
		var result = sut.Line(lineNr);

		//ASSERT

		result.Should().NotBeNull();
		var letter = result.Substring(size - lineNr).First();

		letter.Should().Be(_txt.Letter(lineNr));
	}

	[Fact]
	public void DiamondKata_line_1_contains_nothing_after_letter()
	{
		// ARRANGE
		var size = _random.Next(26) + 1;

		var sut = new DiamondKata(size);

		// ACT
		var result = sut.Line(1);

		//ASSERT

		result.Should().NotBeNull();

		var afterA = result.Substring(result.IndexOf('A') + 1);

		afterA.Should().BeEmpty();
	}

	[Fact]
	public void DiamondKata_line_m_contains_2m_minus_3_spaces_after_letter()
	{
		// ARRANGE
		var size = _random.Next(26) + 1;

		var lineNr = _random.Next(size - 1) + 2; // line 1 is already covered

		var sut = new DiamondKata(size);

		// ACT
		var result = sut.Line(lineNr);

		//ASSERT

		result.Should().NotBeNull();
		var letterIndex = result.IndexOf(_txt.Letter(lineNr));

		var spaceAfterLetter = result.Substring(letterIndex + 1);

		var length = 2 * lineNr - 3;

		spaceAfterLetter.Prefix(length).Should().Be(_txt.Space(length));
	}

	[Fact]
	public void DiamondKata_line_m_contains_mth_letter_at_the_end()
	{
		// ARRANGE
		var size = _random.Next(26) + 1;

		var lineNr = _random.Next(size - 1) + 2; // line 1 is already covered

		var sut = new DiamondKata(size);

		// ACT
		var result = sut.Line(lineNr);

		//ASSERT
		result.Should().NotBeNullOrEmpty();
		result[^1].Should().Be(_txt.Letter(lineNr));
	}

	[Fact]
	public void DiamondKata_of_size_n_line_m_length_is_n_plus_m_minus_1()
	{
		// ARRANGE
		var size = _random.Next(26) + 1;

		var lineNr = _random.Next(size) + 1;

		var sut = new DiamondKata(size);

		// ACT
		var result = sut.Line(lineNr);

		//ASSERT
		result.Should().NotBeNullOrEmpty();
		result.Length.Should().Be(size + lineNr - 1);
	}

	[Fact]
	public void DiamondKata_of_size_n_line_m_and_2n_minus_m_are_the_same()
	{
		// ARRANGE
		var size = _random.Next(26) + 1;

		var lineNr = _random.Next(size) + 1;

		var sut = new DiamondKata(size);

		// ACT
		var mthLine = sut.Line(lineNr);

		var _2nMinusMthLine = sut.Line(2 * size - lineNr);

		//ASSERT
		mthLine.Should().NotBeNullOrEmpty();
		_2nMinusMthLine.Should().NotBeNullOrEmpty();
		mthLine.Should().BeEquivalentTo(_2nMinusMthLine);
	}

}