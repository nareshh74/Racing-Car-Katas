using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        public class CtorShould
        {
            [Fact]
            public void Set_sensor()
            {
                ISensor sensor = new Sensor();
                Alarm alarm = new(sensor);
                Assert.Same(sensor, alarm.Sensor);
            }
        }
    }
}