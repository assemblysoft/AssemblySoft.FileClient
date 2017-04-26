using System.IO;
using System.IO.Compression;

namespace AssemblySoft.FileClient
{

    /// <summary>
    /// Client for common file zip tasks
    /// </summary>
    public partial class FileClient
    {
        /// <summary>
        /// Unzips all files in a zip archive to a specified directory
        /// </summary>
        /// <param name="sourceZipPath">source zip file</param>
        /// <param name="extractPath"></param>
        public static void UnzipFileToDirectory(string sourceZipPath, string extractPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(sourceZipPath, extractPath);
            }
            catch (System.Exception e)
            {
                throw new FileClientException(e.Message, e);
            }
        }

        /// <summary>
        /// Unzips a zip archive, preserving directory hirearchy
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="targetDirectory"></param>
        public static void UnzipFiles(string zipFile, string targetDirectory)
        {
            try
            {
                using (var archive = ZipFile.OpenRead(zipFile))
                {
                    foreach (var entry in archive.Entries)
                    {
                        var dir = Path.GetDirectoryName(entry.FullName);
                        if (dir != null && !Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        var file = Path.GetFileName(entry.FullName);
                        if (!string.IsNullOrWhiteSpace(file))
                        {
                            entry.ExtractToFile(Path.Combine(targetDirectory, entry.FullName), true);
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new FileClientException(e.Message, e);
            }
        }
    }
}
