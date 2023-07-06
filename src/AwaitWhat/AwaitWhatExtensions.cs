using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TimeSpanParserUtil;

// ReSharper disable once CheckNamespace
namespace System
{
	public static class AwaitWhatExtensions
	{
		private static readonly Stopwatch Stopwatch = new Stopwatch();

		
		// Lol https://www.youtube.com/watch?v=ileC_qyLdD4
		public static TaskAwaiter GetAwaiter(this string s)
		{
			return Task.Delay(s.ToTimeSpan()).GetAwaiter();
		}

		private static TimeSpan ToTimeSpan(this string s)
		{
			Stopwatch.Restart();
			var success = TimeSpanParser.TryParse(s, out var parsed);
			if (!success) throw new ArgumentException("Invalid time span", nameof(s));
			Stopwatch.Stop();
			
			// Offset any delays from TimeSpanParser
			var result = parsed - Stopwatch.Elapsed;
			return result <= TimeSpan.Zero ? TimeSpan.Zero : result;
		}
	}
}
