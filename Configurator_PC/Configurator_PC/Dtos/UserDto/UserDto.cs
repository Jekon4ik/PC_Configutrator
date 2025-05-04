namespace Configurator_PC.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string? Password { get; set; }
    }
}
