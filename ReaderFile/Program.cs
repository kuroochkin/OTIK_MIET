using ReaderFile;

// Ввод файла
//  C:\Users\pin11\source\repos\OTIK_MIET\ReaderFile\text.txt
string filePath = "C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\ReaderFile\\text1.txt";

var file = new InfoFile(filePath);

if (File.Exists(filePath))
{
	// Подсчет символов
	file.CharacterCouting();

	// Подсчет частоты
    file.FrequencyCouting();

	// Расчет вероятностей, количества информации и суммарной информации
	file.InformationCouting();
} 
else
{
	Console.WriteLine("Файл не найден.");
}

