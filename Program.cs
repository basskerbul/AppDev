using AppDev;

var vs = new Bites(7);
bool bit = vs.GetBit(4);

byte vs1 = new Bites(7);
int vs2 = new Bites(7);
long vs3 = new Bites(7);

string result = "";
for (int i = 0; i < 8; i++)
    result += vs.GetBit(i) ? 1 : 0;
Console.WriteLine(result.Reverse());

vs.SetBit(true, 2);


