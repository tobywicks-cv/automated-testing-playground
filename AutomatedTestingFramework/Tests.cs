namespace AutomatedTestingFramework;

public class UnitTest1
{
    [Fact]
    public void DemoTest()
    {
        Assert.Equal(1, 1);
    }
    
    [Fact]
    public async Task DemoVerifyTest()
    {
        await Verifier.Verify(new
        {
            Name = "Test",
            Number = 123
        });
    }
}