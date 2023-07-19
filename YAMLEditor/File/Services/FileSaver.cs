using YAMLEditor.File.Services.Interfaces;
using System.IO;
using System.Text;

namespace YAMLEditor.File.Services
{
    class FileSaver : IFileSaver<string>
    {
        public void Save(string filePath, string data)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(data);

            var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.Write(stringBuilder);
                writer.Close();
            }
        }
    }
}
