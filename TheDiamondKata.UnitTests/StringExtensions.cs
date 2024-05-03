namespace TheDiamondKata.UnitTests
{
	public static class StringExtensions
	{
		public static string Prefix(this string txt, int length)
			=> txt.Substring(0, length);
	}
}
