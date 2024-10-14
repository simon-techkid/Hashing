// Hashing by Simon Field

using System.IO;

namespace Hashing.Provisioning.Providers;

public class FileHashProvider : IHashingProvider<FileStream>
{
    public byte[] ConvertToBytes(FileStream data)
    {
        byte[] buffer = new byte[1024];
        using MemoryStream memoryStream = new();
        int read;
        while ((read = data.Read(buffer, 0, buffer.Length)) > 0)
        {
            memoryStream.Write(buffer, 0, read);
        }
        return memoryStream.ToArray();
    }
}
