namespace Configurator_PC.Models
{
    public class Compatibility
    {
        public int Id { get; set; }
        public int Component1Id { get; set; }
        public int Component2Id { get; set; }
        public int ParameterNameId { get; set; }

        public string? Value1 { get; set; }
        public string? Value2 { get; set; }
        public bool? IsCompatible { get; set; }

        public Component? Component1 { get; set; }
        public Component? Component2 { get; set; }
        public ParameterName? ParameterName { get; set; }
    }
}
