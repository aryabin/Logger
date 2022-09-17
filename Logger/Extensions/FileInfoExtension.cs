using System.IO;

namespace Logger.Extensions
{
    internal static class FileInfoExtension
    {
        public static void MoveTo(this FileInfo fileInfo, string newFilePath, bool overwrite = false)
        {
            if (fileInfo == null || newFilePath == null)
            {
                return;
            }

            bool newFilePathExists = File.Exists(newFilePath);

            if (!overwrite && newFilePathExists)
            {
                return;
            }

            if (newFilePathExists)
            {
                File.Delete(newFilePath);
            }

            fileInfo.MoveTo(newFilePath);
        }
    }
}
