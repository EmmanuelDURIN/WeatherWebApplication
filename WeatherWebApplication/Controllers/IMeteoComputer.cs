namespace WeatherWebApplication.Controllers
{
    public interface IMeteoComputer
    {
        void Acquire();
        bool Validate();
    }
}