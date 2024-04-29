using System.Collections.Generic;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Specialized;

abstract class Task
{
    protected string text;
    protected string parsed_text;
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
        this.parsed_text = "";
    }
    protected abstract void ParseText();
}
class Task_1 : Task
{
    private double SumOfNumbers;
    private int count;
    private double rez;

    public double Rez
    {
        get => rez;
        protected set => rez = value;
    }
    [JsonConstructor]
    public Task_1(string text) : base(text)
    {
        SumOfNumbers = 0;
        ParseText();
    }
    protected override void ParseText()
    {
        var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double cur;
        for (int i = 0; i < words.Length; ++i)
        {
            if (double.TryParse(words[i].Trim(new char[] { '.', ',', '!', '-', ':', ';' }), out cur))
            {
                count++;
                SumOfNumbers += cur;
            }
        }
        rez = SumOfNumbers / count;
    }

    public override string ToString()
    {
        return "Text:\n" + text + "\n Sum of integers from text = " + rez.ToString() + "\n";
    }
}
class Task_2 : Task
{
    private string answer = "";
    public string Answer2
    {
        get => answer;
        protected set => answer = value;
    }
    [JsonConstructor]
    public Task_2(string text) : base(text)
    {
        ParseText();
    }
    protected override void ParseText()
    {
        string t = text;
        string[] symb = new string[] { ".", "!", "?", ";" };
        for (int i = 0; i < symb.Length; i++)
        {
            t = t.Replace(symb[i], "$");
        }
        t += " ";
        string[] sent = t.Split("$ ");
        for (int j = 0; j < sent.Length; j++)
        {
            string[] words = sent[j].Split(" ");
            for (int i = 0; i < words.Length / 2; i++)
            {
                string tmp = words[i];
                words[i] = words[words.Length - i - 1];
                words[words.Length - i - 1] = tmp;
            }
            string reverse_predl = String.Join(" ", words);
            if (j != sent.Length - 1)
            {
                reverse_predl += text[reverse_predl.Length + answer.Length] + " ";
            }
            answer += reverse_predl;
        }
    }
    public override string ToString()
    {
        return "Полученный текст:" + "\n" + answer;
    }
}
class JsonIO
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
}
class Program
{
    static void Main()
    {
        string text = "Сегодня 2024 год, в том году был 2023. Когда я родилась был 2005 год, а до 2025 года осталось 0,6 года";
        Task[] tasks = {
            new Task_1(text),
            new Task_2(text)
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\m2312323\Desktop";
        string folderName = "Test";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "task_1.json";
        string fileName2 = "task_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);
        if (!File.Exists(fileName1))
        {
            JsonIO.Write<Task_1>(tasks[0] as Task_1, fileName1);
        }
        else
        {
            var t1 = JsonIO.Read<Task_1>(fileName1);
            Console.WriteLine(t1);
        }
        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task_2>(tasks[1] as Task_2, fileName2);
        }
        else
        {
            var t2 = JsonIO.Read<Task_2>(fileName2);
            Console.WriteLine(t2);
        }

    }
}