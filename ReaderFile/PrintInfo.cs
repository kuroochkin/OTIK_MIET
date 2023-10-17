namespace ReaderFile;

public static class PrintInfo
{
	public static void PrintCharacterTable(IEnumerable<KeyValuePair<char, int>> charFrequencies)
	{
		Console.WriteLine("Символ\tЧастота");
		foreach (var pair in charFrequencies)
		{
			Console.WriteLine($"{pair.Key}\t{pair.Value}");
		}
	}

	public static void PrintCountCharacters(int totalCharacters)
	{
		Console.WriteLine($"Длина файла в символах: {totalCharacters}");
	}
}
