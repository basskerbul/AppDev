List<Action> actList = new List<Action> { Practice1, Practice2 };
doAction(actList);

void Practice1() => Console.WriteLine("method 1");
void Practice2() => Console.WriteLine("method 2");
void doAction(List<Action> action)
{
    foreach(Action act in action) 
        act();
}
/*************/
Calc calc = new Calc();
calc.EHandler += Calc_EHandler;
calc.Sum(15);
calc.RemoteControl();

void Calc_EHandler(object? sender, EventArgs e)
{
    if(sender is Calc)
        Console.WriteLine(((Calc)sender).Result);
}


/*************/
List<taskDel> secondTaskList = new List<taskDel>()
    {
        (message) => Console.WriteLine("first message"),
        (message) => Console.WriteLine("second message")
    };
static void PrintList(List<taskDel> list)
{
    foreach (taskDel item in list)
        item("some text");
}
PrintList(secondTaskList);
/***************/
class Calc: ICalc
{
    private Stack<double> AllResults = new Stack<double>(0);
    public double Result { get; set; } = 0;

    public event EventHandler<EventArgs> EHandler;

    public void RemoteControl()
    {
        while (true)
        {
            Console.WriteLine("Введите действие или exit");
            string? user_answer = Console.ReadLine();
            if (user_answer == "exit" || user_answer == "" || user_answer == null)
                break;
            string[] parse_answer = user_answer.Split(" ");

            try { 
                int x = int.Parse(parse_answer[1]);
                switch (parse_answer[0])
                {
                    case "+":
                        Sum(x);
                        break;
                    case "-":
                        Sub(x);
                        break;
                    case "*":
                        Multy(x);
                        break;
                    case "/":
                        Divide(x);
                        break;
                    case "undo":
                        CanceLast();
                        break;
                    default:
                        Console.WriteLine("Действие не распознано");
                        break;
                }
            }
            catch { throw new Exception("Не удалось распознать данные"); }
        }
    }

    public void Sum(int x)
    {
        Result += x;
        AllResults.Push(Result);
        Print();
    }
    public void Sub(int x)
    {
        Result -= x;
        AllResults.Push(Result);
        Print();
    }
    public void Multy(int x)
    {
        Result *= x;
        AllResults.Push(Result);
        Print();
    }
    public void Divide(int x)
    {
        Result /= x;
        AllResults.Push(Result);
        Print();
    }
    public void CanceLast()
    {
        if (AllResults.TryPop(out double result))
        {
            Result = result;
            Print();
        }
    }

    private void Print() => EHandler?.Invoke(this, new EventArgs());
}

delegate void taskDel(string message);

interface ICalc
{
    double Result { get; }
    void Sum(int x);
    void Sub(int x);
    void Multy(int x);
    void Divide(int x);
    void CanceLast();
    event EventHandler<EventArgs> EHandler;
}





