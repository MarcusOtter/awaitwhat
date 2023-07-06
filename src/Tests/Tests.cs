using System.Diagnostics;

namespace Tests;

public class Tests
{
	// Windows system clock has a resolution of ~15.625 milliseconds
	private const double MaxDifferenceInMs = 16;

	[Test]
	[TestCase("oasijdfaosidf")]
	[TestCase("")]
	[TestCase("1")]
	public void InvalidTimeSpan_Throws(string s)
	{
		Assert.ThrowsAsync<ArgumentException>(async () => await s);
	}
	
	[Test]
	[TestCase("1 second and 7 milliseconds")]
	[TestCase("0.016667 minutes")]
	[TestCase("0.1m2s")]
	[TestCase("1.2s and 10ms")]
	public void ValidTimeSpan_DoesNotThrow(string s)
	{
		Assert.DoesNotThrowAsync(async () => await s);
	}

	[Test]
	[TestCase("30 milliseconds", 30)]
	[TestCase("51 milliseconds", 51)]
	[TestCase("0.381 seconds", 381)]
	[TestCase("1s", 1_000)]
	[TestCase("15ms", 15)]
	[TestCase("0ms", 0)]
	[TestCase("0.001 hours", 3_600)]
	[TestCase("-50ms", 0)]
	[TestCase("0.08333333 minutes", 5_000)]
	[Parallelizable(ParallelScope.All)]
	public async Task Delay_IsWithinBounds(string s, long expectedMs)
	{
		List<long> timings = new();
		var sw = new Stopwatch();

		// Run tests for about 5 seconds regardless of how much time
		var iterations = 5_000 / Math.Max(expectedMs, 1);
		for (var i = 0; i < iterations; i++)
		{
			sw.Restart();
			await s;
			sw.Stop();
			
			timings.Add(sw.ElapsedMilliseconds);
		}
		
		var avg = timings.Average();
		Console.WriteLine(avg);
		
		// Anything below 16ms typically takes about 16ms because of system clock resolution
		Assert.LessOrEqual(avg, expectedMs + MaxDifferenceInMs);
		Assert.GreaterOrEqual(avg, expectedMs - MaxDifferenceInMs);
	}
}
