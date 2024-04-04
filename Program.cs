// Number 1
using System;
abstract class student
{

	public student(string sur, int m, int s)
	{
		surname = sur;
		mark = m;
		skipped = s;
		if (mark == 2)
		{
			pos += 1;
		}
	}
    public int Mark
	{
		get => mark;
		set => mark = value;
	}
    public int Skipped
	{
		get => skipped;
	}
	public string Surname
	{
		get => surname;
		set => surname = value;
	}
	private string surname;
	private int mark;
	private int skipped;
	protected int subject;
	protected int Subject
	{
		get => subject;
		set => subject = value;
	}
	protected static int pos;
    public int Pos
    {
        get => pos;
        set => pos = value;
    }
}
class Mstudent : student
{
	public Mstudent(string sur, int m, int s)
	: base(sur, m, s)
	{
		Subject = 0;
	}
}
class Istudent : student
{
	public Istudent(string sur, int m, int s)
	: base(sur, m, s)
	{
		Subject = 1;
	}

}
class Program
{
	static void sort(student[] x, ref int len)
	{
		int index = 1;
		int nextInd = index + 1;

		while (index < len)
		{
			if (x[index].Skipped > x[index - 1].Skipped)
			{
				index = nextInd;
				nextInd++;
			}
			else
			{
				student temp = x[index - 1];
				x[index - 1] = x[index];
				x[index] = temp;
				index--;
				if (index == 0)
				{
					index = nextInd;
					nextInd++;
				}
			}
		}
	}

	static void Read(int n, student[] students, ref int cntBad, int subject)
	{
		for (int i = 0; i < n; i++)
		{
			int mark, skipped;
			string surname;
			Console.WriteLine($"Введите фамилию {i + 1}-го студента");
			surname = Console.ReadLine();
			Console.WriteLine($"Введите оценку {i + 1}-го студента");
			mark = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine($"Введите количество занятий, пропущенных {i + 1}-м студентом");
			skipped = Convert.ToInt32(Console.ReadLine());

			if (subject == 0) students[i] = new Mstudent(surname, mark, skipped);
			else students[i] = new Istudent(surname, mark, skipped);

			if (mark == 2)
			{
				cntBad++;
			}
		}
	}
	static void MakeBad(ref int n, ref int cntBad, student[] BadStudents, student[] students)
	{
		int pos = 0;
		for (int i = 0; i < n; i++)
		{
			if (students[i].Mark == 2)
			{
				BadStudents[pos] = students[i];
				pos++;
			}
		}
		sort(BadStudents, ref cntBad);
	}
	static void Main(string[] args)
	{
		Console.WriteLine("Введите количество студентов по математике");
		int n = Convert.ToInt32(Console.ReadLine());
		student[] Mstudents = new student[n];
		int cntM = 0;
		Read(n, Mstudents, ref cntM, 0);

		Console.WriteLine("Введите количество студентов по информатике");
		int k = Convert.ToInt32(Console.ReadLine());
		student[] Istudents = new student[k];
		int cntI = 0;
		Read(k, Istudents, ref cntI, 1);

		student[] badMStudents = new Mstudent[cntM];

		MakeBad(ref n, ref cntM, badMStudents, Mstudents);

		Console.WriteLine("Студенты математики");
		for (int i = 0; i < cntM; i++)
		{
			Console.WriteLine($"{badMStudents[i].Surname}, кол-во пропущенных занятий: {badMStudents[i].Skipped}");
		}

		student[] badIStudents = new Istudent[cntI];

		MakeBad(ref k, ref cntI, badIStudents, Istudents);


		Console.WriteLine("Студенты информатики");
		for (int i = 0; i < cntI; i++)
		{
			Console.WriteLine($"{badIStudents[i].Surname}, кол-во пропущенных занятий: {badIStudents[i].Skipped}");
		}
	}
}

// Number 2
//using System;
//abstract class Discipline
//{
//	public string discipline_;
//	protected string discipline
//	{
//		get => discipline_;
//		set => discipline_ = value;
//	}
//}
//class LongJump : Discipline
//{
//	public LongJump()
//	{
//		discipline = "Long jump";
//	}
//}
//class HighJump : Discipline
//{
//	public HighJump()
//	{
//		discipline = "High jump";
//	}
//}
//struct Sportsman
//{

