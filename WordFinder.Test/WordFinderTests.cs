namespace WordFinder.Test
{
    public class Tests
    {
        [Test]
        public void FindsWordsInMatrix()
        {
            var matrix = new List<string>
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };

            var words = new List<string> { "chill", "cold", "wind", "heat", "wind", "cold" };

            var finder = new WordFinder.Models.WordFinder(matrix);
            var result = finder.Find(words);

            CollectionAssert.AreEquivalent(new[] { "chill", "cold", "wind" }, result);
        }

        [Test]
        public void ReturnsEmptyWhenNoWordsFound()
        {
            var matrix = new List<string>
            {
                "aaaa",
                "bbbb",
                "cccc"
            };

            var words = new List<string> { "chill", "cold" };
            var finder = new WordFinder.Models.WordFinder(matrix);

            var result = finder.Find(words);

            Assert.IsEmpty(result);
        }
    }
}