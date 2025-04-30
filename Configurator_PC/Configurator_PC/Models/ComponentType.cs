namespace Configurator_PC.Models
{
    public class ComponentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Component>? Components { get; set; }
        public ICollection<ComponentTypeParameterName>? AllowedParameterNames { get; set; }

        public ICollection<CompatibilityRule>? RulesAsType1 { get; set; }
        public ICollection<CompatibilityRule>? RulesAsType2 { get; set; }
    }
}
