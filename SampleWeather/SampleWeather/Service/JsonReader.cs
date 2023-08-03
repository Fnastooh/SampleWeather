using Newtonsoft.Json.Linq;

namespace SampleWeather.Service
{
    public class JsonReader<T> : IFileReader<T> where T : class, new()
    {
        public List<T> Read()
        {
            using StreamReader reader = new("cities.json");
            var json = reader.ReadToEnd();
            var jarray = JArray.Parse(json);
            List<T> teachers = new();

            foreach (var item in jarray)
            {
                T teacher = item.ToObject<T>() ?? new T();
                teachers.Add(teacher);
            }

            return teachers;
        }
    }
}
