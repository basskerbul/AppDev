int[,] labyrynth1 = new int[,]
{
/*y*/{1, 1, 1, 1, 1, 1, 1 }, 
    {1, 0, 0, 0, 0, 0, 1 },
    {1, 0, 1, 1, 1, 0, 1 },
    {0, 0, 0, 0, 1, 0, 2 },
    {1, 1, 0, 0, 1, 1, 1 },
    {1, 1, 1, 1, 1, 1, 1 },
    {1, 1, 1, 1, 1, 1, 1 }
    /*x*/
};

int[,] labirynth2 = new int[,]
{
{1, 1, 1, 1, 1, 1, 1 },
{1, 0, 0, 0, 0, 0, 1 },
{1, 0, 1, 1, 1, 0, 1 },
{0, 0, 0, 0, 1, 0, 2 },
{1, 1, 0, 0, 1, 1, 1 },
{1, 1, 1, 0, 1, 1, 1 },
{1, 1, 1, 2, 1, 1, 1 }
};


static List<int> ReturnNonRepeatingList(List<int> list)
{
    List<int> result = new List<int>();

    foreach(int item in list)
    {
        if (!list.Contains(item))
            result.Add(item);
    }
    return result;
}
static List<int> ReturnNonRepeatingList2(List<int> list)
{
    return list.Distinct().ToList();
}

static void SortingRepetitions(ref List<int> list)
{
    Dictionary<int, int> ValueCount = new Dictionary<int, int>();
    foreach(int item in list)
    {
        if (ValueCount.ContainsKey(item))
            ValueCount[item]++;
        else
            ValueCount.Add(item, 1);
    }
    ValueCount = ValueCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    list.Clear();
    foreach (int item in ValueCount.Keys)
        list.Add(item);
}
static void SortingRepetitions2(ref List<int> list)
{

    Dictionary<int, int> ValueCount = new Dictionary<int, int>();
    foreach (int item in list)
    {
        if (ValueCount.ContainsKey(item))
            ValueCount[item]++;
        else
            ValueCount.Add(item, 1);
    }
    ValueCount = ValueCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
    list.Clear();
    for (int i = ValueCount.Count - 1; i >= 0; i--)
        list.Add(i);
}

static Dictionary<int,int>? FingWayOut(int[,] labyrinth)
{
    int x = 1; int y = 3;
    Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
    stack.Push(new (y, x));
    while(stack.Count > 0)
    {
        Tuple<int, int> item = stack.Pop();
        if (labyrinth[item.Item1, item.Item2] == 2)
        {
            x = item.Item1;
            y = item.Item2;
            Dictionary<int, int> pointXpointY = new Dictionary<int, int>()
            { { x, y } };
            return pointXpointY;
        }
        labyrinth[item.Item1, item.Item2] = 1;
        if(item.Item2 >= 0 && labyrinth[item.Item1, item.Item2 - 1] != 1)
            stack.Push(new(item.Item1, item.Item2 - 1));
        if(item.Item2 + 1 < labyrinth.GetLength(1) && labyrinth[item.Item1, item.Item2 + 1] != 1)
            stack.Push(new(item.Item1, item.Item2 + 1));
        if(item.Item1 >= 0 && labyrinth[item.Item1 - 1, item.Item2] != 1)
            stack.Push(new(item.Item1 - 1, item.Item2));
        if(item.Item1 + 1 < labyrinth.GetLength(0) && labyrinth[item.Item1 + 1, item.Item2] != 1)
            stack.Push(new(item.Item1 + 1, item.Item2));
    }
    return null;
}
static int HasExit(int startI, int startJ, int[,] labirynth)
{
    Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
    stack.Push(new(startI,startJ));
    int pathCounter = 0;
    while (stack.Count > 0)
    {
        Tuple<int, int> item = stack.Pop();
        if (labirynth[item.Item1, item.Item2] == 2)
            pathCounter += 1;
        labirynth[item.Item1, item.Item2] = 1;
        if (item.Item2 >= 0 && labirynth[item.Item1, item.Item2 - 1] != 1)
            stack.Push(new(item.Item1, item.Item2 - 1));
        if (item.Item2 + 1 < labirynth.GetLength(1) && labirynth[item.Item1, item.Item2 + 1] != 1)
            stack.Push(new(item.Item1, item.Item2 + 1));
        if (item.Item1 >= 0 && labirynth[item.Item1 - 1, item.Item2] != 1)
            stack.Push(new(item.Item1 - 1, item.Item2));
        if (item.Item1 + 1 < labirynth.GetLength(0) && labirynth[item.Item1 + 1, item.Item2] != 1)
            stack.Push(new(item.Item1 + 1, item.Item2));
    }
    return pathCounter;
}
