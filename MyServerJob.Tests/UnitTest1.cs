namespace MyServerJob.Tests;

using MyServerJob.App;

public class UnitTest1
{
    [Fact]
    public void TestCurrentYearIs2026()
    {
        var now = DateTimeHelper.GetCurrentDateTime();
        Assert.Equal(2026, now.Year);
    }
}
