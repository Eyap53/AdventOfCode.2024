using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day03 : BaseDay
{
    private string _input;

    public Day03()
    {
        ParseInput();
    }

    /// <summary>
    /// Use a regex to detect all mul(xx,xx) in _input and multiply the numbers inside
    /// </summary>
    /// <returns></returns>
    public override ValueTask<string> Solve_1()
    {
        int result = 0;
        string pattern = @"mul\((?<num1>\d+),(?<num2>\d+)\)";
        Regex regex = new(pattern);
        MatchCollection matches = regex.Matches(_input);

        foreach (Match match in matches)
        {
            int num1 = int.Parse(match.Groups["num1"].Value);
            int num2 = int.Parse(match.Groups["num2"].Value);
            result += num1 * num2;
        }

        return new ValueTask<string>(result.ToString());
    }


    /// <summary>
    /// Same but with do and don't
    /// </summary>
    /// <returns></returns>
    public override ValueTask<string> Solve_2()
    {
        int result = 0;
        string pattern = @"mul\((?<num1>\d+),(?<num2>\d+)\)|do\(\)|don't\(\)";
        Regex regex = new(pattern);
        MatchCollection matches = regex.Matches(_input);

        bool flag = true;

        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                flag = true;
            }
            else if (match.Value == "don't()")
            {
                flag = false;
            }
            else
            {
                if (flag)
                {
                    int num1 = int.Parse(match.Groups["num1"].Value);
                    int num2 = int.Parse(match.Groups["num2"].Value);
                    result += num1 * num2;
                }
            }
        }

        return new ValueTask<string>(result.ToString());
    }

    private void ParseInput()
    {
        _input = File.ReadAllText(InputFilePath);
    }
}