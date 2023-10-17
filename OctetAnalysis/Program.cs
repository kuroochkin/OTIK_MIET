using ReaderFileByte;

string filePath1 = "C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\OctetAnalysis\\Льюис Кэрролл. Охота на Снарка — Кружков — dos.txt";
string filePath2 = "C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\OctetAnalysis\\Льюис Кэрролл. Охота на Снарка — Кружков — iso.txt";
string filePath3 = "C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\OctetAnalysis\\Льюис Кэрролл. Охота на Снарка — Кружков — koi8r.txt";

// Список адресов файлов
List<string> filespaths = new() { filePath1, filePath2, filePath3 };

// Массив всех байтов из файлов
List<byte> bytes = new();

Dictionary<byte, int> byteFrequency = new Dictionary<byte, int>();

foreach (var filepath in filespaths)
{
	var file = new InfoFile(filepath);
	
	foreach(byte item in File.ReadAllBytes(filepath))
	{
		bytes.Add(item);
	}

	Console.WriteLine("+++++++++++++++++++++++++++++");
    Console.WriteLine($"Работа с файлом ${filepath}");

    if (File.Exists(filepath))
	{
		// Подсчет символов
		file.CharacterCouting();

		// Подсчет частоты
		file.FrequencyCoutingForAnalysis();
	}
	else
	{
		Console.WriteLine($"Файл {filepath} не найден.");
	}
}

foreach (var b in bytes)
{
	// Исключение кодов печатных символов ASCII - (!)
	if (!InfoFileStatic.IsPrintableASCII(b))
	{
		if (byteFrequency.ContainsKey(b))
			byteFrequency[b]++;
		else
			byteFrequency[b] = 1;
	}
}

var sortedBytes = byteFrequency.OrderByDescending(pair => pair.Value);

Console.WriteLine();
Console.WriteLine("Самые частые октеты:");
int count = 0;
foreach (var pair in sortedBytes)
{
	if (count >= 4)
		break;
	Console.WriteLine($"Байт: 0x{pair.Key}, Частота: {pair.Value}");
	count++;
}

