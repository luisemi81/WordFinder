using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Models
{
    public class WordFinder
    {
        private readonly string[] arrayMatrix;
        private readonly int matrixRows;
        private readonly int matrixCols;

        // columns to rows
        private readonly List<string> verticalLines;

        public WordFinder(IEnumerable<string> matrix)
        {
            arrayMatrix = matrix.ToArray();
            matrixRows = arrayMatrix.Length; //get row count
            matrixCols = arrayMatrix[0].Length; //get col count

            // cols to rows to can find
            verticalLines = new List<string>(matrixCols);
            for (int col = 0; col < matrixCols; col++)
            {
                var column = new char[matrixRows];

                for (int row = 0; row < matrixRows; row++)
                    column[row] = arrayMatrix[row][col];

                verticalLines.Add(new string(column));
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            // Get words without duplicates
            var wordSet = new HashSet<string>(wordstream.Distinct(), StringComparer.OrdinalIgnoreCase);

            // Dictionary to have word count
            var wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in wordSet)
            {
                int count = 0;

                // find word in rows
                foreach (var row in arrayMatrix)
                    count += GetWordCount(row, word);

                // find word in cols
                foreach (var col in verticalLines)
                    count += GetWordCount(col, word);

                // if the word was found, save it into the dictionary
                if (count > 0)
                    wordCounts[word] = count;
            }

            // Find the 10 most common words, sorted in descending order and then alphabetically.
            return wordCounts.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(10).Select(x => x.Key);
        }

        private int GetWordCount(string text, string word)
        {
            int count = 0;
            int index = 0;

            //Find word into the text
            while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++; 
                index += word.Length;
            }

            return count;
        }
    }
}
