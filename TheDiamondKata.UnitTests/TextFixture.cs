
namespace TheDiamondKata.UnitTests
{
	internal class TextFixture
	{
		public string Space(int length)
			=> string.Join(null, Enumerable.Repeat(' ', length));

		public char Letter(int nr) => (char)('A' + nr - 1);
	}
}
