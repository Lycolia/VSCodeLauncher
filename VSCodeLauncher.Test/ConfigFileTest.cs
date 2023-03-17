
namespace VSCodeLauncher.Test {
    public class ConfigFileTest {
        [Fact]
        public void Test1() {
            var primeService = new ConfigFile("");
            bool result = primeService.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }
    }
}