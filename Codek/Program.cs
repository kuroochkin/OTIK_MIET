using OTIK_MIET;
using Codek;
using System.Text;
using Decoder = Codek.Decoder;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

bool exitMenu = false;

while (!exitMenu)
{
	Console.Clear(); // Очищаем консоль перед отображением меню
	Console.WriteLine("Консольное меню");
	Console.WriteLine("1. Создание файла и создание архива на его основе файла");
	Console.WriteLine("2. Создание файла и создание архива на его основе архива");
	Console.WriteLine("3. Выход");

	Console.Write("Введите номер выбора: ");
	string choice = Console.ReadLine();

	switch (choice)
	{
		case "1":
			byte[] byteArray = File.ReadAllBytes("C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\Codek\\file.txt");
			
			// Создание файла X
			var file = new ArchiveFile() { FileName = "file.txt", EncodedData = byteArray };

			// Создание кодера
			var coder = new Coder(file);

			// Запускаем создание архива Y на основе файла X
			coder.CreateArchiveFromFile();

			Console.WriteLine("Данные файла: ");
			foreach (var item in coder.FileX.EncodedData)
			{
				Console.WriteLine(item.ToString());
			}

			Console.WriteLine("Данные архива: ");
            foreach (var item in coder.Archive.EncodedData)
			{
				Console.WriteLine(item.ToString());
			}

			break;

		case "2":
			
			byte[] byteArray1 = File.ReadAllBytes("C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\Codek\\file.arc");

			var archive1 = new ArchiveData()
			{
				Name = "file.arc",
				EncodedData = byteArray1,
			};

			var decoder = new Decoder(archive1);

			decoder.CreateFileFromArchive();


			Console.WriteLine("Данные архива: ");
			foreach (var item in decoder.FileX.EncodedData)
			{
				Console.WriteLine(item.ToString());
			}

			Console.WriteLine("Данные файла: ");
			foreach (var item in decoder.Archive.EncodedData)
			{
				Console.WriteLine(item.ToString());
			}

			break;

		case "3":
			exitMenu = true; // Выход из меню
			break;

		default:
			Console.WriteLine("Неверный выбор. Попробуйте снова.");
			break;
	}

	Console.WriteLine("Нажмите Enter для продолжения...");
	Console.ReadLine();
}


