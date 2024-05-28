//using ProtoBuf;

//[ProtoContract]
//[Serializable]
//public class Participant
//{
//    [ProtoMember(1)]
//    private string name;
//    [ProtoMember(2)]
//    private int id;
//    [ProtoMember(3)]
//    private int best_result;
//    [ProtoMember(4)]
//    private int flag = 1;

//    public string Name
//    {
//        get => name;
//        set => name = value;
//    }
//    public int Id
//    {
//        get => id;
//        set => id = value;
//    }
//    public int Best_result
//    {
//        get => best_result;
//        set => best_result = value;
//    }
//    public int Flag
//    {
//        get => flag;
//        set => flag = value;
//    }

//    public Participant()
//    {
//    }

//    public Participant(string name, int id, int best_result, int flag = 1)
//    {
//        this.name = name;
//        this.id = id;
//        this.best_result = best_result;
//    }

//    public override string ToString()
//    {
//        return $"результат: {best_result} имя: {name} идентификационный номер {id} ";
//    }

//    public int SECOND_RES
//    {
//        set
//        {
//            if (value > best_result) best_result = value;
//        }
//    }

//    public void Diskfalif()
//    {
//        flag = 0;
//    }

//    public static void Sort(Participant[] list)
//    {
//        for (int i = 1; i < list.Length; i++)
//        {
//            int k = list[i].best_result;
//            Participant now = list[i];
//            int j = i - 1;

//            while (j >= 0 && list[j].best_result < k)
//            {
//                list[j + 1] = list[j];
//                j--;
//            }
//            list[j + 1] = now;
//        }
//    }

//}

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Participant[] peoplelist = new Participant[] { new Participant("Маша", 1, 125), new Participant("Миша", 2, 123), new Participant("Саша", 3, 12), new Participant("Вова", 4, 400), new Participant("Егор", 5, 600) };
//        Participant.Sort(peoplelist);

//        string path = @"C:\Users\ADM\Desktop";
//        string folder = "Files_for_task1";
//        path = Path.Combine(path, folder);
//        if (!Directory.Exists(path))
//        {
//            Directory.CreateDirectory(path);
//        }

//        Console.WriteLine("binary");
//        Console.WriteLine();
//        string file1 = "task1.bin";
//        file1 = Path.Combine(path, file1);

//        BinaryFile<Participant[]> test1 = new BinaryFile<Participant[]>();
//        if (!System.IO.File.Exists(file1))
//        {
//            test1.Serialize(peoplelist, file1);
//        }
//        else
//        {
//            var f1 = test1.Deserialize(file1);
//            foreach (Participant p in f1)
//            {
//                Console.WriteLine(p);
//            }
//        }

//        Console.WriteLine("\n" + "JSON" + "\n");
//        string file2 = "task1.json";
//        file2 = Path.Combine(path, file2);

//        JSONfile<Participant[]> test2 = new JSONfile<Participant[]>();
//        if (!System.IO.File.Exists(file2))
//        {
//            test2.Serialize(peoplelist, file2);
//        }
//        else
//        {
//            var f2 = test2.Deserialize(file2);
//            foreach (Participant p in f2)
//            {
//                Console.WriteLine(p);
//            }
//        }

//        Console.WriteLine("\n" + "XML" + "\n");
//        string file3 = "task1.xml";
//        file3 = Path.Combine(path, file3);

//        XMLfile<Participant[]> test3 = new XMLfile<Participant[]>();
//        if (!System.IO.File.Exists(file3))
//        {
//            test3.Serialize(peoplelist, file3);
//        }
//        else
//        {
//            var f3 = test3.Deserialize(file3);
//            foreach (Participant p in f3)
//            {
//                Console.WriteLine(p);
//            }
//        }
//    }
//}