namespace OTIK_MIET;

[Serializable]
public class ArchiveHeader
{
	public string Signature { get; set; } // Сигнатура
	public int Version { get; set; } // Версия формата
	public int CompressionAlgorithmCode { get; set; } // Код алгоритма сжатия
	public int ErrorProtectionCode { get; set; }  // Код алгоритма защиты
	public long OriginalFileSize { get; set; }  // Исходная длина файла (байты)

	// Инициализация по умолчанию
	public ArchiveHeader()
	{
		Signature = "ARCV";
		Version = 1;
		CompressionAlgorithmCode = 1;
		ErrorProtectionCode = 2;
		OriginalFileSize = 1024;
	}
}
