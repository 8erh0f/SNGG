namespace SNGG.Services.Tests
{
    [TestClass]
    public class CheckGuessServiceTests
    {
        private ICheckGuessService? _checkQuessService;

        [TestMethod]
        public void ShouldCheckGuessed()
        {
            _checkQuessService = new CheckGuessService();
            var actualNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "4" } };
            var quessedNumbers = new Dictionary<int, string> { { 1, "9" }, { 2, "5" }, { 3, "8" }, { 4, "1" } };
            var actualResult = _checkQuessService.CheckGuessed(quessedNumbers, actualNumbers);
            var expectedResult = new Tuple<int, int>(0, 1);
            Assert.AreEqual(actualResult.Item1, expectedResult.Item1);
            Assert.AreEqual(actualResult.Item2, expectedResult.Item2);

            actualNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "4" } };
            quessedNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "5" }, { 3, "8" }, { 4, "1" } };
            actualResult = _checkQuessService.CheckGuessed(quessedNumbers, actualNumbers);
            expectedResult = new Tuple<int, int>(1, 0);
            Assert.AreEqual(actualResult.Item1, expectedResult.Item1);
            Assert.AreEqual(actualResult.Item2, expectedResult.Item2);

            actualNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "4" } };
            quessedNumbers = new Dictionary<int, string> { { 1, "0" }, { 2, "5" }, { 3, "8" }, { 4, "7" } };
            actualResult = _checkQuessService.CheckGuessed(quessedNumbers, actualNumbers);
            expectedResult = new Tuple<int, int>(0, 0);
            Assert.AreEqual(actualResult.Item1, expectedResult.Item1);
            Assert.AreEqual(actualResult.Item2, expectedResult.Item2);

            actualNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "1" } };
            quessedNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "1" } };
            actualResult = _checkQuessService.CheckGuessed(quessedNumbers, actualNumbers);
            expectedResult = new Tuple<int, int>(4, 0);
            Assert.AreEqual(actualResult.Item1, expectedResult.Item1);
            Assert.AreEqual(actualResult.Item2, expectedResult.Item2);

            actualNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "1" }, { 5, "1" } };
            quessedNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "1" }, { 5, "1" } };
            actualResult = _checkQuessService.CheckGuessed(quessedNumbers, actualNumbers);
            expectedResult = new Tuple<int, int>(5, 0);
            Assert.AreEqual(actualResult.Item1, expectedResult.Item1);
            Assert.AreEqual(actualResult.Item2, expectedResult.Item2);

            actualNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "1" }, { 5, "1" } };
            quessedNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "1" }, { 3, "1" }, { 4, "0" }, { 5, "2" } };
            actualResult = _checkQuessService.CheckGuessed(quessedNumbers, actualNumbers);
            expectedResult = new Tuple<int, int>(1, 3);
            Assert.AreEqual(actualResult.Item1, expectedResult.Item1);
            Assert.AreEqual(actualResult.Item2, expectedResult.Item2);

            actualNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "1" } };
            quessedNumbers = new Dictionary<int, string> { { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "1" }, { 5, "4" } };
            actualResult = _checkQuessService.CheckGuessed(quessedNumbers, actualNumbers);
            expectedResult = new Tuple<int, int>(2, 1);
            Assert.AreEqual(actualResult.Item1, expectedResult.Item1);
            Assert.AreEqual(actualResult.Item2, expectedResult.Item2);
        }
    }
}