using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMeasurementService.Model
{
    public class Measurement
    {
        public int Id { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
        public DateTime TimeStamp { get; set; }

        public Measurement(int id, double pressure, double humidity, double temperature, DateTime timeStamp)
        {
            Id = id;
            Pressure = pressure;
            Humidity = humidity;
            Temperature = temperature;
            TimeStamp = timeStamp;
        }

        public Measurement()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Pressure)}: {Pressure}, {nameof(Humidity)}: {Humidity}, {nameof(Temperature)}: {Temperature}, {nameof(TimeStamp)}: {TimeStamp}";
        }
    }
}
