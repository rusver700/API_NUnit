using System.Diagnostics.CodeAnalysis;

namespace API_Oprecoes_TestesUnitarios
{
    [ExcludeFromCodeCoverage]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Ignore("Ignore test")]

        public void Test1()
        {
            Assert.Pass();
        }
    }
}
