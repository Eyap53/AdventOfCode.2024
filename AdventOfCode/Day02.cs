using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode;

public class Day02 : BaseDay
{
    private int[][] _input;

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

    public override ValueTask<string> Solve_2()
    {
        int counter = 0;

        for (int i = 0; i < _input.Length; i++)
        {
            if (IsSafe(_input[i]))
            {
                counter++;
            }
            else
            {
                // bruteforce test by removing
                for (int j = 0; j < _input[i].Length; j++)
                {
                    int[] newLine = _input[i].Where((_, index) => index != j).ToArray();
                    if (IsSafe(newLine))
                    {
                        counter++;
                        break;
                    }
                }
            }
        }

        return new(counter.ToString());
    }

    private void ParseInput()
    {
        string[] lines = File.ReadAllLines(InputFilePath);

        _input = lines.Select(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToArray();
    }

    /// <summary>
    /// A line is safe if :
    /// - The levels are either all increasing or all decreasing.
    /// - Any two adjacent levels differ by at least one and at most three.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    private bool IsSafe(int[] line)
    {
        bool isIncreasing = line[0] < line[1];
        for (int i = 0; i < line.Length - 1; i++)
        {
            int difference = line[i + 1] - line[i];
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