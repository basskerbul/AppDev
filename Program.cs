// Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.
// Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его
// части два числа равных по сумме первому.

int number = 104;
int[] numbers = { 28, 57, 63, 3, 17, 98, 13 };

PrintAmount(number, numbers); //Вывод 28 + 63 + 13 = 104

static void PrintAmount(int number, int[] setNumbers)
{
    int[] result = new int[] { 0, 0, 0 };
    for(int i = 0; i < setNumbers.Length; i++)
    {
        result[0] = setNumbers[i];
        for(int j = i + 1; j < setNumbers.Length; j++)
        {
            result[1] = setNumbers[j];
            for( int k = j + 1; k < setNumbers.Length; k++)
            {
                result[2] = setNumbers[k];
                int sum = 0;
                foreach (int n in result)
                    sum += n;
                if (sum == number)
                    Console.WriteLine($"{result[0]} + {result[1]} + {result[2]} = {number}");
            }
        }
    }
}