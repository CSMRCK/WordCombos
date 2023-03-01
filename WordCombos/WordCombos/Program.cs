namespace WordCombos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"..\..\..\6letters (1).txt";
            string[] words = File.ReadAllLines(filePath);

            var combinations = from firstPart in words
                               from secondPart in words
                               where firstPart.Length + secondPart.Length == 6
                               select new { firstPart, secondPart };

            foreach (var combination in combinations)
            {
                string resultWord = combination.firstPart + combination.secondPart;
                if(words.Contains(resultWord))
                {
                    Console.WriteLine($"{combination.firstPart}+{combination.secondPart}={resultWord}");
                }
            }

        }
    }
}