namespace Configurator_PC.Models
{
    public class ComponentTypeParameterName
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int ParameterNameId { get; set; }

        public ComponentType? Type { get; set; }
        public ParameterName? ParameterName { get; set; }
    }
}
