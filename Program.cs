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
