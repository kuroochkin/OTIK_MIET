using OTIK_MIET;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Codek;

public class Decoder
{
	public ArchiveData Archive { get; set; } // Ссылка на архив
	public ArchiveFile FileX { get; set; } // Ссылка на файл

	public Decoder(ArchiveData archive)
	{
		Archive = archive;
	}

	public void CreateFileFromArchive()
	{
		string[] parts = Archive.Name.Split('.');

		// Создаем файл
		FileX = new ArchiveFile();

		FileX.FileName = $"{parts[0]}1.txt";

		var connectionString = $"C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\Codek\\{FileX.FileName}";

		using (MemoryStream stream = new MemoryStream())
		{
			File.WriteAllBytes(connectionString, Archive.EncodedData);
		}

		if (Archive.Header.CompressionAlgorithm == 0 && Archive.Header.ErrorProtectionAlgorithm == 0)
		{
			// Обмен данными
			FileX.EncodedData = Archive.EncodedData;
		}
		else
		{
			Console.WriteLine("Коды алгоритмов сжатия и защиты от помех неверны");
		}
	}
}

