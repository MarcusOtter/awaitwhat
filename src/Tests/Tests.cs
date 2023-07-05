namespace Tests;

// TODO: Add more tests eventually

public class Tests
{
	[Test]
	[TestCase("oasijdfaosidf")]
	public void InvalidTimeSpan_Throws(string s)
	{
		Assert.ThrowsAsync<ArgumentException>(async () => await s);
	}
	
	[Test]
	[TestCase("1 second and 7 milliseconds")]
	public void ValidTimeSpan_DoesNotThrow(string s)
	{
		Assert.DoesNotThrowAsync(async () => await s);
	}
}
