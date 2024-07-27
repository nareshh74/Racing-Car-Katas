namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public const double LowPressureThreshold = 17;
        public const double HighPressureThreshold = 21;

        public ISensor Sensor { get; }

        bool _alarmOn = false;
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
                _alarmOn = true;
                this.AlarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
