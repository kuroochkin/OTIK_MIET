namespace ReaderFileByte;

public static class InfoFileStatic
{
	public static bool IsPrintableASCII(byte b)
	{
		return b >= 32 && b <= 126;
	}
}
