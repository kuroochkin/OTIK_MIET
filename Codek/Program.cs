using OTIK_MIET;
using Codek;
using System.Text;

bool exitMenu = false;

while (!exitMenu)
{
	Console.Clear(); // Очищаем консоль перед отображением меню
	Console.WriteLine("Консольное меню");
	Console.WriteLine("1. Создание файла и создание архива на его основе");
	Console.WriteLine("2. Выход");

	Console.Write("Введите номер выбора: ");
	string choice = Console.ReadLine();

	switch (choice)
	{
		case "1":
            Console.WriteLine("Введите название файла: ");
			string filename = Console.ReadLine();
			Console.WriteLine("Введите содержимое файла: ");
			string data = Console.ReadLine();
			byte[] byteArray = Encoding.UTF8.GetBytes(data);
			
			// Создание файла X
			var file = new ArchiveFile() { FileName = filename, EncodedData = byteArray };

			// Создание кодера
			var coder = new Coder(file);

			// Запускаем создание архива Y на основе файла X
			coder.CreateArchiveFromFile();

			Console.WriteLine("Данные архива: ");
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


