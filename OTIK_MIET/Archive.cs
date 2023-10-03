namespace OTIK_MIET;

public class Archive
{
	public ArchiveHeader Header { get; set; }
	public byte[] EncodedData { get; set; }

	public Archive()
	{
		Header = new ArchiveHeader();
		EncodedData = new byte[0];
	}
}
