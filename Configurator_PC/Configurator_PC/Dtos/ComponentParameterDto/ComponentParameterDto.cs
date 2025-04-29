namespace Configurator_PC.Dtos
{
    public class ComponentParameterDto
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public int ParameterNameId { get; set; }
        public string? Value { get; set; }
    }
}
