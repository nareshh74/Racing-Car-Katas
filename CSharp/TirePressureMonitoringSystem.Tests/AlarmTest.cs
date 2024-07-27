using Moq;
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

    public class CheckShould
    {
        [Fact]
        public void Get_value_from_sensor()
        {
            // Arrange
            var sensorMock = new Mock<ISensor>();
            Alarm alarm = new(sensorMock.Object);

            // Act
            alarm.Check();

            // Assert
            sensorMock.Verify(x => x.PopNextPressurePsiValue(), Times.Once);
        }
    }
}