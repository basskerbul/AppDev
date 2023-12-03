
switch (args[0].ToLower())
{
    case "search":
        Search(args[1], args[2]);
        break;
    case "find":
        FindAndRead(args[1], args[2]);
        break;
}

void Copy(string path, string name)
{
    string file_path = Path.Combine(Directory.GetParent(path).FullName, name);
    if (File.Exists(path))
    {
        using (StreamReader sr = new StreamReader(path))
        {
            using (StreamWriter sw = new StreamWriter(file_path))
            {
                sw.WriteLine(sr.ReadToEnd());
            }
        }
    }
    else
        throw new Exception("invalid path");
}
bool Search(string path, string name)
{
    if (Directory.Exists(path) || File.Exists(path))
    {
        string[] files = Directory.GetFiles(path);
        foreach (string file in files)
        {
            if (File.Exists(file) && Path.GetFileName(file) == name)
            {
                Console.WriteLine("file found");
                return true;
            }
        }
        string[] folders = Directory.GetDirectories(path);
        foreach (string folder in folders)
            Search(folder, name);
        return false;
    }
    else
        return false;
}
void FindAndRead(string path, string text)
{
    if (File.Exists(path))
    {   //алгоритм ищет первое совпадение, добавляет к result все, что идет за совпадением
        //и сравнивает с искомым
        StreamReader sr = new StreamReader(path);
        string? line = sr.ReadLine();
        string? result = "";
        while (line != null && result != text)
        {
            foreach (char text_char in text)
            {
                for(int i = 0; i <=  line.Length; i++)
                {
                    if(text_char == line[i])
                    {
                        result += line[i].ToString();
                        for(int j = i + 1; result.Length < text.Length; j++)
                            result += line[j];
                        if (result == text)
                        {
                            Console.WriteLine(line);
                            sr.Close();
                            break;
                        }
                    }
                }
                if (result == text)
                    break;
            }
        }
    }
    else
        throw new Exception("file not found");
}