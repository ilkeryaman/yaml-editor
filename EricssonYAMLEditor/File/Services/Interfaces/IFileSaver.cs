
namespace EricssonYAMLEditor.File.Services.Interfaces
{
    interface IFileSaver<T>
    {
        void Save(string filePath, T data);
    }
}
