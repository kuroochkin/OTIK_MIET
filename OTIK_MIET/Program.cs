using OTIK_MIET;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

// Создание архива
Archive archive = new Archive();

byte[] archiveBytes;
using (MemoryStream stream = new MemoryStream())
{
	IFormatter formatter = new BinaryFormatter();
	formatter.Serialize(stream, archive);
	archiveBytes = stream.ToArray();
}

File.WriteAllBytes("C:\\Users\\pin11\\source\\repos\\OTIK_MIET\\OTIK_MIET\\myarchive.arc", archiveBytes);
