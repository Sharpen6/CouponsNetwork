using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouponsOnline.BusinessLayer.Factory
{
    public class SensorFactory
    {
        public static int GetSensor(SensorType type, string[] args)
        {
            switch (type)
            {
                case SensorType.Location:
                    return CreateLocationSensor(args);
                case SensorType.Time:
                    CreateLocationSensor(args);
                    break;
                case SensorType.Temperature:
                    CreateTimeSensor(args);
                    break;
                default:
                    break;
            }
            return 0;
        }

        private static int CreateLocationSensor(string[] args)
        {
            Sensor s = new Sensor();
            Location loc = new Location();
            using (basicEntities be = new basicEntities())
            {
                s = be.Sensors.Add(s);
                be.SaveChanges();
                loc.Id = s.Id;
                loc.Latitude = args[1];
                loc.Longitude = args[0];
                loc.Sensor = s;
                be.Locations.Add(loc);
                be.SaveChanges();
            }
            return s.Id;
        }
        private static int CreateTimeSensor(string[] args)
        {
            Sensor s = new Sensor();
            Time time = new Time();
            using (basicEntities be = new basicEntities())
            {
                s = be.Sensors.Add(s);
                be.SaveChanges();
                time.Id = s.Id;
                time.Value = args[0];
                time.Sensor = s;
                be.Times.Add(time);
                be.SaveChanges();
            }
            return s.Id;
        }
        private static int CreateTemperatureSensor(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}