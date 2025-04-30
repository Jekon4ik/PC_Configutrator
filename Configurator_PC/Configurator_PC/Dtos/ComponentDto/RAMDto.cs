namespace Configurator_PC.Dtos
{
    public class RAMDto : ComponentDto
    {
        public string MemtoryType { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public int Speed { get; set; }
    }
}
