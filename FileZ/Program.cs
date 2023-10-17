using ReaderFileByte;
using System.Text;

string filePath = "C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\FileZ\\7.txt";

byte[] content = File.ReadAllBytes(filePath);

foreach (byte c in content)
{
	if(c >= 192 && c <= 255)
	{
		Console.WriteLine("Файл содержит русскоязычный текст.");
		break;
	}
}

//Unicode(UTF - 8)
Encoding encoding = InfoFileStatic.DetectFileEncoding(filePath);
Console.WriteLine($"Кодировка: {encoding.EncodingName}");


var file = new InfoFile(filePath);

if (File.Exists(filePath))
{
	// Подсчет частоты
	file.FrequencyCouting();
}
else
{
	Console.WriteLine($"Файл {filePath} не найден.");
}



