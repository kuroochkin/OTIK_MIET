using OTIK_MIET;

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

	}
}

