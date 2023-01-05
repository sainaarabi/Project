using System.IO;

namespace SSO.Common.ExtensionMethods
{
    public static class StreamHelperExtentions
    {
        public static byte[] ReadToEnd(this Stream stream)
        {
            using MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
