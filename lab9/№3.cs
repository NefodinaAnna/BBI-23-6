//using ProtoBuf;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using System.Xml.Serialization;

//[ProtoContract]
//[ProtoInclude(10, typeof(SkierWoman))]
//[ProtoInclude(11, typeof(SkierMan))]
//[XmlInclude(typeof(SkierWoman))]
//[XmlInclude(typeof(SkierMan))]
//[Serializable]
//public class Sportsman
//{
//    [XmlAttribute]
//    [ProtoMember(1)]
//    protected string name;
//    [XmlAttribute]
//    [ProtoMember(2)]
//    protected int result;

//    public string Name
//    {
//        get => name;
//        set => name = value;
//    }
//    public int Result
//    {
//        get => result;
//        set => result = value;
//    }

//    public Sportsman() { }
//    public Sportsman(string name, int result)
//    {
//        this.name = name;
//        this.result = result;
//    }
//    public override string ToString()
//    {
//        return $"результат: {result} имя: {name} ";
//    }
//    public static Sportsman[] Merge(Sportsman[] m1, Sportsman[] m2)
//    {
//        Sportsman[] new_list = new Sportsman[m1.Length + m2.Length];
//        for (int i = 0; i < m1.Length; i++)
//        {
//            new_list[i] = m1[i];
//        }
//        for (int i = 0; i < m2.Length; i++)
//        {
//            new_list[i + m1.Length] = m2[i];
//        }
//        return new_list;

//    }
//}

//[ProtoContract]
//[Serializable]
//public class SkierWoman : Sportsman
//{
//    public SkierWoman() { }
//    public SkierWoman(string name, int result) : base(name, result)
//    { }
//}

//[ProtoContract]
//[Serializable]
//public class SkierMan : Sportsman
//{
//    public SkierMan() { }
//    public SkierMan(string name, int result) : base(name, result)
//    {
//    }
//}

//public class Program
//{
//    static Sportsman[] Sort(Sportsman[] list)
//    {
//        for (int i = 0; i < list.Length; i++)
//        {
//            for (int j = i; j < list.Length; j++)
//                if (list[i].Result < list[j].Result)
//                {
//                    Sportsman person_now = list[j];
//                    list[j] = list[i];
//                    list[i] = person_now;
//                }
//        }
//        return list;
//    }
//    public static void Main(string[] args)
//    {
//        Sportsman[] onegroup_sw = new Sportsman[] { new SkierWoman("Маша", 100), new SkierWoman("Катя", 50), new SkierWoman("Марина", 150), new SkierWoman("Саша", 100), new SkierWoman("Алекса", 98) };
//        Sportsman[] twogroup_sw = new Sportsman[] { new SkierWoman("Инна", 101), new SkierWoman("Надя", 56), new SkierWoman("Юля", 140), new SkierWoman("Элла", 110), new SkierWoman("Виола", 99) };
//        Sportsman[] onegroup_sm = new Sportsman[] { new SkierMan("Вадим", 112), new SkierMan("Олег", 87), new SkierMan("Витя", 140), new SkierMan("Дима", 110), new SkierMan("Антон", 199) };
//        Sportsman[] twogroup_sm = new Sportsman[] { new SkierMan("Саша", 105), new SkierMan("Вова", 56), new SkierMan("Эндрю", 137), new SkierMan("Артур", 111), new SkierMan("Егор", 200) };
//        Sort(onegroup_sw);
//        Sort(twogroup_sw);
//        Sort(onegroup_sm);
//        Sort(twogroup_sm);
//        Sportsman[] women = Sportsman.Merge(onegroup_sw, twogroup_sw);
//        Sort(women);
//        Sportsman[] men = Sportsman.Merge(onegroup_sm, twogroup_sm);
//        Sort(men);
//        Sportsman[] allpeople = Sportsman.Merge(women, men);
//        Sort(allpeople);

//        string path = @"C:\Users\Анна\Desktop\лб 9";
//        string folder = "Files_for_task3";
//        path = Path.Combine(path, folder);
//        if (!Directory.Exists(path))
//        {
//            Directory.CreateDirectory(path);
//        }
//        BinaryFile<Sportsman[]> test1 = new BinaryFile<Sportsman[]>();

