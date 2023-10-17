/* Доработайте приложение генеалогического дерева таким образом чтобы программа выводила 
 * на экран близких родственников (жену/мужа). Продумайте способ более красивого вывода с 
 * использованием горизонтальных и вертикальных черточек.
(реализация с урока есть в FamilyMember_task3.cs, но будет лучше если вы напишите свою) */

using System.Collections.Generic;

public enum Gender
{ Female, Male }

public class FamilyMember
{
    private string first_name;
    private string last_name;
    private Gender gender;
    private DateTime birthday;
    
    private FamilyMember? mother;
    private FamilyMember? father;

    public string FirstName { get { return first_name; } set { first_name = value; } }
    public string LastName { get { return last_name; } set { last_name = value; } }
    public Gender Gender { get {  return gender; } set {  gender = value; } }
    public DateTime Birthday { get; set; }
    public FamilyMember? Mother { get; set; }
    public FamilyMember? Father { get; set; }

    public void PrintInfo()
    {
        Output.PrintTextsInBorder("BASIC INFORMATION", $"First name: {first_name}", 
            $"Last Name: {last_name}", $"Gender: {gender.ToString()}", $"Birthday is: {birthday.ToString()}",
            father != null ? $"Father name is {father.FirstName.ToString()} {father.LastName.ToString()}" : "There is not father",
            mother != null ? $"Mother name is {mother.FirstName.ToString()} {mother.LastName.ToString()}" : "There is not father");
    }
}
public class AbultFamilyMember: FamilyMember
{
    private FamilyMember? partner;
    private bool areThereChild;

    public FamilyMember? Partner { get; set; }
    public bool AreThereChild { get; set; }
    
    public void PrintPersonalInfo()
    {
        PrintInfo();
        Output.PrintTextsInBorder("ADDITIONAL INFORMATION",
            partner == null ? "He/She doesn't have a partner" : 
            $"Partner is {partner.FirstName.ToString()} {partner.LastName.ToString()}",
            areThereChild ? "He/She have child" : "He/She doesn't have child");
    }
}

public static class Output
{
    private static char border_up_right = '┐';
    private static char border_up_left = '┌';
    private static char border_down_right = '┘';
    private static char border_down_left = '└';
    private static char border_horizontal = '─';
    private static char border_vertical = '│';
    private static int string_lenght = 20;

    private static string CreateBorder(char border_right, char border_left, char border_line)
    {
        string border = "";
        border += border_left;
        for (int i = 1; i < string_lenght; i++)
            border += border_line;
        border += border_right;
        return border;
    }

    public static void PrintTextsInBorder(params string[] info)
    {
        string border = CreateBorder(border_up_right, border_up_left, border_horizontal);
        Console.WriteLine(border);
        for(int i = 0; i < info.Length; i++)
        {
            string line = $"{border_vertical} {info[i]}";
            if (line.Length >= string_lenght) Console.WriteLine($"{line} {border_vertical}");
            else
            {
                for (int j = line.Length; j < string_lenght; j++)
                {
                    line += " ";
                }
                Console.WriteLine(line + border_vertical);
            }
        }
        border = CreateBorder(border_down_right, border_down_left, border_horizontal);
        Console.WriteLine(border);
    }
}