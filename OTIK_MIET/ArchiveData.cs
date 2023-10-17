using System.Runtime.Serialization.Formatters.Binary;

namespace OTIK_MIET;

[Serializable]
public class ArchiveData
{
	public string Name { get; set; }
	public ArchiveHeader Header { get; set; }
	public List<ArchiveFile> Files { get; set; } // Список файлов
	public byte[] EncodedData { get; set; } // Содержимое архива

	public ArchiveData()
	{
		Header = new ArchiveHeader();
		Files = new List<ArchiveFile>();
	}

	// Сериализация объекта в бинарный файл
	public static void SerializeToBinaryFile(string filePath, object obj)
	{
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(fs, obj);
		}
	}

	// Десериализация объекта из бинарного файла
	public static object DeserializeFromBinaryFile(string filePath)
	{
		using (FileStream fs = new FileStream(filePath, FileMode.Open))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			return formatter.Deserialize(fs);
		}
	}
}

