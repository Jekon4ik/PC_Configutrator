namespace Configurator_PC.Dtos
{
    public class GPUDto : ComponentDto
    {
        public string  Inteface { get; set; } = string.Empty;
        public string MemoryType { get; set; } = string.Empty;
        public int MemoryCapacity { get; set; }
        public int PowerSupply { get; set; }
    }
}
