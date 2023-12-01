using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new();

            Console.Write($"Results part 1: {p.CalibrationValuePart1()}\nResults part 2: {p.CalibrationValuePart2()}");
        }

        private int CalibrationValuePart1()
        {
            string[] lines = ReadInputData().Split("\n");

            int sum = 0;

            foreach (string line in lines)
            {
                string[] nums = FindNumbers(line);
                sum += CalibrationValue(nums);
            }

            return sum;
        }

        private int CalibrationValuePart2()
        {
            string input = ReadInputData().Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3e")
            .Replace("four", "4")
            .Replace("five", "5e")
            .Replace("six", "6")
            .Replace("seven", "7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e");

            string[] lines = input.Split('\n');
            int sum = 0;

            foreach (string line in lines)
            {
                string[] nums = FindNumbers(line);
                sum += CalibrationValue(nums);
            }

            return sum;
        }

        public string ReadInputData() => File.ReadAllText("....\\inputDay1.txt");

        private string[] FindNumbers(string input) => Regex.Matches(input, "\\d").Select(m => m.Value).ToArray();

        private int CalibrationValue(string[] nums) => int.Parse(nums[0] + nums[^1]);
    }
}
