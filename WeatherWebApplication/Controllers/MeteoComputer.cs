
namespace WeatherWebApplication.Controllers
{
    public class MeteoComputer : IMeteoComputer, IDisposable
    {
        private IMeteoDataRecorder meteoDataRecorder;
        // Injection par constructeur
        public MeteoComputer(IMeteoDataRecorder meteoDataRecorder)
        {
            this.meteoDataRecorder = meteoDataRecorder;
        }
        public void Acquire()
        {
            meteoDataRecorder.Record();
        }
        public bool Validate()
        {
            return true;
        }
        public void Dispose()
        {
        }
    }
}