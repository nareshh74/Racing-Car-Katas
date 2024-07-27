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

            [Theory]
            [InlineData(Alarm.LowPressureThreshold - 1, true)]
            [InlineData(Alarm.LowPressureThreshold, false)]
            [InlineData(Alarm.HighPressureThreshold + 1, true)]
            public void Set_alarm_as_expected(int value, bool expected)
            {
                // Arrange
                var sensorMock = new Mock<ISensor>();
                sensorMock.Setup(x => x.PopNextPressurePsiValue()).Returns(value);
                Alarm alarm = new(sensorMock.Object);

                // Act
                alarm.Check();

                // Assert
                Assert.Equal(expected, alarm.AlarmOn);
            }

            [Fact]
            public void Increment_alarm_count()
            {
                // Arrange
                var sensorMock = new Mock<ISensor>();
                sensorMock.Setup(x => x.PopNextPressurePsiValue()).Returns(Alarm.LowPressureThreshold - 1);
                Alarm alarm = new(sensorMock.Object);

                // Act
                alarm.Check();

                // Assert
                Assert.Equal(1, alarm.AlarmCount);
            }
        }

        public class AlarmOnShould
        {
            [Theory]
            [InlineData(Alarm.LowPressureThreshold - 1, true)]
            [InlineData(Alarm.LowPressureThreshold, false)]
            [InlineData(Alarm.HighPressureThreshold + 1, true)]
            public void Get_alarm_on_as_expected(int value, bool expected)
            {
                // Arrange
                var sensorMock = new Mock<ISensor>();
                sensorMock.Setup(x => x.PopNextPressurePsiValue()).Returns(value);
                Alarm alarm = new(sensorMock.Object);

                // Act
                alarm.Check();

                // Assert
                Assert.Equal(expected, alarm.AlarmOn);
            }
        }
    }
}