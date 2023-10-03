namespace OTIK_MIET;

[Serializable]
public class ArchiveHeader
{
	public string Signature { get; set; } // Сигнатура
	public int Version { get; set; } // Версия формата
	public List<string> CompressionAlgorithms { get; set; } // Коды алгоритмов сжатия
	public List<string> ErrorProtectionAlgorithms { get; set; } // Коды алгоритмов защиты от помех
	public long OriginalFileSize { get; set; } // Исходная длина файла (в байтах)

	public ArchiveHeader()
	{
		Signature = "ARCV";
		Version = 1;
		CompressionAlgorithms = new List<string> { "LZW", "Huffman" };
		ErrorProtectionAlgorithms = new List<string> { "ReedSolomon" };
		OriginalFileSize = 1024;
	}
}

