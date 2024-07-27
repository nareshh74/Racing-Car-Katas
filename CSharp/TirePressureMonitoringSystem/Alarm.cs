namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        public ISensor Sensor { get; }

        bool _alarmOn = false;
        private long _alarmCount = 0;

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
                _alarmCount += 1;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
