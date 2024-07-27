namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public const double LowPressureThreshold = 17;
        public const double HighPressureThreshold = 21;

        public ISensor Sensor { get; }

        public bool AlarmOn { get; private set; }
        public long AlarmCount { get; private set; }

        public Alarm(ISensor sensor)
        {
            this.Sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = this.Sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this.AlarmOn = true;
                this.AlarmCount += 1;
            }
        }
    }
}
