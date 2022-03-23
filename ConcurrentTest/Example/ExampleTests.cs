using Xunit;
using ConcurrentLib;

namespace ConcurrentTest
{
    public class ExampleTests
    {
        [Fact]
        public void ExampleTest()
        {
            ConcurrentLib.ExampleClass example = new ConcurrentLib.ExampleClass();
            Assert.Equal(4, example.Calculate(2));
        }
    }
}