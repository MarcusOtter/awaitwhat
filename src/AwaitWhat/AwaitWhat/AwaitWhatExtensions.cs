using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TimeSpanParserUtil;

// ReSharper disable once CheckNamespace
namespace System
{
	public static class AwaitWhatExtensions
	{
		// Lol https://www.youtube.com/watch?v=ileC_qyLdD4
		public static TaskAwaiter GetAwaiter(this string s)
		{
			return Task.Delay(s.ToTimeSpan()).GetAwaiter();
		}

		private static TimeSpan ToTimeSpan(this string s)
		{
			var success = TimeSpanParser.TryParse(s, out var result);
			if (!success) throw new ArgumentException("Invalid time span", nameof(s));
			return result;
		}
	}
}
