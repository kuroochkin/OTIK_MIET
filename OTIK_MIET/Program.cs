using OTIK_MIET;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;

// Создание архива
var archive = new ArchiveData();

var connectionString = "C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\OTIK_MIET\\myarchive.arc";

byte[] archiveBytes;
using (MemoryStream stream = new MemoryStream())
{
	IFormatter formatter = new BinaryFormatter();
	formatter.Serialize(stream, archive);
	archiveBytes = stream.ToArray();
	File.WriteAllBytes(connectionString, archiveBytes);
}



bool exitMenu = false;

while (!exitMenu)
{
	Console.Clear(); // Очищаем консоль перед отображением меню
	Console.WriteLine("Консольное меню");
    Console.WriteLine("1. Создание нового файла в архиве");
    Console.WriteLine("2. Вывести название всех файлов в архиве");
	Console.WriteLine("3. Записать данные в файл по имени");
	Console.WriteLine("4. Считать данные из файла по имени в байтах");
	Console.WriteLine("5. Считать данные из файла в текстовом виде");
	Console.WriteLine("6. Считать данные об архиве");
	Console.WriteLine("7. Выход");

	Console.Write("Введите номер выбора: ");
	string choice = Console.ReadLine();

	switch (choice)
	{
		case "1":
			Console.WriteLine("Введите название файла: ");
			string name = Console.ReadLine();

			var __file = new ArchiveFile()
			{
				FileName = name,
				EncodedData = new byte[] { },
			};

			archive.Files.Add(__file);
			break;


		case "2":
			if (archive.Files.Count > 0)
				foreach (var item in archive.Files)
				{
					Console.WriteLine(item.FileName);
				}
			else
                Console.WriteLine("Архив не содержит файлов");

            break;

		case "3":
            Console.WriteLine("Введите название файла, в который хотите внести изменения:");
			string _filename = Console.ReadLine();
			var _file = archive.Files.FirstOrDefault(file => file.FileName == _filename);
			if(_file is null)
			{
				Console.WriteLine("Такого файла не существует");
				break;
			}
            
            Console.WriteLine("Введите данные, которые хотите занести в файл: ");
			string _data = Console.ReadLine();
			byte[] byteArray = Encoding.UTF8.GetBytes(_data);
			_file.EncodedData = byteArray;
			ArchiveData.SerializeToBinaryFile(connectionString, archive);
			break;

		case "4":
			Console.WriteLine("Введите название файла, из которого хотите считать информацию в байтах:");
			string _filename1 = Console.ReadLine();
			var _file1 = archive.Files.FirstOrDefault(file => file.FileName == _filename1);
			if (_file1 is null)
			{
				Console.WriteLine("Такого файла не существует");
				break;
			}

			foreach (var item in _file1.EncodedData)
			{
				Console.WriteLine(item.ToString());
			}
			break;

		case "5":
			Console.WriteLine("Введите название файла, из которого хотите считать информацию в байтах:");
			string _filename2 = Console.ReadLine();
			var _file2 = archive.Files.FirstOrDefault(file => file.FileName == _filename2);
			if (_file2 is null)
			{
				Console.WriteLine("Такого файла не существует");
				break;
			}

			string str = Encoding.UTF8.GetString(_file2.EncodedData);
			Console.WriteLine(str);
			break;

		case "6":
			var archiveData = (ArchiveData)ArchiveData.DeserializeFromBinaryFile(connectionString);
			var archiveHeader = archiveData.Header;

			var builder = new StringBuilder();
			builder.AppendLine(archiveHeader.Signature);
			builder.AppendLine(archiveHeader.Version.ToString());
			foreach (var item in archiveHeader.CompressionAlgorithms)
			{
				builder.Append(item + " ");
			}
			builder.AppendLine();
			foreach (var item in archiveHeader.ErrorProtectionAlgorithms)
			{
				builder.Append(item + " ");
			}
			builder.AppendLine();
			builder.Append(archiveHeader.OriginalFileSize);

			Console.WriteLine(builder.ToString());
			break;

		case "7":
			exitMenu = true; // Выход из меню
			break;

		default:
			Console.WriteLine("Неверный выбор. Попробуйте снова.");
			break;
	}

	Console.WriteLine("Нажмите Enter для продолжения...");
	Console.ReadLine();
}
