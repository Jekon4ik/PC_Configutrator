namespace Configurator_PC.Dtos.ComponentDto
{
    public class StorageDto : ComponentDto
    {
        public string Type { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Interface { get; set; } = string.Empty;
    }
}
