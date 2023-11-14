//Написать программу-калькулятор, вычисляющую выражения вида a + b, a - b, a / b, a * b,
//введенные из командной строки, и выводящую результат выполнения на экран.

while(true)
{
    Calculator.PrintResult();
}

static class Calculator
{
    public static void PrintResult()
    {
        Console.WriteLine("Введите выражение");
        string? user_answer = Console.ReadLine();
        if(user_answer != null && user_answer != "")
        {
            string[] chars = user_answer.Split(" ");
            try
            {
                int a = int.Parse(chars[0]);
                int b = int.Parse(chars[2]);
                switch (chars[1])
                {
                    case "+":
                        Console.WriteLine($"{a + b}");
                        break;
                    case "-":
                        Console.WriteLine($"{a - b}");
                        break;
                    case "*":
                        Console.WriteLine($"{a * b}");
                        break;
                    case "/":
                        if (b == 0) 
                            Console.WriteLine("Нельзя делить на 0");
                        else
                            Console.WriteLine($"{a / b}");
                        break;
                    default:
                        Console.WriteLine("Оператор не распознан");
                        break;
                }
            }
            catch { throw new Exception("Данные не распознаны"); }
        } 
    }
}