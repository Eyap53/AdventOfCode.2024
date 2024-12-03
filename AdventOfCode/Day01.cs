namespace AdventOfCode;

public class Day01 : BaseDay
{
    private List<int> _list1;
    private List<int> _list2;

    public Day01()
    {
        ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        _list1.Sort();
        _list2.Sort();

        int distance = 0;

        for (int i = 0; i < _list1.Count; i++)
        {
            distance += Math.Abs(_list1[i] - _list2[i]);
        }

        return new(distance.ToString());
    }

    /// <summary>
    /// Not Optimized.
    /// </summary>
    public override ValueTask<string> Solve_2()
    {
        int similarityScore = 0;

        for (int i = 0; i < _list1.Count; i++)
        {
            similarityScore += _list1[i] * _list2.Count(x => x == _list1[i]);
        }

        return new(similarityScore.ToString());
    }

    private void ParseInput()
    {
        string[] input = File.ReadAllLines(InputFilePath);
        _list1 = new();
        _list2 = new();

        foreach (var line in input)
        {
            string[] lineParts = line.Split("   ");
            if (lineParts.Length == 2 && int.TryParse(lineParts[0], out int num1) && int.TryParse(lineParts[1], out int num2))
            {
                _list1.Add(num1);
                _list2.Add(num2);
            }
        }
    }
}
