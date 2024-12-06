namespace AdventOfCode;

public class Day06 : BaseDay
{
    private string[] _input;
    private IntVector2 _startingPosition;

    public enum Direction
    {
        None = 0,
        North = 1,
        East = 2,
        South = 4,
        West = 8
    }

    public Day06()
    {
        ParseInput();
    }

    public override ValueTask<string> Solve_1()
    {
        HashSet<IntVector2> visited = new();
        IntVector2 currentPosition = _startingPosition;
        Direction currentDirection = Direction.North;

        // Console.WriteLine($"Starting position: {_startingPosition}");
        while (currentPosition.x >= 0 && currentPosition.x < _input.Length && currentPosition.y >= 0 && currentPosition.y < _input[currentPosition.x].Length)
        {
            visited.Add(currentPosition);
            currentPosition = Move(currentPosition, ref currentDirection);
            // Console.WriteLine($"Current position: {currentPosition}");
        }
        return new ValueTask<string>(visited.Count.ToString());
    }

    public override ValueTask<string> Solve_2() => throw new NotImplementedException();

    private void ParseInput()
    {
        _input = File.ReadAllLines(InputFilePath);

        // get the starting position (when char is '^') (Not Optimized)
        for (int i = 0; i < _input.Length; i++)
        {
            if (_input[i].Contains('^'))
            {
                _startingPosition = new(i, _input[i].IndexOf('^'));
                break;
            }
        }
    }

    private IntVector2 Move(IntVector2 position, ref Direction direction)
    {
        IntVector2 positionInFront = direction switch
        {
            Direction.North => new(position.x - 1, position.y),
            Direction.East => new(position.x, position.y + 1),
            Direction.South => new(position.x + 1, position.y),
            Direction.West => new(position.x, position.y - 1),
            _ => throw new NotImplementedException()
        };
        if (positionInFront.x >= 0
            && positionInFront.x < _input.Length
            && positionInFront.y >= 0
            && positionInFront.y < _input[positionInFront.x].Length
            && _input[positionInFront.x][positionInFront.y] == '#')
        {
            // Shift the direction from current position
            direction = GetDirectionClockwise(direction);
            return Move(position, ref direction);
        }
        else
        {
            return positionInFront;
        }
    }

    private static Direction GetDirectionClockwise(Direction direction)
    {
        return direction switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new NotImplementedException()
        };
    }

}