using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
abstract class Task
{
	protected string text;
	protected string parsed_text;
	public Task(string text)
	{
		this.text = text;
		this.parsed_text = "";
	}
	protected abstract void ParseText();
	protected double CountPersent(int number, int total) // все одинаковые
	{
		return (double)number / (double)total * 100;
	}
	public virtual string getText()
	{
		return text;
	}
	public virtual string getParsedText()
	{
		return parsed_text;
	}
}
class Task_8 : Task
{

	private int string_width;
	public Task_8(string text, int stringWidth = 50) : base(text)
	{
		string_width = stringWidth;
		ParseText();
	}
	public override string ToString()
	{
		return "Text:\n" + text + "\nParsed text:\n" + parsed_text;
	}
	protected override void ParseText()
	{
		string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		// "Andrew,", "hello,", ...
		// parsed_text = "Andrew,\nhello"
		int curLength = 0;
		for (int i = 0; i < words.Length;)
		{
			curLength = 0;
			while (i < words.Length && curLength + words[i].Length <= string_width)
			{
				curLength += words[i].Length + 1;
				parsed_text += words[i] + " ";
				++i;
			}
			while (curLength <= string_width)
			{
				parsed_text += " ";
				++curLength;
			}
			parsed_text += "\n";
		}
	}
}
class Task_9 : Task
{
	private Dictionary<string, int> rate;
	private Dictionary<string, string> decode;
	private int AmountOfWordsToEncode;
	public Task_9(string text, int AmountOfWordsToEncode = 1) : base(text)
	{
		this.AmountOfWordsToEncode = AmountOfWordsToEncode;
		rate = new Dictionary<string, int>();
		decode = new Dictionary<string, string>();
		parsed_text = text;
		ParseText();
	}
	public override string ToString()
	{
		string res;
		res = "Text:\n" + text + "\nEncoded text:\n" + parsed_text + "\nTable to decode:\n";
		foreach (var pair in decode)
		{
			res += pair.Key + " -> " + pair.Value + "\n";
		}
		res += "\n";
		return res;
	}
	// "abc abc aaaa"
	// ab = 2, bc = 2, aa = 2
	// 1: 0c 0c aaaa
	// 2: 0c 0c aaaa

	private void countRate()
	{
		rate.Clear();
		for (int i = 0; i + 1 < parsed_text.Length;)
		{
			if (!char.IsLetter(parsed_text[i]) || !char.IsLetter(parsed_text[i + 1]))
			{
				i += 1;
				continue;
			}

			if (rate.ContainsKey(parsed_text.Substring(i, 2)))
			{
				rate[parsed_text.Substring(i, 2)] += 1;
			}
			else
			{
				rate.TryAdd(parsed_text.Substring(i, 2), 1);
			}

			if (i + 2 < parsed_text.Length && parsed_text.Substring(i, 2) == parsed_text.Substring(i + 1, 2))
			{
				i += 2;
			}
			else
			{
				i += 1;
			}
		}
	}
	protected override void ParseText()
	{
		for (int i = 0; i < AmountOfWordsToEncode; ++i)
		{
			countRate();

			string toEncode = "";
			int rating = 0;
			foreach (var pair in rate)
			{
				if (pair.Value > rating)
				{
					toEncode = pair.Key;
					rating = pair.Value;
				}
			}

			if (toEncode == "") break;

			decode.TryAdd(i.ToString(), toEncode);
			parsed_text = parsed_text.Replace(toEncode, i.ToString());
		}
	}

	public Dictionary<string, string> getDecoder()
	{
		return decode;
	}
}

class Task_10 : Task
{
	protected Dictionary<string, string> decode;
	public Task_10(string encodedText, Dictionary<string, string> decode) : base(encodedText)
	{
		parsed_text = encodedText;
		this.decode = decode;
		ParseText();
	}
	protected override void ParseText()
	{
		// aa -> 1
		// pair = {"1", "aa"}
		foreach (KeyValuePair<string, string> pair in decode)
		{
			parsed_text = parsed_text.Replace(pair.Key, pair.Value);
		}
	}
	public override string ToString()
	{
		string res;
		res = "Encoded text:\n" + text + "\nDecoded text:\n" + parsed_text + "\nTable, which was used to decode:\n";
		foreach (var pair in decode)
		{
			res += pair.Key + " -> " + pair.Value + "\n";
		}
		res += "\n";
		return res;
	}
}

