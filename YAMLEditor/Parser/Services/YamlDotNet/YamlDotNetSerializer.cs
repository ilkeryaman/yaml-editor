using YamlDotNet.Serialization;

namespace YAMLEditor.Parser.Services.YamlDotNet
{
    class YamlDotNetSerializer : Interfaces.ISerializer
    {
        public string Serialize(object data)
        {
            var serializer = new Serializer();
            return serializer.Serialize(data);
        }
    }
}
