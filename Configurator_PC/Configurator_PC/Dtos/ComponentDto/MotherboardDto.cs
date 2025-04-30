namespace Configurator_PC.Dtos
{
    public class MotherboardDto : ComponentDto
    {
        public string Socket { get; set; } = string.Empty;
        public string FormFactor { get; set; } = string.Empty;
        public string SupportedMemoryType { get; set; } = string.Empty;
        public int MemorySlots { get; set; }
        public int M2Slots { get; set; }
        public int SataPorts { get; set; }
    }
}
