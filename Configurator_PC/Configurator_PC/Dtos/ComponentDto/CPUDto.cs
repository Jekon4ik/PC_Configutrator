namespace Configurator_PC.Dtos
{
    public class CPUDto : ComponentDto
    {
        public string Socket { get; set; } = string.Empty;
        public int CoreCount { get; set; }
        public int ThreadCount { get; set; }
        public double BaseClock { get; set; }
        public double BoostClock { get; set; }
        public int TDP { get; set; }
    }
}
