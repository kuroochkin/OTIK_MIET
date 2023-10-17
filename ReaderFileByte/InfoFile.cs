using System.Text;

namespace ReaderFileByte;

public class InfoFile
{
	public string FilePath { get; set; } = null!;

	public Dictionary<byte, int> byteFrequency = new();

	public int TotalCharacters { get; set; }

	public double TotalInformation { get; set; }

	public InfoFile(string filePath)
	{
		FilePath = filePath;
		TotalInformation = 0;
	}

	public void CharacterCouting()
	{
		byte[] content = File.ReadAllBytes(FilePath);
		TotalCharacters = content.Length;

		PrintInfo.PrintCountCharacters(TotalCharacters);
	}

	public void FrequencyCouting()
	{
		byte[] content = File.ReadAllBytes(FilePath);

		foreach (byte c in content)
		{
			if (byteFrequency.ContainsKey(c))
				byteFrequency[c]++;
			else
				byteFrequency[c] = 1;
		}

		var sortedAlphabetically = byteFrequency.OrderBy(pair => pair.Key);
		var sortedByFrequency = byteFrequency.OrderByDescending(pair => pair.Value);

		Console.WriteLine("Таблица символов (отсортированная по алфавиту):");
		PrintInfo.PrintCharacterTable(sortedAlphabetically);

		Console.WriteLine("\nТаблица символов (отсортированная по убыванию частоты):");
		PrintInfo.PrintCharacterTable(sortedByFrequency);
	}

	public void FrequencyCoutingForAnalysis()
	{
		byte[] content = File.ReadAllBytes(FilePath);

		foreach (byte c in content)
		{
			if (byteFrequency.ContainsKey(c))
				byteFrequency[c]++;
			else
				byteFrequency[c] = 1;
		}

		var sortedAlphabetically = byteFrequency.OrderBy(pair => pair.Key).Take(20);
		var sortedByFrequency = byteFrequency.OrderByDescending(pair => pair.Value).Take(20);

		Console.WriteLine("Таблица символов (отсортированная по алфавиту):");
		PrintInfo.PrintCharacterTable(sortedAlphabetically);

		Console.WriteLine("\nТаблица символов (отсортированная по убыванию частоты):");
		PrintInfo.PrintCharacterTable(sortedByFrequency);
	}

	// Расчет вероятностей, количества информации и суммарной информации
	public void InformationCouting()
	{
		foreach (var pair in byteFrequency)
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
