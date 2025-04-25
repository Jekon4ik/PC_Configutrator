namespace Configurator_PC.Models
{
    public class ComponentParameter
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int ParameterNameId { get; set; }
        public string? Value { get; set; }

        public Component? Component { get; set; }
        public ParameterName? ParameterName { get; set; }
    }
}
