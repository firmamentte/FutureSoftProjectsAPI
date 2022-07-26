using System.Text.Json;

namespace FutureSoftProjectsAPI.Data
{
    public class StaticClass
    {
        public static class JsonFileReader
        {
            public static async Task<T> ReadAsync<T>(string filePath)
            {
                using FileStream _stream = File.OpenRead(filePath);
                return await JsonSerializer.DeserializeAsync<T>(_stream);
            }
        }
    }
}
