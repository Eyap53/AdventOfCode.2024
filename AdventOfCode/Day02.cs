using System.Collections.Generic;

namespace AdventOfCode;

public class Day02 : BaseDay
{
    private string[] _input;

    public Day02()
    {
        ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        int counter = 0;

        for (int i = 0; i < _input.Length; i++)
        {
            if (IsSafe(_input[i]))
            {
                counter++;
            }
        }

        return new(counter.ToString());
    }

    public override ValueTask<string> Solve_2() => throw new NotImplementedException();

    private void ParseInput()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    /// <summary>
    /// A line is safe if :
    /// - The levels are either all increasing or all decreasing.
    /// - Any two adjacent levels differ by at least one and at most three.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    private bool IsSafe(string line)
    {
        int[] lineParts = line.Split(" ").Select(Int32.Parse).ToArray();

        bool isIncreasing = lineParts[0] < lineParts[1];
        for (int i = 0; i < lineParts.Length - 1; i++)
        {
            int difference = lineParts[i + 1] - lineParts[i];
            if (isIncreasing && difference < 0 || !isIncreasing && difference > 0)
            {
                return false;
            }
            if (Math.Abs(difference) == 0 || Math.Abs(difference) > 3)
            {
                return false;
            }
        }
        return true;
    }
}