class Task_12 : Task
{
	// decode: [то, на что меняем] = то, что меняем  --- (Task_10)

	// encode: [то, что меняем] = то, на что меняем  !!!
	//  "aaa" - "x"
	//  "bb"  - "y"
	//  "c"   - "z"
	// "aaa bb c" -> {"aaa", "bb", "c"} -> {"x", "y", "z"} 

	private Dictionary<string, string> encode;
	private string[] encoded_words;
	public Task_12(string text, Dictionary<string, string> encode) : base(text)
	{
		this.encode = encode;
		ParseText();
	}
	protected override void ParseText()
	{
		encoded_words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < encoded_words.Length; ++i)
		{
			if (encode.ContainsKey(encoded_words[i]))
			{
				encoded_words[i] = encode[encoded_words[i]];
			}
		}
		parsed_text = string.Join(" ", encoded_words);
	}

	public override string ToString()
	{
		string res;
		res = "Text:\n" + text + "\nEncoded text:\n" + parsed_text + "\nTable, which was used to encode:\n";
		foreach (var pair in encode)
		{
			res += pair.Key + " -> " + pair.Value + "\n";
		}
		res += "\nResult array of encoded words = {";
		for (int i = 0; i < encoded_words.Length; ++i)
		{
			res += "\"" + encoded_words[i] + "\"";

			if (i != encoded_words.Length - 1) res += ", ";
		}
		res += "}\n";
		return res;
	}
}

class Task_13 : Task
{
	private Dictionary<char, int> rate;
	private int total;

	public Task_13(string text) : base(text)
	{
		rate = new Dictionary<char, int>();
		ParseText();
	}
	protected override void ParseText()
	{
		// words[i] = i-th string
		// words[i][j] = j-th char from i-th string 
		// char.IsLetter('a') = true
		// char.IsLetter('1') = false
		var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		total = 0;
		for (int i = 0; i < words.Length; ++i)
		{
			if (char.IsLetter(words[i][0]))
			{
				++total;
				if (rate.ContainsKey(words[i][0]))
				{
					rate[words[i][0]] += 1;
				}
				else
				{
					rate.TryAdd(words[i][0], 1);
				}
			}
		}
	}

	public override string ToString()
	{
		string res = "Text:\n" + text + "\nFrequency, depends on first letter:\n";
		foreach (var pair in rate)
		{
			res +=
			   char.ToString(pair.Key)
			 + " = "
			 + $"{CountPersent(pair.Value, total)}" + "%\n";
		}
		return res;
	}
}

class Task_15 : Task
{
	private int SumOfNumbers;
	public Task_15(string text) : base(text)
	{
		SumOfNumbers = 0;
		ParseText();
	}
	protected override void ParseText()
	{
		var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		int cur;
		for (int i = 0; i < words.Length; ++i)
		{
			if (int.TryParse(words[i].Trim(new char[] { '.', ',', '!', '-', ':', ';' }), out cur))
			{
				SumOfNumbers += cur;
			}
		}
	}

	public override string ToString()
	{
		return "Text:\n" + text + "\n Sum of integers from text = " + SumOfNumbers.ToString() + "\n";
	}
}


class Program
{
	public static void Main()
	{
		//Task_8 task8 = new Task_8("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот,состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий", 10);
		//Console.WriteLine(task8);

		//Task_9 task9 = new Task_9("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот,состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий", 10);
		//Console.WriteLine(task9);
		//Task_10 task10 = new Task_10(task9.getParsedText(), task9.getDecoder());
		//Console.Write(task10);
		//if (task9.getText() == task10.getParsedText())
		//{
		//	Console.WriteLine("OK! Text was encoded and decoded successfuly:)\n\n");
		//}
		//else
		//{
		//	Console.WriteLine("OH NO! Text wasn't encoded and decoded successfuly:(\n\n");
		//}

		//Task_12 task12 = new Task_12(task9.getParsedText(), task9.getDecoder());
		//Console.WriteLine(task12);


		//Task_13 task13 = new Task_13("Андрей, Алена, Александр, Филип, Фрося, Ольга, Миранда");
		//Console.WriteLine(task13);

		Task_15 task15 = new Task_15("Today is the 23th of November and we are in 1945. We are to close to the great victory! Yesterday we got 15 gektars forward - sounds good");
		Console.WriteLine(task15);
	}
}