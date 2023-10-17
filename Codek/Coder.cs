using OTIK_MIET;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Linq;

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
		string[] parts = FileX.FileName.Split('.');

		// Создаем архив
		Archive = new ArchiveData();

		Archive.Name = $"{parts[0]}.{Archive.Header.Signature}";
		Archive.EncodedData = new byte[] { };

		var connectionString = $"C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\Codek\\{Archive.Name}";

		byte[] archiveBytes;
		using (MemoryStream stream = new MemoryStream())
		{
			IFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, Archive.EncodedData);
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
