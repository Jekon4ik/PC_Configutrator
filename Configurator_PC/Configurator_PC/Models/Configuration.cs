namespace Configurator_PC.Models
{
    public class Configuration
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ConfigurationComponent>? ConfigurationComponents { get; set; }

    }
}
