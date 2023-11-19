
while (true)
{
    Console.Clear();

    Calculator calculator = new Calculator();
    calculator.MyEventHandler += Calc_MyEventHandler;

    Console.WriteLine("Введите выражение");
    string? user_answer = Console.ReadLine();

    if (user_answer == null || user_answer == "")
        break;

    //отмена последнего действия
    if(user_answer == "back")
        calculator.CancelLastAction();

    string[]? answer_parts = user_answer.Split(" ");

    if (answer_parts.Length < 3)
        throw new InvalidOperationException();

    try
    {
        double number1 = DoubleTryParse(answer_parts[0]);
        double number2 = DoubleTryParse(answer_parts[2]);
        string operation = answer_parts[1];

        switch (operation)
        {
            case "+":
                calculator.Addition(number1, number2);
                break;
            case "-":
                calculator.Subtraction(number1, number2);
                break;
            case "*":
                calculator.Multiplication(number1, number2);
                break;
            case "/":
                calculator.Division(number1, number2);
                break;
            default:
                throw new UnrecognizedOperatorException("Оператор не распознан");
        }
    }
    catch (FormatException) 
    {
        Console.WriteLine("Введенный формат не поддерживается");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

double DoubleTryParse(string input)
{
    try
    {
        double result = double.Parse(input);
        if (result >= 0)
            return result;
        else
        {
            Console.WriteLine("Замена на 0");
            return 0;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Формат не поддерживается");
        return 0;
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
        return 0;
    }
}



static void Calc_MyEventHandler(object? sender, EventArgs e)
{
    if (sender is Calculator)
        Console.WriteLine($"Answer: {((Calculator)sender).Solution}");
}

public interface ICalculator
{
    public double Solution { get; }
    public void Addition(double addend1, double addend2);
    public void Subtraction(double minuend,  double subtrahend);
    public void Multiplication(double multiplicand, double multiplier);
    public void Division(double dividend, double divisor);
    public void CancelLastAction();
    event EventHandler<EventArgs> MyEventHandler;
}

public class CalculatorExeption: Exception
{
    public CalculatorExeption() { }
    public CalculatorExeption(string error): base(error) { }
}

public class DivideByZeroException: CalculatorExeption
{
    public DivideByZeroException() { }
    public DivideByZeroException(string error): base(error) { }
}

public class UnrecognizedOperatorException: Exception
{
    public UnrecognizedOperatorException() { }
    public UnrecognizedOperatorException(string error): base(error) { }
}

public class InvalidOperationException: Exception
{
    public InvalidOperationException() { }
    public InvalidOperationException(string error): base(error) { }
}


public class Calculator : ICalculator
{
    public double Solution { get; set; } = 0;
    private Stack<double> solutions = new Stack<double>();  
    public event EventHandler<EventArgs> MyEventHandler;

    private void PrintResult() => MyEventHandler?.Invoke(this, new EventArgs());

    public void Addition(double addend1, double addend2)
    {
        Solution = addend1 + addend2;
        solutions.Push(Solution);
        PrintResult();
    }

    public void Subtraction(double minuend, double subtrahend)
    {
        Solution = minuend - subtrahend;
        solutions.Push(Solution);
        PrintResult();
    }

    public void Division(double dividend, double divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException("Деление на 0"); 
        else
            Solution = dividend / divisor;
        solutions.Push(Solution);
        PrintResult();
    }

    public void Multiplication(double multiplicand, double multiplier)
    {
        Solution = multiplicand * multiplier;
        solutions.Push(Solution);
        PrintResult();
    }

    public void CancelLastAction()
    {
        if (solutions.Count == 0)
            throw new Exception("Нет действий для отмены");
        else
            Solution = solutions.Pop();
        PrintResult();
    }
}

