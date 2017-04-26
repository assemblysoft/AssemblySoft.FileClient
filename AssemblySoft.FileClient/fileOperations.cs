using System.IO;
using System.Threading.Tasks;

namespace AssemblySoft.IO
{
    /// <summary>
    /// Client for common file tasks
    /// </summary>
    public partial class FileClient
    {
        /// <summary>
        /// Writes text to a text file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        /// <param name="append"></param>
        public static void WriteTextToFile(string path, string text, bool append = false)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            var dir = Path.GetDirectoryName(path);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (TextWriter writer = new StreamWriter(path, append))
            {
                writer.WriteLine(text);
                writer.Flush();
            }
        }

        /// <summary>
        /// Writes text to a text file asyncronously
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        /// <param name="append"></param>
        /// <returns></returns>
        public static async Task WriteTextToFileAsync(string path, string text, bool append = false)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            var dir = Path.GetDirectoryName(path);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (TextWriter writer = new StreamWriter(path, append))
            {
                await writer.WriteAsync(text);
                await writer.FlushAsync();
            }
        }

        /// <summary>
        /// Deletes the file
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }        
    }    

}