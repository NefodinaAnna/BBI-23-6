//using ProtoBuf;
//using System;
//using System.Xml.Serialization;

//[ProtoContract]
//[Serializable]
//public class Sportsman
//{
//	[XmlAttribute]
//	[ProtoMember(1)]
//	private string surname;
//	[XmlAttribute]
//	[ProtoMember(2)]
//	private double res1;
//	[XmlAttribute]
//	[ProtoMember(3)]
//	private double res2;
//	[XmlAttribute]
//	[ProtoMember(4)]
//	private double res3;

//	public Sportsman() { }
//	public Sportsman(string surname, double res1, double res2, double res3)
//	{
//		this.surname = surname;
//		this.res1 = res1;
//		this.res2 = res2;
//		this.res3 = res3;
//	}
//	public double getMax()
//	{
//		if (res1 >= res2 && res1 >= res3)
//		{
//			return res1;
//		}
//		else if (res2 >= res1 && res2 >= res3)
//		{
//			return res2;
//		}
//		else
//		{
//			return res3;
//		}
//	}

//	public string Surname
//	{
//		get => surname;
//		set => surname = value;
//	}

//	public double Res1
//	{
//		get => res1;
//		set => res1 = value;
//	}

//	public double Res2
//	{
//		get => res2;
//		set => res2 = value;
//	}

//	public double Res3
//	{
//		get => res3;
//		set => res3 = value;
//	}

//	public override string ToString()
//	{
//		return $"{Surname}, результат: {getMax()}";
//	}
//}
//class Program
//{
//	static void Main(string[] args)
//	{
//		Sportsman[] sportsmen = new Sportsman[5] { new Sportsman("Сидоров", 10, 5, 7), new Sportsman("Петров", 1, 5, 6), new Sportsman("Иванов", 1, 5, 6), new Sportsman("Романов", 1, 5, 6), new Sportsman("Долгопупс", 1, 5, 6) };

//		string path = @"C:\Users\Анна\Desktop\лб 9";
//		string folder = "Files_for_task3";
//		path = Path.Combine(path, folder);
//		if (!Directory.Exists(path))
//		{
//			Directory.CreateDirectory(path);
//		}
//		BinaryFile<Sportsman[]> test1 = new BinaryFile<Sportsman[]>();

//		Console.WriteLine("BIN");
//		string file1 = "task2.bin";
//		file1 = Path.Combine(path, file1);

//		if (!System.IO.File.Exists(file1))
//		{
//			test1.Serialize(sportsmen, file1);
//		}
//		else
//		{
//			var f1 = test1.Deserialize(file1);
//			foreach (Sportsman s in f1)
//			{
//				Console.WriteLine(s);
//			}
//		}

//		JSONfile<Sportsman[]> test2 = new JSONfile<Sportsman[]>();
//		Console.WriteLine("JSON");
//		string file11 = "task2.json";
//		file11 = Path.Combine(path, file11);

//		if (!System.IO.File.Exists(file11))
//		{
//			test2.Serialize(sportsmen, file11);
//		}
//		else
//		{
//			var f11 = test2.Deserialize(file11);
//			foreach (Sportsman s in f11)
//			{
//				Console.WriteLine(s);
//			}
//		}

//		XMLfile<Sportsman[]> test3 = new XMLfile<Sportsman[]>();
//		Console.WriteLine("XML");
//		string file111 = "task2.xml";
//		file111 = Path.Combine(path, file111);

//		if (!System.IO.File.Exists(file111))
//		{
//			test3.Serialize(sportsmen, file111);
//		}
//		else
//		{
//			var f111 = test3.Deserialize(file111);
//			foreach (Sportsman s in f111)
//			{
//				Console.WriteLine(s);
//			}
//		}
//	}
//}

