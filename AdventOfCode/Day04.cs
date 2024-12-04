using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day04 : BaseDay
{
    private string[] _input;

    public Day04()
    {
        ParseInput();
    }

    /// <summary>
    /// Count the number of XMAS apparition
    /// To do that, we go throught the input, and search for every X.
    /// Once one has been spotted, we check the other letter around
    /// </summary>
    /// <returns></returns>
    public override ValueTask<string> Solve_1()
    {
        int counter = 0;
        for (int i = 0; i < _input.Length; i++)
        {
            for (int j = 0; j < _input[i].Length; j++)
            {
                if (_input[i][j] == 'X')
                {
                    // Verticals
                    if (i >= 3 && _input[i - 1][j] == 'M' && _input[i - 2][j] == 'A' && _input[i - 3][j] == 'S')
                    {
                        counter++;
                    }
                    if (i <= _input.Length - 4 && _input[i + 1][j] == 'M' && _input[i + 2][j] == 'A' && _input[i + 3][j] == 'S')
                    {
                        counter++;
                    }
                    // Horizontals
                    if (j >= 3 && _input[i][j - 1] == 'M' && _input[i][j - 2] == 'A' && _input[i][j - 3] == 'S')
                    {
                        counter++;
                    }
                    if (j <= _input[i].Length - 4 && _input[i][j + 1] == 'M' && _input[i][j + 2] == 'A' && _input[i][j + 3] == 'S')
                    {
                        counter++;
                    }
                    // Diagonals
                    if (i >= 3 && j >= 3 && _input[i - 1][j - 1] == 'M' && _input[i - 2][j - 2] == 'A' && _input[i - 3][j - 3] == 'S')
                    {
                        counter++;
                    }
                    if (i <= _input.Length - 4 && j <= _input[i].Length - 4 && _input[i + 1][j + 1] == 'M' && _input[i + 2][j + 2] == 'A' && _input[i + 3][j + 3] == 'S')
                    {
                        counter++;
                    }
                    if (i >= 3 && j <= _input[i].Length - 4 && _input[i - 1][j + 1] == 'M' && _input[i - 2][j + 2] == 'A' && _input[i - 3][j + 3] == 'S')
                    {
                        counter++;
                    }
                    if (i <= _input.Length - 4 && j >= 3 && _input[i + 1][j - 1] == 'M' && _input[i + 2][j - 2] == 'A' && _input[i + 3][j - 3] == 'S')
                    {
                        counter++;
                    }
                }
            }
        }

        return new ValueTask<string>(counter.ToString());
    }

    /// <summary>
    /// Count the number of X-MAS apparition
    /// To do that, we go throught the input, and search for every A.
    /// Once one has been spotted, we check the other letter around (M and S), to be sure they form a cross.
    /// </summary>
    /// <returns></returns>
    public override ValueTask<string> Solve_2()
    {
        int counter = 0;
        for (int i = 1; i < _input.Length - 1; i++) // remove edges
        {
            for (int j = 1; j < _input[i].Length - 1; j++) // remove edges
            {
                if (_input[i][j] == 'A')
                {
                    // Direct Check
                    bool isMasDiagonal1 = (_input[i - 1][j - 1] == 'M' && _input[i + 1][j + 1] == 'S') || (_input[i + 1][j + 1] == 'M' && _input[i - 1][j - 1] == 'S');
                    bool isMasDiagonal2 = (_input[i + 1][j - 1] == 'M' && _input[i - 1][j + 1] == 'S') || (_input[i - 1][j + 1] == 'M' && _input[i + 1][j - 1] == 'S');
                    if (isMasDiagonal1 && isMasDiagonal2)
                    {
                        counter++;
                    }
                }
            }
        }

        return new ValueTask<string>(counter.ToString());
    }

    private void ParseInput()
    {
        _input = File.ReadAllLines(InputFilePath);
    }
}