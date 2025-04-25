namespace Configurator_PC.Models
{
    public class ConfigurationComponent
    {
        public int Id { get; set; }
        public int ConfigurationId { get; set; }
        public int ComponentId { get; set; }

        public Configuration? Configuration { get; set; }
        public Component? Component { get; set; }
    }
}
