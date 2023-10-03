using OTIK_MIET;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Codek;

[Serializable]
public class Coder
{
	public ArchiveData Archive { get; set; } // Ссылка на архив
	public ArchiveFile FileX { get; set; } // Ссылка на файл

	public Coder(ArchiveFile file)
	{
		FileX = file;
	}

	public void CreateArchiveFromFile()
	{
		// Создаем архив
		Archive = new ArchiveData();

		var connectionString = "C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\Codek\\coder.arc";

		byte[] archiveBytes;
		using (MemoryStream stream = new MemoryStream())
		{
			IFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, Archive);
			archiveBytes = stream.ToArray();
			File.WriteAllBytes(connectionString, archiveBytes);
		}

		if (Archive.Header.CompressionAlgorithm == 0 && Archive.Header.ErrorProtectionAlgorithm == 0)
		{
			// Обмен данными
			Archive.EncodedData = FileX.EncodedData;
		}
		else
		{
            Console.WriteLine("Коды алгоритмов сжатия и защиты от помех неверны");
        }
	}


}
