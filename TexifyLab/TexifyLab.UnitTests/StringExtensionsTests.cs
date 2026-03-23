namespace TexifyLab.UnitTests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase("Nemo", ";", "N;e;m;o")]
        [TestCase("ABC", "-", "A-B-C")]
        [TestCase("A", ";", "A")]
        public void Intersperse_ShouldReturnCorrectFormattedString(string input, string separator, string expected)
        {
            // Act
            var result = input.Intersperse(separator);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Intersperse_WhenInputIsEmpty_ShouldReturnOriginalInput()
        {
            string input = string.Empty;
            var result = input.Intersperse(";");
            Assert.That(result, Is.EqualTo(input));
        }

        [Test]
        public void Intersperse_WhenSeparatorIsNull_ShouldThrowArgumentNullException()
        {
            string input = "Nemo";
            // NUnit dùng Assert.Throws để check exception
            Assert.Throws<ArgumentNullException>(() => input.Intersperse(null!));
        }

        [Test]
        public void Intersperse_ExampleTest()
        {
            string input = "Nemo";

            Assert.That(input, Is.EqualTo(input + ""));
        }
    }
}
