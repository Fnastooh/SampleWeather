namespace SampleWeather.Service
{
    public interface IFileReader<T> where T : class, new()
    {
        List<T> Read();
    }
}