using System.Diagnostics;

namespace WordCombos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //No need in try/cathes for file opening since this stuff is just for us :)

            string inputFilePath = @"..\..\..\6letters (1).txt";
            string outputFilePath = @"..\..\..\Result.txt";
            string[] words = File.ReadAllLines(inputFilePath);

            var combinations = from firstPart in words
                               from secondPart in words
                               where firstPart.Length + secondPart.Length == 6
                               select new { firstPart, secondPart };

            using (StreamWriter writer = File.CreateText(outputFilePath))
            {
                foreach (var combination in combinations.Distinct())
                {
                    string resultWord = combination.firstPart + combination.secondPart;
                    if (words.Contains(resultWord))
                    {
                        writer.WriteLine($"{combination.firstPart}+{combination.secondPart}={resultWord}");
                    }
                }
            }

            //Sorry for a Linux/IOS guys, don`t think this code will work
            Process.Start("notepad.exe", outputFilePath);
        }
    }
}