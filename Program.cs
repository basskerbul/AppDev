//Дан двумерный массив.
//Отсортировать данные в нем по возрастанию.
//Вывести результат на печать.


int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
Sorting(ref a);
Printing(a);
Console.ReadKey();

static void Sorting(ref int[,] some_array)
{
    int[] intermediate_result = new int[some_array.Length];

    for(int line = 0; line < some_array.Length / some_array.GetLength(0); line++)
    {
        for(int j = 0; j < some_array.GetLength(0); j++)
            intermediate_result[line * some_array.GetLength(0) + j] = some_array[line, j];
    }

    for(int i = 0; i < intermediate_result.Length; i++)
    {
        for(int j = 0; j < intermediate_result.Length - 1; j++)
        {
            if (intermediate_result[j] > intermediate_result[j + 1])
            {
                int box = intermediate_result[j];
                intermediate_result[j] = intermediate_result[j + 1];
                intermediate_result[j + 1] = box;
            }
        }
    }

    for (int line = 0; line < some_array.Length / some_array.GetLength(0); line++)
    {
        for (int j = 0; j < some_array.GetLength(0); j++)
            some_array[line, j] = intermediate_result[line * some_array.GetLength(0) + j];
    }
}
static void Printing(int[,] some_array)
{
    int layer = some_array.Length / some_array.GetLength(0);
    int index = some_array.GetLength(0);

    for(int i = 0; i < layer; i++)
    {
        for (int k = 0; k < index; k++)
            Console.Write($"{some_array[i, k]}  ");
        Console.Write("\n");
    }
}