//        Console.WriteLine("WOMEN BIN");
//        string file1 = "taskSkierWomen.bin";
//        file1 = Path.Combine(path, file1);

//        if (!System.IO.File.Exists(file1))
//        {
//            test1.Serialize(women, file1);
//        }
//        else
//        {
//            var f1 = test1.Deserialize(file1);
//            foreach (Sportsman s in f1)
//            {
//                Console.WriteLine(s);
//            }
//        }

//        Console.WriteLine("MEN BIN");
//        string file2 = "taskSkierMan.bin";
//        file2 = Path.Combine(path, file2);

//        if (!System.IO.File.Exists(file2))
//        {
//            test1.Serialize(men, file2);
//        }
//        else
//        {
//            var f2 = test1.Deserialize(file2);
//            foreach (Sportsman s in f2)
//            {
//                Console.WriteLine(s);
//            }
//        }

//        Console.WriteLine("ALLPEOPLE BIN");
//        string file3 = "taskSkier.bin";
//        file3 = Path.Combine(path, file3);

//        if (!System.IO.File.Exists(file3))
//        {
//            test1.Serialize(allpeople, file3);
//        }
//        else
//        {
//            var f3 = test1.Deserialize(file3);
//            foreach (Sportsman s in f3)
//            {
//                Console.WriteLine(s);
//            }
//        }


//        JSONfile<Sportsman[]> test2 = new JSONfile<Sportsman[]>();

//        Console.WriteLine("WOMEN JSON");
//        string file11 = "taskSkierWomen.json";
//        file11 = Path.Combine(path, file11);

//        if (!System.IO.File.Exists(file11))
//        {
//            test2.Serialize(women, file11);
//        }
//        else
//        {
//            var f11 = test2.Deserialize(file11);
//            foreach (Sportsman s in f11)
//            {
//                Console.WriteLine(s);
//            }
//        }

//        Console.WriteLine("MEN JSON");
//        string file22 = "taskSkierMan.json";
//        file22 = Path.Combine(path, file22);

//        if (!System.IO.File.Exists(file22))
//        {
//            test2.Serialize(men, file22);
//        }
//        else
//        {
//            var f22 = test2.Deserialize(file22);
//            foreach (Sportsman s in f22)
//            {
//                Console.WriteLine(s);
//            }
//        }

//        Console.WriteLine("ALLPEOPLE JSON");
//        string file33 = "taskSkier.json";
//        file33 = Path.Combine(path, file33);

//        if (!System.IO.File.Exists(file33))
//        {
//            test2.Serialize(allpeople, file33);
//        }
//        else
//        {
//            var f33 = test2.Deserialize(file33);
//            foreach (Sportsman s in f33)
//            {
//                Console.WriteLine(s);
//            }
//        }

//        XMLfile<Sportsman[]> test3 = new XMLfile<Sportsman[]>();

//        Console.WriteLine("WOMEN XML");
//        string file111 = "taskSkierWomen.xml";
//        file111 = Path.Combine(path, file111);

//        if (!System.IO.File.Exists(file111))
//        {
//            test3.Serialize(women, file111);
//        }
//        else
//        {
//            var f111 = test3.Deserialize(file111);
//            foreach (Sportsman s in f111)
//            {
//                Console.WriteLine(s);
//            }
//        }

//        Console.WriteLine("MEN XML");
//        string file222 = "taskSkierMan.xml";
//        file222 = Path.Combine(path, file222);

//        if (!System.IO.File.Exists(file222))
//        {
//            test3.Serialize(men, file222);
//        }
//        else
//        {
//            var f222 = test3.Deserialize(file222);
//            foreach (Sportsman s in f222)
//            {
//                Console.WriteLine(s);
//            }
//        }

//        Console.WriteLine("ALLPEOPLE XML");
//        string file333 = "taskSkier.xml";
//        file333 = Path.Combine(path, file333);

//        if (!System.IO.File.Exists(file333))
//        {
//            test3.Serialize(allpeople, file333);
//        }
//        else
//        {
//            var f333 = test3.Deserialize(file333);
//            foreach (Sportsman s in f333)
//            {
//                Console.WriteLine(s);
//            }
//        }
//    }
//}