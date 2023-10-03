namespace OTIK_MIET;

[Serializable]
public class ArchiveHeader
{
	public string Signature { get; set; } // Сигнатура
	public int Version { get; set; } // Версия формата
	public List<int> CompressionAlgorithms { get; set; } // Коды алгоритмов сжатия
	public List<int> ErrorProtectionAlgorithms { get; set; } // Коды алгоритмов защиты от помех
	public int CompressionAlgorithm { get; set; } // Выбранный код сжатия
	public int ErrorProtectionAlgorithm { get; set; } // Выбранный код защиты
	public long OriginalFileSize { get; set; } // Исходная длина файла (в байтах)

	public ArchiveHeader()
	{
		Signature = "ARCV";
		Version = 1;
		CompressionAlgorithm = 0;
		ErrorProtectionAlgorithm = 0;
		CompressionAlgorithms = new List<int> { 1, 2, 3 };
		ErrorProtectionAlgorithms = new List<int> { 1, 2, 3 };
		OriginalFileSize = 1024;
	}
}

