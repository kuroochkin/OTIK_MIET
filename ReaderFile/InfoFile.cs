using System.Text;

namespace ReaderFile;

public class InfoFile
{
	public string FilePath { get; set; } = null!;

	public Dictionary<char, int> charFrequencies = new();

	public int TotalCharacters { get; set; }

	public double TotalInformation { get; set; }

	public InfoFile(string filePath)
	{
		FilePath = filePath;
		TotalInformation = 0;
	}

	public void CharacterCouting()
	{
		string content = File.ReadAllText(FilePath);
		TotalCharacters = content.Length;

		PrintInfo.PrintCountCharacters(TotalCharacters);
	}

	public void FrequencyCouting()
	{
		string content = File.ReadAllText(FilePath, Encoding.UTF8);

		foreach (char c in content)
		{
			if (charFrequencies.ContainsKey(c))
				charFrequencies[c]++;
			else
				charFrequencies[c] = 1;
		}

		var sortedAlphabetically = charFrequencies.OrderBy(pair => pair.Key);
		var sortedByFrequency = charFrequencies.OrderByDescending(pair => pair.Value);

		Console.WriteLine("Таблица символов (отсортированная по алфавиту):");
		PrintInfo.PrintCharacterTable(sortedAlphabetically);

		Console.WriteLine("\nТаблица символов (отсортированная по убыванию частоты):");
		PrintInfo.PrintCharacterTable(sortedByFrequency);
	}

	// Расчет вероятностей, количества информации и суммарной информации
	public void InformationCouting()
	{
		foreach (var pair in charFrequencies)
		{
			double probability = (double)pair.Value / TotalCharacters;
			double information = -Math.Log2(probability);
			TotalInformation += information;
			Console.WriteLine($"\nСимвол: {pair.Key}, Вероятность: {probability}, Количество информации: {information} бит");
		}

		double totalInformationBytes = TotalInformation / 8;
		Console.WriteLine($"\nСуммарное количество информации в битах: {TotalInformation}");
		Console.WriteLine($"Суммарное количество информации в байтах: {totalInformationBytes}");
	}
}

