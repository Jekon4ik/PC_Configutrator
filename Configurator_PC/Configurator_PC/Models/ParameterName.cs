namespace Configurator_PC.Models
{
    public class ParameterName
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ComponentParameter>? ComponentParameters { get; set; }
        public ICollection<ComponentTypeParameterName>? ComponentTypeLinks { get; set; }
        public ICollection<Compatibility>? Compatibilities { get; set; }
    }
}
