namespace Configurator_PC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string? Password { get; set; }
        public ICollection<Configuration>? Configurations { get; set; }
    }
}
