namespace WordFinder
{
    public class Program
    {
        static void Main(string[] args)
        {
            var matrix = new List<string>
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };

            var wordstream = new List<string> { "chill", "cold", "wind", "heat", "wind", "cold" };

            var finder = new Models.WordFinder(matrix);
            var result = finder.Find(wordstream);

            Console.WriteLine("Words found:");
            foreach (var word in result)
                Console.WriteLine(word);
        }
    }
}
