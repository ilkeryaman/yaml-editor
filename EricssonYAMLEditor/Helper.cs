using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace EricssonYAMLEditor
{
    class Helper
    {
        public void test()
        {
            var deserializer = new Deserializer();
            var result = deserializer.Deserialize<Dictionary<string, Object>>(new StreamReader("C:\\Users\\eilkyam\\Desktop\\ilker2.yaml"));



            var stringBuilder = new StringBuilder();
            var serializer = new Serializer();
            stringBuilder.AppendLine(serializer.Serialize(result));

            var stream = new FileStream("C:\\Users\\eilkyam\\Desktop\\ilker555_generated.yaml", FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.Write(stringBuilder);
                writer.Close();
            }
        }

        public void test2(object result)
        {
            var stringBuilder = new StringBuilder();
            var serializer = new Serializer();
            stringBuilder.AppendLine(serializer.Serialize(result));

            var stream = new FileStream("C:\\Users\\eilkyam\\Desktop\\ilker412.yaml", FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.Write(stringBuilder);
                writer.Close();
            }
        }
    }
}
