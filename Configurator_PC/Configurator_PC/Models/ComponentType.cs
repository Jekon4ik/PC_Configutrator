namespace Configurator_PC.Models
{
    public class ComponentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Component>? Components { get; set; }
        public ICollection<ComponentTypeParameterName>? AllowedParameterNames { get; set; }
    }
}
