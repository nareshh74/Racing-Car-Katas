namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        public const double LowPressureThreshold = 17;
        public const double HighPressureThreshold = 21;

        public ISensor Sensor { get; }

        public bool On { get; private set; }
        public long Count { get; private set; }

        public Alarm(ISensor sensor)
        {
            this.Sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = this.Sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this.On = true;
                this.Count += 1;
            }
        }
    }
}