//	public Sportsman(string s, Discipline d, double r1, double r2, double r3)
//	{
//		surname = s;
//		TypeOfSport = d;
//		res1 = r1;
//		res2 = r2;
//		res3 = r3;
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
//	public string getSurname()
//	{
//		return surname;
//	}
//	public double getFirst()
//	{
//		return res1;
//	}
//	public double getSecond()
//	{
//		return res2;
//	}
//	public double getThird()
//	{
//		return res3;
//	}
//	private Discipline TypeOfSport;
//	private string surname;
//	private double res1, res2, res3;
//}
//class Program
//{
//	static void Read(int n, Sportsman[] sportsmen, Discipline d)
//	{
//		Console.WriteLine($"Введите спортсменов, учавствующих в дисциплине {d}");
//		for (int i = 0; i < n; i++)
//		{
//			double res1, res2, res3;
//			string surname;
//			Console.WriteLine($"Введите фамилию {i + 1}-го спортсмена");
//			surname = Console.ReadLine();
//			Console.WriteLine($"Введите первый результат {i + 1}-го спортсмена");
//			res1 = Convert.ToDouble(Console.ReadLine());
//			Console.WriteLine($"Введите второй результат {i + 1}-го спортсмена");
//			res2 = Convert.ToDouble(Console.ReadLine());
//			Console.WriteLine($"Введите третий результат {i + 1}-го спортсмена");
//			res3 = Convert.ToDouble(Console.ReadLine());
//			sportsmen[i] = new Sportsman(surname, d, res1, res2, res3);
//		}
//	}
//	static void Print(Sportsman[] sportsmen, int n)
//	{
//		for (int i = 0; i < n; i++)
//		{
//			Console.WriteLine($"{sportsmen[i].getSurname()}, лучший результат: {sportsmen[i].getMax()} м");
//		}
//	}
//	static void Main(string[] args)
//	{
//		Console.WriteLine("Введите количество спортсменов, учавствующих в дисциплине Long Jump");
//		int n = Convert.ToInt32(Console.ReadLine());
//		Sportsman[] LongJumpers = new Sportsman[n];
//		Read(n, LongJumpers, new LongJump());
//		Console.WriteLine("Прыжки в длину");
//		Print(LongJumpers, n);

//		Console.WriteLine("Введите количество спортсменов, учавствующих в дисциплине High Jump");
//		int k = Convert.ToInt32(Console.ReadLine());
//		Sportsman[] HighJumpers = new Sportsman[k];
//		Read(n, HighJumpers, new LongJump());
//		Console.WriteLine("Прыжки в высоту");
//		Print(HighJumpers, k);
//	}
//}

// Number 3
//using System;
//abstract class Discipline
//{
//    public string discipline_;
//    protected string discipline
//    {
//        get => discipline_;
//        set => discipline_ = value;
//    }
//}
//abstract class Gender
//{
//    public string gender_;
//    protected string gender
//    {
//        get => gender_;
//        set => gender_ = value;
//    }
//}
//class Female : Gender
//{
//    public Female()
//    {
//        gender = "Female";
//    }
//}
//class Male : Gender
//{
//    public Male()
//    {
//        gender = "Male";
//    }
//}
//class Skiing : Discipline
//{
//    public Skiing()
//    {
//        discipline = "Skiing";
//    }
//}
//abstract class Athlete
//{
//    public Athlete(string s, double r, Gender g, Discipline d)
//    {
//        surname = s;
//        res = r;
//        gender_ = g;
//        TypeOfSport = d;
//    }
//    private Gender gender_;
//    public Gender gender { get { return gender_; } }
//    protected Discipline TypeOfSport;
//    public Discipline TypeOfSport_ { get { return TypeOfSport; } }
//    protected string surname;
//    public string surname_ { get { return surname; } }
//    protected double res;
//    public double res_ { get { return res; } }
//    public virtual void Print(int i)
//    {
//        Console.WriteLine($" {i + 1}  {surname}   {res} секунд ");
//    }
//}
//class Skier : Athlete
//{
//    public Skier(string s, double r, Gender g)
//    : base(s, r, g, new Skiing())
//    { }
//}
//class Skier_m : Skier
//{
//    public Skier_m(string s, double r)
//    : base(s, r, new Male())
//    { }
//    public override void Print (int i)
//    {

