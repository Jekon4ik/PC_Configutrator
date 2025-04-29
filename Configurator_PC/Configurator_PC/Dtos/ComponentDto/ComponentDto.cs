namespace Configurator_PC.Dtos
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
