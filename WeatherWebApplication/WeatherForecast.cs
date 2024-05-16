using System.ComponentModel.DataAnnotations;

namespace WeatherWebApplication
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        [Range(-200, 100)]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required]
        public string? Summary { get; set; }

        //[EmailAddress]
        //public string Email {  get; set; }
        //[RegularExpression(@"[\d]{1,3\.}")]
       // public string IpAddress{  get; set; }

    }
}
