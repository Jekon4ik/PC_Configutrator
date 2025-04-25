namespace Configurator_PC.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }

        public ComponentType? Type { get; set; }
        public ICollection<ComponentParameter>? Parameters { get; set; }
        public ICollection<ConfigurationComponent>? ConfigurationComponents { get; set; }
    }
}
