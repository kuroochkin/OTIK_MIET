using System.Text;
using System.Text.RegularExpressions;

namespace ReaderFileByte;

public static class InfoFileStatic
{
	public static bool IsPrintableASCII(byte b)
	{
		return b >= 32 && b <= 126;
	}

	public static Encoding DetectFileEncoding(string filePath)
	{
		// Открытие файла в режиме чтения с автоматическим определением кодировки
		using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
		{
			using (StreamReader reader = new StreamReader(fileStream, Encoding.Default, true))
			{
				// Чтение первых нескольких байтов из файла для определения кодировки
				byte[] buffer = new byte[4];
				reader.BaseStream.Read(buffer, 0, buffer.Length);

				// Определение кодировки
				if (buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)
				{
					// UTF-8 с BOM (Byte Order Mark)
					return Encoding.UTF8;
				}
				else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
				{
					// UTF-16 little-endian с BOM
					return Encoding.Unicode;
				}
				else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
				{
					// UTF-16 big-endian с BOM
					return Encoding.BigEndianUnicode;
				}
				else if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xFE && buffer[3] == 0xFF)
				{
					// UTF-32 big-endian с BOM
					return Encoding.GetEncoding("UTF-32BE");
				}
				else if (buffer[0] == 0xFF && buffer[1] == 0xFE && buffer[2] != 0 && buffer[3] != 0)
				{
					// UTF-32 little-endian с BOM
					return Encoding.UTF32;
				}
				else
				{
					// Если BOM не найден, используйте ANSI как кодировку по умолчанию
					return Encoding.Default;
				}
			}
		}
	}
}