namespace OTIK_MIET;

[Serializable]
public class ArchiveFile
{
	public string FileName { get; set; } // Имя файла
	public byte[] EncodedData { get; set; } // Закодированные данные файла
}
