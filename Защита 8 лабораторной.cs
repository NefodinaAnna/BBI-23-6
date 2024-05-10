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
class Task_9 : Task
{
	private Dictionary<string, int> rate;
	private Dictionary<string, string> decode;
	private int AmountOfWordsToEncode;
	private char[] Codes = new char[] { '#', '@', '&', '^', '~' };
	public Task_9(string text, int AmountOfWordsToEncode = 1) : base(text)
	{
		this.AmountOfWordsToEncode = Math.Min(AmountOfWordsToEncode, 5);
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

			decode.TryAdd(Codes[i].ToString(), toEncode);
			parsed_text = parsed_text.Replace(toEncode, Codes[i].ToString());
		}
	}

	public Dictionary<string, string> getDecoder()
	{
		return decode;
	}
}
struct Dict
{
	private string[] key_;
	private string[] value_;
	public Dict(Dictionary<string, string> d)
	{
		key_ = d.Keys.ToArray();
		value_ = d.Values.ToArray();
	}
	public string Value(string k)
	{
		for(int i = 0; i < key_.Length; i++)
		{
			if (key_[i] == k)
			{
				return value_[i];
			}
		}
		return "";
	}
	public bool ContainsKey(string k)
	{
		if (key_.Contains(k)) { return true; }
		else { return false; }
	}
	public string[] Keys() { return key_; }
}
class Task_12 : Task
{
	// decode: [то, на что меняем] = то, что меняем  --- (Task_10)

	// encode: [то, что меняем] = то, на что меняем  !!!
	//  "aaa" - "x"
	//  "bb"  - "y"
	//  "c"   - "z"
	// "aaa bb c" -> {"aaa", "bb", "c"} -> {"x", "y", "z"} 

	private Dict encode;
	private string[] encoded_words;
	public Task_12(string text, Dictionary<string, string> encode) : base(text)
	{
		this.encode = new Dict(encode);
		ParseText();
	}
	
	protected override void ParseText()
	{
		encoded_words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < encoded_words.Length; ++i)
		{
			if (encode.ContainsKey(encoded_words[i]))
			{
				encoded_words[i] = encode.Value(encoded_words[i]);
			}
		}
		parsed_text = string.Join(" ", encoded_words);
	}

	public override string ToString()
	{
		string res;
		res = "Text:\n" + text + "\nEncoded text:\n" + parsed_text + "\nTable, which was used to encode:\n";
		foreach (var k in encode.Keys())
		{
			res += k + " -> " + encode.Value(k) + "\n";
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

class Program
{
	public static void Main()
	{
		int number = 9;

		Console.WriteLine($"TASK #{number++}");
		Task_9 task9 = new Task_9("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот,состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий", 5);
		Console.WriteLine(task9);

		number = 12;
		Console.WriteLine($"TASK #{number++}");
		Task_12 task12 = new Task_12(task9.getParsedText(), task9.getDecoder());
		Console.WriteLine(task12);
	}
}