//        Console.WriteLine($" {i + 1}ый спортсмен  {surname}   {res} секунд ");
//    }
//}
//class Skier_f : Skier
//{
//    public Skier_f(string s, double r)
//    : base(s, r, new Female())
//    { }
//    public override void Print(int i)
//    {

//        Console.WriteLine($" {i + 1}ая спортсменка  {surname}   {res} секунд ");
//    }
//}
//class Program
//{
//    static void sort(Athlete[] x, ref int len)
//    {
//        for (int i = 0; i < len - 1; i++)
//        {
//            for (int k = 0; k < len - 1 - i; k++)
//            {
//                if (x[k].res_ > x[k + 1].res_)
//                {
//                    (x[k], x[k + 1]) = (x[k + 1], x[k]);
//                }
//            }
//        }
//    }
//    static void Read(Athlete[] x, int n, Gender g)
//    {
//        for (int i = 0; i < n; i++)
//        {
//            double res;
//            string surname;
//            Console.WriteLine($"Введите фамилию {i + 1}-го спортсмена");
//            surname = Console.ReadLine();
//            Console.WriteLine($"Введите результат {i + 1}-го спортсмена");
//            res = Convert.ToDouble(Console.ReadLine());
//            if (g.gender_ == "Male")
//            {
//                x[i] = new Skier_m(surname, res);
//            }
//            else
//            {
//                x[i] = new Skier_f(surname, res);
//            }
//        }
//    }
//    static void Print(Athlete[] gr1, int n, string TableName)
//    {
//        Console.WriteLine($"Таблица группы {TableName}");
//        Console.WriteLine("----------------------------------------");
//        Console.WriteLine("|  Место  |   Фамилия   |   Результат  |");
//        Console.WriteLine("----------------------------------------");
//        for (int i = 0; i < n; i++)
//        {
//            gr1[i].Print(i);
//        }
//        Console.WriteLine();
//    }
//    static void Merge(Athlete[] gr1, Athlete[] gr2, int n, int k, Athlete[] skiers)
//    {
//        int pos1 = 0;
//        int pos2 = 0;
//        for (int i = 0; i < n + k; i++)
//        {
//            if (pos1 == n)
//            {
//                skiers[i] = gr2[pos2];
//                pos2++;
//                continue;
//            }
//            if (pos2 == k)
//            {
//                skiers[i] = gr1[pos1];
//                pos1++;
//                continue;
//            }
//            if (gr1[pos1].res_ < gr2[pos2].res_)
//            {
//                skiers[i] = gr1[pos1];
//                pos1++;
//            }
//            else
//            {
//                skiers[i] = gr2[pos2];
//                pos2++;
//            }
//        }
//    }
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Введите количество лыжниц в 1-ой группе");
//        int n = Convert.ToInt32(Console.ReadLine());
//        Skier_f[] f1 = new Skier_f[n];
//        Read(f1, n, new Female());

//        Console.WriteLine("Введите количество лыжниц в 2-ой группе");
//        int k = Convert.ToInt32(Console.ReadLine());
//        Skier_f[] f2 = new Skier_f[k];
//        Read(f2, k, new Female());

//        Console.WriteLine("Введите количество лыжников в 1-ой группе");
//        int p = Convert.ToInt32(Console.ReadLine());
//        Skier_m[] m1 = new Skier_m[p];
//        Read(m1, p, new Male());

//        Console.WriteLine("Введите количество лыжников в 2-ой группе");
//        int d = Convert.ToInt32(Console.ReadLine());
//        Skier_m[] m2 = new Skier_m[d];
//        Read(m2, d, new Male());

//        sort(f1, ref n);
//        sort(f2, ref k);
//        sort(m1, ref p);
//        sort(m2, ref d);

//        Print(f1, n, "Лыжницы-1");
//        Print(f2, k, "Лыжницы-2");
//        Print(m1, p, "Лыжники-1");
//        Print(m2, d, "Лыжники-2");

//        Athlete[] f12 = new Athlete[n + k];
//        Merge(f1, f2, n, k, f12);
//        Print(f12, n + k, "Лыжницы-12");
//        Athlete[] m12 = new Athlete[p + d];
//        Merge(m1, m2, p, d, m12);
//        Print(m12, p + d, "Лыжники-12");

//        Athlete[] all = new Athlete[n + k + p + d];
//        Merge(f12, m12, n + k, p + d, all);
//        Print(all, n + k + p + d, "Лыжники+Лыжницы");
//    }
//}